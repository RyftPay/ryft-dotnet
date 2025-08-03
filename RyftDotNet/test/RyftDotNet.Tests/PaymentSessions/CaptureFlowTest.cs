using RyftDotNet.PaymentSessions;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.PaymentSessions
{
    public sealed class CaptureFlowTest
    {
        [Theory, MemberData(nameof(ExpectedValues))]
        public void StaticValues_ShouldReturnExpectedValue(CaptureFlow actual, CaptureFlow expected)
            => actual.ShouldBe(expected);

        public static TheoryData<CaptureFlow, CaptureFlow> ExpectedValues() =>
            new TheoryData<CaptureFlow, CaptureFlow>
            {
                { CaptureFlow.Manual, new CaptureFlow("Manual") },
                { CaptureFlow.Automatic, new CaptureFlow("Automatic") }
            };
    }
}
