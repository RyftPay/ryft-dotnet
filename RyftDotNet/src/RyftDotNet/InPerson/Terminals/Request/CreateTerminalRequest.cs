using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RyftDotNet.InPerson.Terminals.Request
{
    public sealed class CreateTerminalRequest
    {
        [JsonPropertyName("serialNumber")]
        public string SerialNumber { get; }

        [JsonPropertyName("locationId")]
        public string LocationId { get; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("metadata")]
        public IDictionary<string, string>? Metadata { get; set; }

        public CreateTerminalRequest(string serialNumber, string locationId)
        {
            SerialNumber = serialNumber;
            LocationId = locationId;
        }
    }
}
