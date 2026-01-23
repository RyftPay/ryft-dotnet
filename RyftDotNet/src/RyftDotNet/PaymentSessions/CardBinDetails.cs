using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions
{
    public class CardBinDetails : IEquatable<CardBinDetails>
    {
        [property: JsonPropertyName("issuer")]
        public string? Issuer { get; }

        [property: JsonPropertyName("issuerCountry")]
        public string? IssuerCountry { get; }

        [property: JsonPropertyName("fundingType")]
        public CardFundingType? FundingType { get; }

        [property: JsonPropertyName("productType")]
        public CardProductType? ProductType { get; }

        public CardBinDetails(string? issuer, string? issuerCountry, CardFundingType? fundingType, CardProductType? productType)
        {
            Issuer = issuer;
            IssuerCountry = issuerCountry;
            FundingType = fundingType;
            ProductType = productType;
        }

        public bool Equals(CardBinDetails? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Issuer == other.Issuer
                   && IssuerCountry == other.IssuerCountry
                   && FundingType == other.FundingType
                   && ProductType == other.ProductType);

        public override bool Equals(object? obj)
            => ReferenceEquals(this, obj) || obj is CardBinDetails other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(Issuer, IssuerCountry, FundingType, ProductType);
    }
}
