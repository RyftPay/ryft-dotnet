using System;
using System.Text.Json.Serialization;
using RyftDotNet.Common;

namespace RyftDotNet.PayoutMethods
{
    public sealed class PayoutMethodBankAccount : IEquatable<PayoutMethodBankAccount>
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

        [property: JsonPropertyName("address")]
        public AccountAddress? Address { get; }

        public PayoutMethodBankAccount(
            AccountNumberType accountNumberType,
            string last4,
            BankIdType? bankIdType = null,
            string? bankId = null,
            string? bankName = null,
            AccountAddress? address = null)
        {
            AccountNumberType = accountNumberType;
            Last4 = last4;
            BankIdType = bankIdType;
            BankId = bankId;
            BankName = bankName;
            Address = address;
        }

        public bool Equals(PayoutMethodBankAccount? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || AccountNumberType == other.AccountNumberType
                   && Last4 == other.Last4
                   && BankIdType == other.BankIdType
                   && BankId == other.BankId
                   && BankName == other.BankName
                   && Equals(Address, other.Address));

        public override bool Equals(object? obj)
            => obj is PayoutMethodBankAccount other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(
                AccountNumberType,
                Last4,
                BankIdType,
                BankId,
                BankName,
                Address
            );
    }
}
