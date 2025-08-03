using System;
using System.Text.Json.Serialization;

namespace RyftDotNet.Accounts
{
    public sealed class AccountCapabilities : IEquatable<AccountCapabilities>
    {
        [property: JsonPropertyName("visaPayments")]
        public AccountCapability VisaPayments { get; }

        [property: JsonPropertyName("mastercardPayments")]
        public AccountCapability MastercardPayments { get; }

        [property: JsonPropertyName("amexPayments")]
        public AccountCapability AmexPayments { get; }

        public AccountCapabilities(
            AccountCapability visaPayments,
            AccountCapability mastercardPayments,
            AccountCapability amexPayments)
        {
            VisaPayments = visaPayments;
            MastercardPayments = mastercardPayments;
            AmexPayments = amexPayments;
        }

        public bool Equals(AccountCapabilities? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || VisaPayments.Equals(other.VisaPayments)
                   && MastercardPayments.Equals(other.MastercardPayments)
                   && AmexPayments.Equals(other.AmexPayments));

        public override bool Equals(object? obj)
            => obj is AccountCapabilities other && Equals(other);

        public override int GetHashCode()
            => HashCode
                .Combine(VisaPayments, MastercardPayments, AmexPayments)
                .GetHashCode();
    }
}
