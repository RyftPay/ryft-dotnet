using System.Text.Json.Serialization;

namespace RyftDotNet.PaymentSessions.Request
{
    public sealed class ThreeDsSettingsRequest
    {
        public ThreeDsSettingsRequest(string challengeIndicator)
        {
            ChallengeIndicator = challengeIndicator;
        }

        [property: JsonPropertyName("challengeIndicator")]
        public string ChallengeIndicator { get; set; }
    }
}
