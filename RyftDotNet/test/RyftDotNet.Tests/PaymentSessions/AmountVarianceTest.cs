using RyftDotNet.PaymentSessions;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.PaymentSessions
{
    public sealed class AmountVarianceTest
    {
        [Theory, MemberData(nameof(ExpectedValues))]
        public void StaticValues_ShouldReturnExpectedValue(AmountVariance actual, AmountVariance expected)
            => actual.ShouldBe(expected);

        public static TheoryData<AmountVariance, AmountVariance> ExpectedValues() =>
            new TheoryData<AmountVariance, AmountVariance>
            {
                { AmountVariance.Fixed, new AmountVariance("Fixed") },
                { AmountVariance.Variable, new AmountVariance("Variable") }
            };
    }
}
