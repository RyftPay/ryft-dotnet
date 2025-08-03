using System;
using System.Text.Json.Serialization;
using RyftDotNet.Common;

namespace RyftDotNet.PaymentSessions
{
    public sealed class PaymentSessionPaymentMethod : IEquatable<PaymentSessionPaymentMethod>
    {
        [property: JsonPropertyName("type")]
        public PaymentMethodType Type { get; }

        [property: JsonPropertyName("tokenizedDetails")]
        public PaymentMethodTokenizedDetails? TokenizedDetails { get; }

        [property: JsonPropertyName("card")]
        public PaymentSessionCard? Card { get; }

        [property: JsonPropertyName("wallet")]
        public PaymentSessionWallet? Wallet { get; }

        [property: JsonPropertyName("billingAddress")]
        public Address? BillingAddress { get; }

        [property: JsonPropertyName("checks")]
        public PaymentMethodChecks? Checks { get; }

        public PaymentSessionPaymentMethod(
            PaymentMethodType type,
            PaymentMethodTokenizedDetails? tokenizedDetails = null,
            PaymentSessionCard? card = null,
            PaymentSessionWallet? wallet = null,
            Address? billingAddress = null,
            PaymentMethodChecks? checks = null)
        {
            Type = type;
            TokenizedDetails = tokenizedDetails;
            Card = card;
            Wallet = wallet;
            BillingAddress = billingAddress;
            Checks = checks;
        }

        public bool Equals(PaymentSessionPaymentMethod? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Type == other.Type
                   && Equals(TokenizedDetails, other.TokenizedDetails)
                   && Equals(Card, other.Card)
                   && Equals(Wallet, other.Wallet)
                   && Equals(BillingAddress, other.BillingAddress)
                   && Equals(Checks, other.Checks));

        public override bool Equals(object? obj)
            => obj is PaymentSessionPaymentMethod other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(
                Type,
                TokenizedDetails,
                Card,
                Wallet,
                BillingAddress,
                Checks
            ).GetHashCode();
    }
}
