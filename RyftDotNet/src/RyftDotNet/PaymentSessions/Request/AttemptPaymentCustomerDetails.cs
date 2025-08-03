using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions.Request
{
    public sealed class AttemptPaymentCustomerDetails
    {
        [property: JsonPropertyName("email")]
        public string Email { get; }

        [property: JsonPropertyName("homePhoneNumber")]
        public string? HomePhoneNumber { get; set; }

        [property: JsonPropertyName("mobilePhoneNumber")]
        public string? MobilePhoneNumber { get; set; }

        public AttemptPaymentCustomerDetails(
            string email)
        {
            Email = email;
        }
    }
}
