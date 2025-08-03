using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.Accounts
{
    public sealed class AccountVerificationRequiredPerson : IEquatable<AccountVerificationRequiredPerson>
    {
        [property: JsonPropertyName("role")]
        public string Role { get; }

        [property: JsonPropertyName("quantity")]
        public int Quantity { get; }

        public AccountVerificationRequiredPerson(string role, int quantity)
        {
            Role = role;
            Quantity = quantity;
        }

        public bool Equals(AccountVerificationRequiredPerson? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Role == other.Role
                   && Quantity == other.Quantity);

        public override bool Equals(object? obj)
            => obj is AccountVerificationRequiredPerson other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Role, Quantity).GetHashCode();
    }
}
