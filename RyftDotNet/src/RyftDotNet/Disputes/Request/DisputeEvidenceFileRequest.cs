using System.Text.Json.Serialization;

namespace RyftDotNet.Disputes.Request
{
    public sealed class DisputeEvidenceFileRequest
    {
        [property: JsonPropertyName("id")]
        public string Id { get; }

        public DisputeEvidenceFileRequest(string id)
        {
            Id = id;
        }
    }
}
