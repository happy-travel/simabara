using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HT.StdOutLogger.Models;
using Microsoft.AspNetCore.Http;

namespace HT.StdOutLogger.Internals
{
    internal static class HttpLogHelper
    {
        public static async Task<FormattedHttpRequest> GetFormattedHttpRequest(HttpRequest httpRequest)
        {
            if (httpRequest is null)
                return new FormattedHttpRequest();

            var traceIdentifier = httpRequest.HttpContext.TraceIdentifier;
            var method = httpRequest.Method;
            var path = httpRequest.Path;
            var host = httpRequest.Host.ToString();
            var headers = GetFormattedHeaders(httpRequest.Headers);
            var requestBody = await GetRequestBody(httpRequest);

            return new FormattedHttpRequest(traceIdentifier, method, host, path, headers, requestBody);
        }


        public static FormattedHttpResponse GetFormattedHttpResponse(HttpResponse httpResponse)
        {
            if (httpResponse is null)
                return new FormattedHttpResponse();

            var statusCode = httpResponse.StatusCode;
            var headers = GetFormattedHeaders(httpResponse.Headers);

            return new FormattedHttpResponse(statusCode, headers);
        }


        private static List<string> GetFormattedHeaders(IHeaderDictionary headerDictionary)
        {
            return headerDictionary.Where(h => h.Value.Any()).Select(h => $"{h.Key}: {h.Value.First()}").ToList();
        }


        public static string GetTraceId(HttpRequest httpRequest)
        {
            return httpRequest.Headers.FirstOrDefault(i => i.Key.Equals(TraceIdHeader)).Value.FirstOrDefault();
        }


        private static async Task<string> GetRequestBody(HttpRequest httpRequest)
        {
            httpRequest.EnableBuffering(50 * 1024, 100 * 1024);
            var body = string.Empty;
            try
            {
                using (var reader = new StreamReader(httpRequest.Body,
                    Encoding.UTF8,
                    false,
                    Convert.ToInt32(httpRequest.ContentLength),
                    true))
                {
                    body = await reader.ReadToEndAsync();
                    httpRequest.Body.Position = 0;
                }
            }
            catch
            {
                //ignore
            }

            return body;
        }


        private const string TraceIdHeader = "TraceId";
    }
}