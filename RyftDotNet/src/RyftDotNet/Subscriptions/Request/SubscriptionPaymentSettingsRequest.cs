using System.Text.Json.Serialization;

namespace RyftDotNet.Subscriptions.Request
{
    public sealed class SubscriptionPaymentSettingsRequest
    {
        [property: JsonPropertyName("statementDescriptor")]
        public SubscriptionStatementDescriptorRequest? StatementDescriptor { get; set; }
    }
}
