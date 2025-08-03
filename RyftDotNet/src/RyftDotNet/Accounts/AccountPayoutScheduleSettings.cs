using System;
using System.Text.Json.Serialization;
using RyftDotNet.Common;

namespace RyftDotNet.Accounts
{
    public sealed class AccountPayoutScheduleSettings : IEquatable<AccountPayoutScheduleSettings>
    {
        [property: JsonPropertyName("type")]
        public PayoutScheduleType Type { get; }

        public AccountPayoutScheduleSettings(PayoutScheduleType type)
        {
            Type = type;
        }

        public bool Equals(AccountPayoutScheduleSettings? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Type == other.Type);

        public override bool Equals(object? obj)
            => obj is AccountPayoutScheduleSettings other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Type).GetHashCode();
    }
}
