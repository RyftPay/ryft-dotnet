using RyftDotNet.PaymentSessions;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.PaymentSessions
{
    public sealed class CaptureTypeTest
    {
        [Theory, MemberData(nameof(ExpectedValues))]
        public void StaticValues_ShouldReturnExpectedValue(CaptureType actual, CaptureType expected)
            => actual.ShouldBe(expected);

        public static TheoryData<CaptureType, CaptureType> ExpectedValues() =>
            new TheoryData<CaptureType, CaptureType>
            {
                { CaptureType.Final, new CaptureType("Final") },
                { CaptureType.NotFinal, new CaptureType("NotFinal") }
            };
    }
}
