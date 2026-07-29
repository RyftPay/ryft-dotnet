using System.IO;
using RyftDotNet.Conversions;
using RyftDotNet.Utility;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Conversions
{
    public sealed class ConversionRateTest
    {
        [Fact]
        public void FromJson_ShouldReturnExpectedValue()
        {
            string json = File.ReadAllText("assets/conversions/rate.json");
            JsonUtility.Deserialize<ConversionRate>(json).ShouldBe(new ConversionRate(
                new ConversionRateSell(1000L, "GBP"),
                new ConversionRateBuy(1247L, "USD", new ConversionFees(
                    new ConversionFee(10L),
                    new ConversionPlatformFeeDetail(5L, new ConversionFee(2L))
                )),
                1.247m,
                "2024-03-15"
            ));
        }
    }
}
