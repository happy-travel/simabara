using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using StdOutLogger.Internals;
using StdOutLogger.Models;

namespace StdOutLogger
{
    public class HttpContextLogger: IHttpContextLogger
    {
        public async Task AddHttpRequest(HttpRequest httpRequest)
        {
            _traceId = HttpLogHelper.GetTraceId(httpRequest);
            _formattedHttpRequest = await HttpLogHelper.GetFormattedHttpRequest(httpRequest);
        }


        public void AddHttpResponse(HttpResponse httpResponse)
        {
            _formattedHttpResponse = HttpLogHelper.GetFormattedHttpResponse(httpResponse);
        }

        
        public HttpContextLog GetHttpContextLogModel() => new HttpContextLog(_traceId, DateTime.UtcNow, _formattedHttpRequest, _formattedHttpResponse);


        private string _traceId;
        private FormattedHttpRequest _formattedHttpRequest;
        private FormattedHttpResponse _formattedHttpResponse;
    }
}
