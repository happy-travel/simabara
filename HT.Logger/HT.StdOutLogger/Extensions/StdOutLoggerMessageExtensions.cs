using Microsoft.Extensions.Logging;
using StdOutLogger.Models;

namespace StdOutLogger.Extensions
{
    public static class StdOutLoggerMessageExtensions
    {
        public static void LogInformationToJson(this ILogger logger, EventId eventId, string message, HttpContextLog httpContextContextLog)
        {
            logger.Log(LogLevel.Information,
                eventId,
                new{ TraceId = httpContextContextLog.TraceId, HttpContext = httpContextContextLog, Message = message },
                null,
                (state, ex) => string.Empty);
        }
    }
}
