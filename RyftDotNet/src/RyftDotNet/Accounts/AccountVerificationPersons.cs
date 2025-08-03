using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using RyftDotNet.Utility;

namespace RyftDotNet.Accounts
{
    public sealed class AccountVerificationPersons : IEquatable<AccountVerificationPersons>
    {
        [property: JsonPropertyName("status")]
        public string Status { get; }

        [property: JsonPropertyName("required")]
        public IEnumerable<AccountVerificationRequiredPerson>? Required { get; }

        public AccountVerificationPersons(
            string status,
            IEnumerable<AccountVerificationRequiredPerson>? required = null)
        {
            Status = status;
            Required = required;
        }

        public bool Equals(AccountVerificationPersons? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Status == other.Status
                   && Utilities.SequenceEqual(Required, other.Required));

        public override bool Equals(object? obj)
            => obj is AccountVerificationPersons other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Status, Required).GetHashCode();
    }
}
