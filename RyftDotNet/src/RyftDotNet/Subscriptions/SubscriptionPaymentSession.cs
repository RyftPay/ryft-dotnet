using System;
using System.Text.Json.Serialization;
using RyftDotNet.PaymentSessions;

namespace RyftDotNet.Subscriptions
{
    public sealed class SubscriptionPaymentSession : IEquatable<SubscriptionPaymentSession>
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        [property: JsonPropertyName("clientSecret")]
        public string? ClientSecret { get; }

        [property: JsonPropertyName("requiredAction")]
        public PaymentSessionRequiredAction? RequiredAction { get; }

        public SubscriptionPaymentSession(
            string id,
            string? clientSecret = null,
            PaymentSessionRequiredAction? requiredAction = null)
        {
            Id = id;
            ClientSecret = clientSecret;
            RequiredAction = requiredAction;
        }

        public bool Equals(SubscriptionPaymentSession? other)
            => !ReferenceEquals(null, other)
               && (ReferenceEquals(this, other)
                   || Id == other.Id
                   && ClientSecret == other.ClientSecret
                   && Equals(RequiredAction, other.RequiredAction));

        public override bool Equals(object? obj)
            => obj is SubscriptionPaymentSession other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(Id, ClientSecret, RequiredAction);
    }
}
