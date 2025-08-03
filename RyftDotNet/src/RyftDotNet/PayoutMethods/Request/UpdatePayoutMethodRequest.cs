using System.Text.Json.Serialization;

namespace RyftDotNet.PayoutMethods.Request
{
    public sealed class UpdatePayoutMethodRequest
    {
        [property: JsonPropertyName("bankAccount")]
        public BankAccountRequest? BankAccount { get; set; }

        [property: JsonPropertyName("displayName")]
        public string? DisplayName { get; set; }
    }
}
