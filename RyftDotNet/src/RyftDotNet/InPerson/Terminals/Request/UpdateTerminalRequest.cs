using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RyftDotNet.InPerson.Terminals.Request
{
    public sealed class UpdateTerminalRequest
    {
        [JsonPropertyName("locationId")]
        public string? LocationId { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("metadata")]
        public IDictionary<string, string>? Metadata { get; set; }
    }
}