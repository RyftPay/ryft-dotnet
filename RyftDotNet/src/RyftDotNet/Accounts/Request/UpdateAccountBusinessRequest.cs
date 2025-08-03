using System.Collections.Generic;
using System.Text.Json.Serialization;
using RyftDotNet.Common;
using RyftDotNet.Common.Request;

namespace RyftDotNet.Accounts.Request
{
    public sealed class UpdateAccountBusinessRequest
    {
        [property: JsonPropertyName("name")]
        public string? Name { get; set; }

        [property: JsonPropertyName("type")]
        public BusinessType? Type { get; set; }

        [property: JsonPropertyName("registrationNumber")]
        public string? RegistrationNumber { get; set; }

        [property: JsonPropertyName("registeredAddress")]
        public AccountAddressRequest? RegisteredAddress { get; set; }

        [property: JsonPropertyName("contactEmail")]
        public string? ContactEmail { get; set; }

        [property: JsonPropertyName("registrationDate")]
        public DateOfEvent? RegistrationDate { get; set; }

        [property: JsonPropertyName("phoneNumber")]
        public string? PhoneNumber { get; set; }

        [property: JsonPropertyName("tradingName")]
        public string? TradingName { get; set; }

        [property: JsonPropertyName("tradingAddress")]
        public AccountAddressRequest? TradingAddress { get; set; }

        [property: JsonPropertyName("tradingCountries")]
        public IEnumerable<string>? TradingCountries { get; set; }

        [property: JsonPropertyName("websiteUrl")]
        public string? WebsiteUrl { get; set; }
    }
}
