using System;

namespace HT.LinkGenerator.Infrastructure
{
    public class UrlHelper
    {
        public static string CombineUri(string baseUri, string relativeUri) {
            return new Uri(new Uri(baseUri), relativeUri).ToString();
        }
    }
}