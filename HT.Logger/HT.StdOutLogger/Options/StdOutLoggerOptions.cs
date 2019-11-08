using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace HT.StdOutLogger.Options
{
    public class StdOutLoggerOptions
    {
        public bool UseUtcTimestamp { get; set; } = true;
        public bool IncludeScopes { get; set; } = false;

        public JsonSerializerSettings JsonSerializerSettings { get; set; } = new JsonSerializerSettings
        {
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate,
            Converters = new List<JsonConverter>
                {new StringEnumConverter {NamingStrategy = new CamelCaseNamingStrategy()}},
            MaxDepth = 3
        };

        public List<string> SkippedJsonParameters { get; set; } = new List<string> {"MethodInfo", "{OriginalFormat}"};
    }
}