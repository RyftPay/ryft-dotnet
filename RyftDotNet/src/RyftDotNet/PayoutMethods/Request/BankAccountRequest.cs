using System.Text.Json.Serialization;
using RyftDotNet.Common;

namespace RyftDotNet.PayoutMethods.Request
{
    public sealed class BankAccountRequest
    {
        [property: JsonPropertyName("accountNumberType")]
        public AccountNumberType AccountNumberType { get; }

        [property: JsonPropertyName("accountNumber")]
        public string AccountNumber { get; }

        [property: JsonPropertyName("bankIdType")]
        public BankIdType? BankIdType { get; set; }

        [property: JsonPropertyName("bankId")]
        public string? BankId { get; set; }

        [property: JsonPropertyName("address")]
        public AccountAddress? Address { get; set; }

        public BankAccountRequest(
            AccountNumberType accountNumberType,
            string accountNumber)
        {
            AccountNumberType = accountNumberType;
            AccountNumber = accountNumber;
        }
    }
}
