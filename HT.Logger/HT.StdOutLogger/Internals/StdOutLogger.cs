﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StdOutLogger.Options;

namespace StdOutLogger.Internals
{
    internal class StdOutLogger : ILogger
    {
        public StdOutLogger(string name, LoggerProcessor loggerProcessor)
        {
            _name = name;
            _loggerProcessor = loggerProcessor;
        }


        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
                return;

            var messageBuilder = new StringBuilder(formatter != null ? formatter(state, exception) : string.Empty);
            

            var parameters = GetParameters(state);
             
            var jObject = JObject.FromObject(new
            {
                LogName = _name,
                CreatedAt = Options.UseUtcTimestamp ? DateTime.UtcNow : DateTime.Now,
                LogLevel = logLevel,
                EventId = eventId,
                Parameters = parameters,
                Message = messageBuilder.ToString(),
                Exception = exception?.ToString(),
                Scopes = GetScopeData()
            }, JsonSerializer.Create(Options.JsonSerializerSettings));
            

            _loggerProcessor.Log(jObject.ToString(Formatting.None));
        }


        private object GetParameters<TState>(TState state)
        {
            if (state is IEnumerable<KeyValuePair<string, object>> parameters)
                return parameters.Where(p => !Options.SkippedJsonParameters.Contains(p.Key)).ToDictionary(i => i.Key, i => i.Value);
            return state;
        }


        private JArray GetScopeData()
        {
            JArray jArray = null;
            var scopedProvider = ScopeProvider;
            if (Options.IncludeScopes)
            {
                jArray = new JArray();
                scopedProvider?.ForEachScope((scope, array) =>
                {
                    var jScope = JToken.FromObject(scope);
                    if (jScope is JArray)
                        array.AddFirst(jScope.ToObject<List<object>>());
                    else if (jScope is JObject)
                        array.AddFirst(jScope.ToObject<object>());


                }, jArray);
            }
            return jArray;
        }
        

        private void GetScopeMessage(StringBuilder stringBuilder)
        {
            var scopedProvider = ScopeProvider;
            if (Options.IncludeScopes)
                scopedProvider?.ForEachScope((scope, builder) =>
                {
                    builder.Append("=> ");
                    builder.Append(scope);
                }, stringBuilder);
        }


        public bool IsEnabled(LogLevel logLevel) => logLevel != LogLevel.None;


        public IDisposable BeginScope<TState>(TState state) => ScopeProvider?.Push(state) ?? NullScope.Instance;


        public StdOutLoggerOptions Options
        {
            get => _options;
            set
            {
                _options = value;
                _options.JsonSerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            }
        }

        internal IExternalScopeProvider ScopeProvider { get; set; }
        private readonly string _name;
        private readonly LoggerProcessor _loggerProcessor;
        private StdOutLoggerOptions _options;
    }
}