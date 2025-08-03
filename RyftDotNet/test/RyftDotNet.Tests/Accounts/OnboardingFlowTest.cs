using RyftDotNet.Accounts;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Accounts
{
    public sealed class OnboardingFlowTest
    {
        [Theory, MemberData(nameof(ExpectedValues))]
        public void StaticValues_ShouldReturnExpectedValue(OnboardingFlow actual, OnboardingFlow expected)
            => actual.ShouldBe(expected);

        public static TheoryData<OnboardingFlow, OnboardingFlow> ExpectedValues() =>
            new TheoryData<OnboardingFlow, OnboardingFlow>
            {
                { OnboardingFlow.Hosted, new OnboardingFlow("Hosted") },
                { OnboardingFlow.NonHosted, new OnboardingFlow("NonHosted") }
            };
    }
}
