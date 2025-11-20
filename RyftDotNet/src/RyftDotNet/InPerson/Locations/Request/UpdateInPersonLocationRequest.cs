using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RyftDotNet.InPerson.Locations.Request
{
    public sealed class UpdateInPersonLocationRequest
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("metadata")]
        public IDictionary<string, string>? Metadata { get; set; }
    }
}
