using System.Text.Json.Serialization;

namespace RyftDotNet.Disputes.Request
{
    public sealed class AddEvidenceRequest
    {
        [property: JsonPropertyName("text")]
        public DisputeEvidenceTextRequest? Text { get; set; }

        [property: JsonPropertyName("files")]
        public DisputeEvidenceFilesRequest? Files { get; set; }
    }
}
