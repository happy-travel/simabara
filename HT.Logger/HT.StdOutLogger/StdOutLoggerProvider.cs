using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StdOutLogger.Internals;
using StdOutLogger.Options;

namespace StdOutLogger
{
    public class StdOutLoggerProvider : ILoggerProvider, ISupportExternalScope
    {
        public StdOutLoggerProvider(IOptions<StdOutLoggerOptions> options)
        {
            _options = options.Value;
            _loggers = new ConcurrentDictionary<string, Internals.StdOutLogger>();
            _loggerProcessor = new LoggerProcessor();
        }


        public ILogger CreateLogger(string name)
        {
            return _loggers.GetOrAdd(name, loggerName => new Internals.StdOutLogger(name, _loggerProcessor)
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
        private readonly ConcurrentDictionary<string, Internals.StdOutLogger> _loggers;
    }
}