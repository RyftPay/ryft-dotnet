using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.Accounts
{
    public sealed class AccountSettings : IEquatable<AccountSettings>
    {
        [property: JsonPropertyName("payouts")]
        public AccountPayoutSettings Payouts { get; }

        public AccountSettings(AccountPayoutSettings payouts)
        {
            Payouts = payouts;
        }

        public bool Equals(AccountSettings? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Equals(Payouts, other.Payouts));

        public override bool Equals(object? obj)
            => obj is AccountSettings other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Payouts).GetHashCode();
    }
}
