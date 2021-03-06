namespace HappyTravel.Simabara.Model
{
    public readonly struct PaymentLinkData
    {
        public PaymentLinkData(decimal amount, string email, string serviceType, 
            string currency, string comment)
        {
            Amount = amount;
            Email = email;
            ServiceType = serviceType;
            Currency = currency;
            Comment = comment;
        }

        public decimal Amount { get; }
        public string Email { get; }
        public string ServiceType { get; }
        public string Currency { get; }
        public string Comment { get; }
    }
}