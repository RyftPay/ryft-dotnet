using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.Accounts
{
    public sealed class AccountPayoutSettings : IEquatable<AccountPayoutSettings>
    {
        [property: JsonPropertyName("schedule")]
        public AccountPayoutScheduleSettings Schedule { get; }

        public AccountPayoutSettings(AccountPayoutScheduleSettings schedule)
        {
            Schedule = schedule;
        }

        public bool Equals(AccountPayoutSettings? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Schedule.Equals(other.Schedule));

        public override bool Equals(object? obj)
            => obj is AccountPayoutSettings other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Schedule).GetHashCode();
    }
}
