using System.Collections.Generic;
using System.Text.Json.Serialization;
using RyftDotNet.Common;
using RyftDotNet.Common.Request;

namespace RyftDotNet.Accounts.Request
{
    public sealed class CreateAccountBusinessRequest
    {
        [property: JsonPropertyName("name")]
        public string Name { get; }

        [property: JsonPropertyName("type")]
        public BusinessType Type { get; }

        [property: JsonPropertyName("registrationNumber")]
        public string RegistrationNumber { get; set; }

        [property: JsonPropertyName("registeredAddress")]
        public AccountAddressRequest RegisteredAddress { get; }

        [property: JsonPropertyName("contactEmail")]
        public string ContactEmail { get; }

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

        public CreateAccountBusinessRequest(
            string name,
            BusinessType type,
            string registrationNumber,
            AccountAddressRequest registeredAddress,
            string contactEmail)
        {
            Name = name;
            Type = type;
            RegistrationNumber = registrationNumber;
            RegisteredAddress = registeredAddress;
            ContactEmail = contactEmail;
        }
    }
}
