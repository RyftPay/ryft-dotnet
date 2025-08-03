using System;
using System.Text.Json.Serialization;
using RyftDotNet.PayoutMethods;

namespace RyftDotNet.Payouts
{
    public sealed class PayoutBankAccount : IEquatable<PayoutBankAccount>
    {
        [property: JsonPropertyName("accountNumberType")]
        public AccountNumberType AccountNumberType { get; }

        [property: JsonPropertyName("last4")]
        public string? Last4 { get; }

        [property: JsonPropertyName("bankIdType")]
        public BankIdType? BankIdType { get; }

        [property: JsonPropertyName("bankId")]
        public string? BankId { get; }

        [property: JsonPropertyName("bankName")]
        public string? BankName { get; }

        public PayoutBankAccount(
            AccountNumberType accountNumberType,
            string last4,
            BankIdType? bankIdType = null,
            string? bankId = null,
            string? bankName = null)
        {
            AccountNumberType = accountNumberType;
            Last4 = last4;
            BankIdType = bankIdType;
            BankId = bankId;
            BankName = bankName;
        }

        public bool Equals(PayoutBankAccount? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || AccountNumberType == other.AccountNumberType
                   && Last4 == other.Last4
                   && BankIdType == other.BankIdType
                   && BankId == other.BankId
                   && BankName == other.BankName);

        public override bool Equals(object? obj)
            => obj is PayoutBankAccount other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(
                AccountNumberType,
                Last4,
                BankIdType,
                BankId,
                BankName
            );
    }
}
