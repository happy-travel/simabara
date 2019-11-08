using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using StdOutLogger.Extensions;
using StdOutLogger.Options;

namespace StdOutLogger
{
    public class HttpContextLoggingMiddleware
    {
        public HttpContextLoggingMiddleware(RequestDelegate next, HttpContextLoggingMiddlewareOptions options)
        {
            _options = options;
            _next = next;
        }


        public async Task Invoke(HttpContext httpContext, IHttpContextLogger httpContextLogger, ILogger<HttpContextLoggingMiddleware> logger)
        {
            if (_options.IgnoredPaths.Contains(httpContext.Request.Path))
            {
                await _next(httpContext);
            }
            else
            {
                await httpContextLogger.AddHttpRequest(httpContext.Request);
                await _next(httpContext);
                httpContextLogger.AddHttpResponse(httpContext.Response);
                if (_options.LogInMiddleware)
                {
                    var httpContextLogModel = httpContextLogger.GetHttpContextLogModel();
                    logger.LogInformationToJson(default,string.Empty, httpContextLogModel);
                }
            }
        }


        private readonly RequestDelegate _next;
        private readonly HttpContextLoggingMiddlewareOptions _options;
    }
}