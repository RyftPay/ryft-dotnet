using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.Accounts
{
    public sealed class AccountTermsOfService : IEquatable<AccountTermsOfService>
    {
        [property: JsonPropertyName("acceptance")]
        public AccountTermsOfServiceAcceptance Acceptance { get; }

        public AccountTermsOfService(AccountTermsOfServiceAcceptance acceptance)
        {
            Acceptance = acceptance;
        }

        public bool Equals(AccountTermsOfService? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Equals(Acceptance, other.Acceptance));

        public override bool Equals(object? obj)
            => obj is AccountTermsOfService other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Acceptance).GetHashCode();
    }
}
