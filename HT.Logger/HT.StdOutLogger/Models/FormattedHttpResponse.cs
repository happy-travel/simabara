using System.Collections.Generic;

namespace StdOutLogger.Models
{
    public readonly struct FormattedHttpResponse
    {
        public FormattedHttpResponse(int statusCode, List<string> headers)
        {
            StatusCode = statusCode;
            Headers = headers;
        }
        

        public int StatusCode { get; }
        public List<string> Headers { get; }

    }
}
