using System.Collections.Concurrent;
using HT.StdOutLogger.Internals;
using HT.StdOutLogger.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HT.StdOutLogger
{
    public class StdOutLoggerProvider : ILoggerProvider, ISupportExternalScope
    {
        public StdOutLoggerProvider(IOptions<StdOutLoggerOptions> options)
        {
            _options = options.Value;
            _loggers = new ConcurrentDictionary<string, global::HT.StdOutLogger.Internals.StdOutLogger>();
            _loggerProcessor = new LoggerProcessor();
        }


        public ILogger CreateLogger(string name)
        {
            return _loggers.GetOrAdd(name, loggerName => new global::HT.StdOutLogger.Internals.StdOutLogger(name, _loggerProcessor)
            {
                Options = _options,
                ScopeProvider = _scopeProvider
            });
        }


        public void SetScopeProvider(IExternalScopeProvider scopeProvider)
        {
            _scopeProvider = scopeProvider;

            foreach (var logger in _loggers)
                logger.Value.ScopeProvider = _scopeProvider;
        }


        public void Dispose()
        {
            _loggerProcessor.Dispose();
        }


        private readonly StdOutLoggerOptions _options;
        private readonly LoggerProcessor _loggerProcessor;
        private IExternalScopeProvider _scopeProvider = NullExternalScopeProvider.Instance;
        private readonly ConcurrentDictionary<string, global::HT.StdOutLogger.Internals.StdOutLogger> _loggers;
    }
}