using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using RyftDotNet.Common;
using RyftDotNet.Utility;

namespace RyftDotNet.Accounts
{
    public sealed class AccountBusiness : IEquatable<AccountBusiness>
    {
        [property: JsonPropertyName("name")]
        public string Name { get; }

        [property: JsonPropertyName("type")]
        public BusinessType Type { get; }

        [property: JsonPropertyName("registeredAddress")]
        public AccountAddress RegisteredAddress { get; }

        [property: JsonPropertyName("contactEmail")]
        public string ContactEmail { get; }

        [property: JsonPropertyName("registrationNumber")]
        public string? RegistrationNumber { get; }

        [property: JsonPropertyName("registrationDate")]
        public DateOfEvent? RegistrationDate { get; }

        [property: JsonPropertyName("phoneNumber")]
        public string? PhoneNumber { get; }

        [property: JsonPropertyName("tradingName")]
        public string? TradingName { get; }

        [property: JsonPropertyName("tradingAddress")]
        public AccountAddress? TradingAddress { get; }

        [property: JsonPropertyName("tradingCountries")]
        public IEnumerable<string>? TradingCountries { get; }

        [property: JsonPropertyName("websiteUrl")]
        public string? WebsiteUrl { get; }

        [property: JsonPropertyName("documents")]
        public IEnumerable<AccountDocument>? Documents { get; }

        public AccountBusiness(
            string name,
            BusinessType type,
            AccountAddress registeredAddress,
            string contactEmail,
            string? registrationNumber = null,
            DateOfEvent? registrationDate = null,
            string? phoneNumber = null,
            string? tradingName = null,
            AccountAddress? tradingAddress = null,
            IEnumerable<string>? tradingCountries = null,
            string? websiteUrl = null,
            IEnumerable<AccountDocument>? documents = null)
        {
            Name = name;
            Type = type;
            RegisteredAddress = registeredAddress;
            ContactEmail = contactEmail;
            RegistrationNumber = registrationNumber;
            RegistrationDate = registrationDate;
            PhoneNumber = phoneNumber;
            TradingName = tradingName;
            TradingAddress = tradingAddress;
            TradingCountries = tradingCountries;
            WebsiteUrl = websiteUrl;
            Documents = documents;
        }

        public bool Equals(AccountBusiness? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Name == other.Name
                   && Type == other.Type
                   && RegisteredAddress.Equals(other.RegisteredAddress)
                   && ContactEmail == other.ContactEmail
                   && RegistrationNumber == other.RegistrationNumber
                   && Equals(RegistrationDate, other.RegistrationDate)
                   && PhoneNumber == other.PhoneNumber
                   && TradingName == other.TradingName
                   && Equals(TradingAddress, other.TradingAddress)
                   && Utilities.SequenceEqual(TradingCountries, other.TradingCountries)
                   && WebsiteUrl == other.WebsiteUrl
                   && Utilities.SequenceEqual(Documents, other.Documents));

        public override bool Equals(object? obj)
            => obj is AccountBusiness other && Equals(other);

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Name);
            hashCode.Add(Type);
            hashCode.Add(RegisteredAddress);
            hashCode.Add(ContactEmail);
            hashCode.Add(RegistrationNumber);
            hashCode.Add(RegistrationDate);
            hashCode.Add(PhoneNumber);
            hashCode.Add(TradingName);
            hashCode.Add(TradingAddress);
            hashCode.Add(TradingCountries);
            hashCode.Add(WebsiteUrl);
            hashCode.Add(Documents);
            return hashCode.ToHashCode();
        }
    }
}
