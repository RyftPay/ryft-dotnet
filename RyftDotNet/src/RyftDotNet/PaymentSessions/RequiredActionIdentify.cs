using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions
{
    public sealed class RequiredActionIdentify : IEquatable<RequiredActionIdentify>
    {
        [property: JsonPropertyName("threeDsMethodUrl")]
        public string? ThreeDsMethodUrl { get; }

        [property: JsonPropertyName("threeDsMethodData")]
        public string? ThreeDsMethodData { get; }

        [property: JsonPropertyName("sessionId")]
        public string? SessionId { get; }

        [property: JsonPropertyName("sessionSecret")]
        public string? SessionSecret { get; }

        [property: JsonPropertyName("scheme")]
        public string? Scheme { get; }

        [property: JsonPropertyName("paymentMethodId")]
        public string? PaymentMethodId { get; }

        public RequiredActionIdentify(
            string? threeDsMethodUrl = null,
            string? threeDsMethodData = null,
            string? sessionId = null,
            string? sessionSecret = null,
            string? scheme = null,
            string? paymentMethodId = null)
        {
            ThreeDsMethodUrl = threeDsMethodUrl;
            ThreeDsMethodData = threeDsMethodData;
            SessionId = sessionId;
            SessionSecret = sessionSecret;
            Scheme = scheme;
            PaymentMethodId = paymentMethodId;
        }

        public bool Equals(RequiredActionIdentify? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || ThreeDsMethodUrl == other.ThreeDsMethodUrl
                   && ThreeDsMethodData == other.ThreeDsMethodData
                   && SessionId == other.SessionId
                   && SessionSecret == other.SessionSecret
                   && Scheme == other.Scheme
                   && PaymentMethodId == other.PaymentMethodId);

        public override bool Equals(object? obj)
            => obj is RequiredActionIdentify other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(
                ThreeDsMethodUrl,
                ThreeDsMethodData,
                SessionId,
                SessionSecret,
                Scheme,
                PaymentMethodId
            ).GetHashCode();
    }
}
