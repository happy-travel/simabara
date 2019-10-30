using System;
using Newtonsoft.Json;

namespace HT.LinkGenerator.Model
{
    /// <summary>
    /// This struct is needed to deserialize version correctly, because JSON .NET cannot deserialize string to Version
    /// https://github.com/bridgedotnet/Bridge.Newtonsoft.Json/issues/126
    /// </summary>
    public readonly struct DeserializableVersion 
    {
        private readonly int _major;
        private readonly int _minor;

        [JsonConstructor]
        public DeserializableVersion(int major, int minor)
        {
            _major = major;
            _minor = minor;
        }
        
        public Version Version => new Version(_major, _minor);
    }
}