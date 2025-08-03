using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RyftDotNet.Disputes.Request
{
    public sealed class RemoveEvidenceRequest
    {
        [property: JsonPropertyName("text")]
        public IEnumerable<DisputeEvidenceTextIdentifier>? Text { get; set; }

        [property: JsonPropertyName("files")]
        public IEnumerable<DisputeEvidenceFileIdentifier>? Files { get; set; }
    }
}
