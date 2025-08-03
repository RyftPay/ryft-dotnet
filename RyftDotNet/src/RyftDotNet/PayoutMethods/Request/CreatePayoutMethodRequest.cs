using System.Text.Json.Serialization;

namespace RyftDotNet.PayoutMethods.Request
{
    public sealed class CreatePayoutMethodRequest
    {
        [property: JsonPropertyName("type")]
        public PayoutMethodType Type { get; }

        [property: JsonPropertyName("country")]
        public string Country { get; }

        [property: JsonPropertyName("currency")]
        public string Currency { get; }

        [property: JsonPropertyName("bankAccount")]
        public BankAccountRequest BankAccount { get; }

        [property: JsonPropertyName("displayName")]
        public string? DisplayName { get; set; }

        public CreatePayoutMethodRequest(
            PayoutMethodType type,
            string country,
            string currency,
            BankAccountRequest bankAccount)
        {
            Type = type;
            Country = country;
            Currency = currency;
            BankAccount = bankAccount;
        }
    }
}
