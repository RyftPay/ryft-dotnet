using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.Common
{
    public sealed class PaymentMethodChecks : IEquatable<PaymentMethodChecks>
    {
        [property: JsonPropertyName("avsResponseCode")]
        public string? AvsResponseCode { get; }
        [property: JsonPropertyName("cvvResponseCode")]
        public string? CvvResponseCode { get; }

        public PaymentMethodChecks(
            string? avsResponseCode,
            string? cvvResponseCode)
        {
            AvsResponseCode = avsResponseCode;
            CvvResponseCode = cvvResponseCode;
        }

        public bool Equals(PaymentMethodChecks? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || AvsResponseCode == other.AvsResponseCode
                   && CvvResponseCode == other.CvvResponseCode);

        public override bool Equals(object? obj)
            => obj is PaymentMethodChecks other && Equals(other);

        public override int GetHashCode()
            => HashCode
                .Combine(AvsResponseCode, CvvResponseCode)
                .GetHashCode();
    }
}
