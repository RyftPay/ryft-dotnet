using RyftDotNet.PaymentSessions;
using RyftDotNet.Utility;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.PaymentSessions
{
    public sealed class PaymentSessionThreeDsSettingsTest
    {
        [Fact]
        public void FromJson_ShouldReturnExpectedValue_WhenOnlyPolicyReturned()
            => JsonUtility.Deserialize<PaymentSessionThreeDsSettings>("{\"policy\":\"Required\"}")
                .ShouldBe(new PaymentSessionThreeDsSettings(policy: "Required"));

        [Fact]
        public void FromJson_ShouldReturnExpectedValue_WhenOnlyChallengeIndicatorReturned()
            => JsonUtility.Deserialize<PaymentSessionThreeDsSettings>("{\"challengeIndicator\":\"NoPreference\"}")
                .ShouldBe(new PaymentSessionThreeDsSettings("NoPreference"));

        [Fact]
        public void Equals_ShouldReturnFalse_WhenPolicyDiffers()
            => new PaymentSessionThreeDsSettings("NoPreference", "Required")
                .ShouldNotBe(new PaymentSessionThreeDsSettings("NoPreference", "Default"));
    }
}
