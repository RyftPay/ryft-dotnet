using System.IO;
using RyftDotNet.Conversions;
using RyftDotNet.Utility;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Conversions
{
    public sealed class ConversionTest
    {
        [Fact]
        public void FromJson_ShouldReturnExpectedValue_WhenMinimumRequiredFieldsReturned()
        {
            string json = File.ReadAllText("assets/conversions/conversion-min.json");
            JsonUtility.Deserialize<Conversion>(json).ShouldBe(new Conversion(
                "con_01FCTS1XMKH9FF43CAFA4CXT3P",
                new ConversionSell(null, "GBP", null),
                new ConversionBuy(null, "USD", null),
                null,
                ConversionStatus.InProgress,
                null,
                null,
                null,
                null,
                1470989538L
            ));
        }

        [Fact]
        public void FromJson_ShouldReturnExpectedValue_WhenAllFieldsReturned()
        {
            string json = File.ReadAllText("assets/conversions/conversion-full.json");
            JsonUtility.Deserialize<Conversion>(json).ShouldBe(new Conversion(
                "con_01FCTS1XMKH9FF43CAFA4CXT3P",
                new ConversionSell(1000L, "GBP", null),
                new ConversionBuy(1247L, "USD", new ConversionFees(
                    new ConversionFee(10L),
                    new ConversionPlatformFeeDetail(5L, new ConversionFee(2L))
                )),
                1.247m,
                ConversionStatus.Settled,
                "FX conversion",
                "2024-03-15",
                1470989600L,
                new ConversionCreatedBy("ac_b83f2653-06d7-44a9-a548-5825e8186004", "Test Account"),
                1470989538L
            ));
        }
    }
}
