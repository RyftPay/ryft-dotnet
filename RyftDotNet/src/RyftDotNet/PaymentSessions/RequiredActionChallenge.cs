using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions
{
    public sealed class RequiredActionChallenge : IEquatable<RequiredActionChallenge>
    {
        [property: JsonPropertyName("acsUrl")]
        public string AcsUrl { get; }

        [property: JsonPropertyName("cReq")]
        public string CReq { get; }

        public RequiredActionChallenge(string acsUrl, string cReq)
        {
            AcsUrl = acsUrl;
            CReq = cReq;
        }

        public bool Equals(RequiredActionChallenge? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || AcsUrl == other.AcsUrl
                   && CReq == other.CReq);

        public override bool Equals(object? obj)
            => obj is RequiredActionChallenge other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(AcsUrl, CReq).GetHashCode();
    }
}
