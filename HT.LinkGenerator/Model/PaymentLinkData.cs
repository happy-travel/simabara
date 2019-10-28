namespace HT.LinkGenerator.Model
{
    public readonly struct PaymentLinkData
    {
        public PaymentLinkData(decimal price, string facility, Currencies currency, string comment)
        {
            Price = price;
            Facility = facility;
            Currency = currency;
            Comment = comment;
        }

        public decimal Price { get; }
        public string Facility { get; }
        public Currencies Currency { get; }
        public string Comment { get; }
    }
}