using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.Payouts
{
    public sealed class PayoutPayoutMethod : IEquatable<PayoutPayoutMethod>
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        [property: JsonPropertyName("bankAccount")]
        public PayoutBankAccount BankAccount { get; }

        public PayoutPayoutMethod(string id, PayoutBankAccount bankAccount)
        {
            Id = id;
            BankAccount = bankAccount;
        }

        public bool Equals(PayoutPayoutMethod? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Id == other.Id &&
                   BankAccount.Equals(other.BankAccount));

        public override bool Equals(object? obj)
            => obj is PayoutPayoutMethod other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Id, BankAccount);
    }
}
