using System.Collections.Generic;

namespace HT.LinkGenerator.Model
{
    public class PaymentLinkSettings
    {
        public List<string> Currencies { get; set; }
        public List<string> Facilities { get; set; }
        public string DefaultCurrency { get; set; }
        public string DefaultFacility { get; set; }
    }
}