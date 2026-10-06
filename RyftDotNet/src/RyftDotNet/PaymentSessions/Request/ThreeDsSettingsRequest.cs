using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions.Request
{
    public sealed class ThreeDsSettingsRequest
    {
        public ThreeDsSettingsRequest(string challengeIndicator)
        {
            ChallengeIndicator = challengeIndicator;
        }

        public ThreeDsSettingsRequest(string? challengeIndicator, string? policy)
        {
            ChallengeIndicator = challengeIndicator;
            Policy = policy;
        }

        [property: JsonPropertyName("challengeIndicator")]
        public string? ChallengeIndicator { get; set; }

        [property: JsonPropertyName("policy")]
        public string? Policy { get; set; }
    }
}
