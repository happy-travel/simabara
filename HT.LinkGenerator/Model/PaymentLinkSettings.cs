using System.Collections.Generic;

namespace HT.LinkGenerator.Model
{
    public class PaymentLinkSettings
    {
        public List<string> Currencies { get; set; }
        
        /// <summary>
        /// Key is service type code and Value is service type description. 
        /// </summary>
        public Dictionary<string, string> ServiceTypes { get; set; }
    }
}