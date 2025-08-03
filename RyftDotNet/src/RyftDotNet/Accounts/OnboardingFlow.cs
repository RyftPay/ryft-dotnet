using RyftDotNet.Common;

namespace RyftDotNet.Accounts
{
    public sealed class OnboardingFlow : ConstantValue
    {
        public OnboardingFlow(string value) : base(value) { }

        public static readonly OnboardingFlow Hosted = new OnboardingFlow("Hosted");
        public static readonly OnboardingFlow NonHosted = new OnboardingFlow("NonHosted");
    }
}
