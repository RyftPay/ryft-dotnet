using RyftDotNet.Conversions;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Conversions
{
    public sealed class ConversionTriggerTypeTest
    {
        [Theory, MemberData(nameof(ExpectedValues))]
        public void StaticValues_ShouldReturnExpectedValue(ConversionTriggerType actual, ConversionTriggerType expected)
            => actual.ShouldBe(expected);

        public static TheoryData<ConversionTriggerType, ConversionTriggerType> ExpectedValues() =>
            new TheoryData<ConversionTriggerType, ConversionTriggerType>
            {
                { ConversionTriggerType.Manual, new ConversionTriggerType("Manual") },
                { ConversionTriggerType.Automatic, new ConversionTriggerType("Automatic") }
            };
    }
}
