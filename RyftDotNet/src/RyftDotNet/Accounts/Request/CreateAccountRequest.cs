using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RyftDotNet.Accounts.Request
{
    public sealed class CreateAccountRequest
    {
        [property: JsonPropertyName("onboardingFlow")]
        public OnboardingFlow? OnboardingFlow { get; set; }

        [property: JsonPropertyName("email")]
        public string? Email { get; set; }

        [property: JsonPropertyName("entityType")]
        public EntityType? EntityType { get; set; }

        [property: JsonPropertyName("business")]
        public CreateAccountBusinessRequest? Business { get; set; }

        [property: JsonPropertyName("individual")]
        public CreateAccountIndividualRequest? Individual { get; set; }

        [property: JsonPropertyName("metadata")]
        public IDictionary<string, string>? Metadata { get; set; }

        [property: JsonPropertyName("settings")]
        public AccountSettingsRequest? Settings { get; set; }

        [property: JsonPropertyName("termsOfService")]
        public TermsOfServiceRequest? TermsOfService { get; set; }
    }
}
