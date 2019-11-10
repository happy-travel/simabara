using System;

namespace HT.LinkGenerator.Infrastructure
{
    public static class UrlHelper
    {
        private const string UrlPathSeparator = "/";
        public static string CombineUri(string baseUri, string relativeUri) {
            if (baseUri.EndsWith(UrlPathSeparator, StringComparison.OrdinalIgnoreCase))
                baseUri = baseUri.Substring(0, baseUri.Length - 1);

            if (relativeUri.StartsWith(UrlPathSeparator))
                relativeUri = relativeUri.Substring(1, relativeUri.Length - 1);
                
            return $"{baseUri}/{relativeUri}";
        }
    }
}