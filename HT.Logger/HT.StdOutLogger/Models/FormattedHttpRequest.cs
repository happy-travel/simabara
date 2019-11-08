using System.Collections.Generic;

namespace StdOutLogger.Models
{
    public readonly struct FormattedHttpRequest
    {
        public FormattedHttpRequest(string traceIdentifier, string method, string host, string path, List<string> headers, string requestBody)
        {
            TraceIdentifier = traceIdentifier;
            Method = method;
            Host = host;
            Path = path;
            Headers = headers;
            RequestBody = requestBody;
        }


        public string TraceIdentifier { get; }
        public string Host { get; }
        public string Method { get; }
        public string Path { get; }
        public List<string> Headers { get; }
        public string RequestBody { get; }
    }
}
