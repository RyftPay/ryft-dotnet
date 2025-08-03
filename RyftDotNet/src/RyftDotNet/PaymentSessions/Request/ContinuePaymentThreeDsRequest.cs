using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions.Request
{
    public sealed class ContinuePaymentThreeDsRequest
    {
        [property: JsonPropertyName("fingerprint")]
        public string? Fingerprint { get; set; }

        [property: JsonPropertyName("challengeResult")]
        public string? ChallengeResult { get; set; }
    }
}
