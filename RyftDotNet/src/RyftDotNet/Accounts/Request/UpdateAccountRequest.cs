using System.Collections.Generic;
using System.Text.Json.Serialization;
using RyftDotNet.Common.Request;

namespace RyftDotNet.Accounts.Request
{
    public sealed class UpdateAccountRequest
    {
        [property: JsonPropertyName("entityType")]
        public EntityType? EntityType { get; set; }

        [property: JsonPropertyName("business")]
        public UpdateAccountBusinessRequest? Business { get; set; }

        [property: JsonPropertyName("individual")]
        public UpdateAccountIndividualRequest? Individual { get; set; }

        [property: JsonPropertyName("metadata")]
        public IDictionary<string, string>? Metadata { get; set; }

        [property: JsonPropertyName("settings")]
        public AccountSettingsRequest? Settings { get; set; }

        [property: JsonPropertyName("termsOfService")]
        public TermsOfServiceRequest? TermsOfService { get; set; }

        [property: JsonPropertyName("capabilities")]
        public AccountCapabilitiesRequest? Capabilities { get; set; }

        [property: JsonPropertyName("documents")]
        public IEnumerable<AccountDocumentRequest>? Documents { get; set; }
    }
}
