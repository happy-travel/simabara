using System.Collections.Generic;

namespace HT.StdOutLogger.Options
{
    public class HttpContextLoggingMiddlewareOptions
    {
        public List<string> IgnoredPaths { get; set; } = new List<string> {"/health"};
        public bool LogInMiddleware { get; set; } = false;
    }
}
