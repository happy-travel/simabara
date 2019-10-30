namespace HT.LinkGenerator.Model
{
    public struct SendPaymentLinkRequest
    {
        public SendPaymentLinkRequest(string email, PaymentLinkData paymentData)
        {
            Email = email;
            PaymentData = paymentData;
        }

        public string Email { get; }
        public PaymentLinkData PaymentData { get; }
    }
}