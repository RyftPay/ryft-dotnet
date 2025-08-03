using RyftDotNet.Payouts;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Payouts
{
    public sealed class PayoutSchemeTest
    {
        [Theory, MemberData(nameof(ExpectedValues))]
        public void StaticValues_ShouldReturnExpectedValue(PayoutScheme actual, PayoutScheme expected)
            => actual.ShouldBe(expected);

        public static TheoryData<PayoutScheme, PayoutScheme> ExpectedValues() =>
            new TheoryData<PayoutScheme, PayoutScheme>
            {
                { PayoutScheme.Ach, new PayoutScheme("Ach") },
                { PayoutScheme.Bacs, new PayoutScheme("Bacs") },
                { PayoutScheme.Chaps, new PayoutScheme("Chaps") },
                { PayoutScheme.Fps, new PayoutScheme("Fps") },
                { PayoutScheme.Swift, new PayoutScheme("Swift") },
                { PayoutScheme.Sepa, new PayoutScheme("Sepa") },
                { PayoutScheme.SepaInstant, new PayoutScheme("SepaInstant") }
            };
    }
}
