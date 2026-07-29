using RyftDotNet.Conversions;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Conversions
{
    public sealed class ConversionStatusTest
    {
        [Theory, MemberData(nameof(ExpectedValues))]
        public void StaticValues_ShouldReturnExpectedValue(ConversionStatus actual, ConversionStatus expected)
            => actual.ShouldBe(expected);

        public static TheoryData<ConversionStatus, ConversionStatus> ExpectedValues() =>
            new TheoryData<ConversionStatus, ConversionStatus>
            {
                { ConversionStatus.InProgress, new ConversionStatus("InProgress") },
                { ConversionStatus.Settled, new ConversionStatus("Settled") }
            };
    }
}
