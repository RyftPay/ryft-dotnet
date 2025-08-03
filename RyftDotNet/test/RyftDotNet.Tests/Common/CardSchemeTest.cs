using RyftDotNet.Common;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Common
{
    public sealed class CardSchemeTest
    {
        [Theory, MemberData(nameof(ExpectedValues))]
        public void StaticValues_ShouldReturnExpectedValue(CardScheme actual, CardScheme expected)
            => actual.ShouldBe(expected);

        public static TheoryData<CardScheme, CardScheme> ExpectedValues() =>
            new TheoryData<CardScheme, CardScheme>
            {
                { CardScheme.Visa, new CardScheme("Visa") },
                { CardScheme.Mastercard, new CardScheme("Mastercard") },
                { CardScheme.Amex, new CardScheme("Amex") }
            };
    }
}
