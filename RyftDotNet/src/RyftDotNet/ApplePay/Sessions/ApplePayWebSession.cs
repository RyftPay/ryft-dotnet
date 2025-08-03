using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.ApplePay.Sessions
{
    public sealed class ApplePayWebSession : IEquatable<ApplePayWebSession>
    {
        [property: JsonPropertyName("sessionObject")]
        public string SessionObject { get; }

        public ApplePayWebSession(string sessionObject)
        {
            SessionObject = sessionObject;
        }

        public bool Equals(ApplePayWebSession? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || SessionObject == other.SessionObject);

        public override bool Equals(object? obj)
            => obj is ApplePayWebSession other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(SessionObject).GetHashCode();
    }
}
