using RyftDotNet.PaymentSessions.Request;
using RyftDotNet.Utility;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.PaymentSessions
{
    public sealed class ThreeDsSettingsRequestTest
    {
        [Fact]
        public void ToJson_ShouldOmitPolicy_WhenOnlyChallengeIndicatorProvided()
            => JsonUtility.Serialize(new ThreeDsSettingsRequest("NoPreference"))
                .ShouldBe("{\"challengeIndicator\":\"NoPreference\"}");

        [Fact]
        public void ToJson_ShouldOmitChallengeIndicator_WhenOnlyPolicyProvided()
            => JsonUtility.Serialize(new ThreeDsSettingsRequest(challengeIndicator: null, policy: "Required"))
                .ShouldBe("{\"policy\":\"Required\"}");

        [Fact]
        public void ToJson_ShouldIncludeBothFields_WhenBothProvided()
            => JsonUtility.Serialize(new ThreeDsSettingsRequest("ChallengeRequested", "Required"))
                .ShouldBe("{\"challengeIndicator\":\"ChallengeRequested\",\"policy\":\"Required\"}");
    }
}
