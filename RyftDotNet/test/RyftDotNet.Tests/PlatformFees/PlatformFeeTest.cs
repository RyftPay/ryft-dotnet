using System;
using System.IO;
using RyftDotNet.PlatformFees;
using RyftDotNet.Utility;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.PlatformFees
{
    public sealed class PlatformFeeTest
    {
        [Fact]
        public void FromJson_ShouldReturnExpectedValue()
        {
            string json = File.ReadAllText("assets/platform-fees/response.json");
            JsonUtility.Deserialize<PlatformFee>(json).ShouldBe(new PlatformFee(
                "pf_01FCTS1XMKH9FF43CAFA4CXT3P",
                "ps_01JJPPAZTNN38EMDJ72FASHE7R",
                40,
                450L,
                "GBP",
                "ac_b83f2653-06d7-44a9-a548-5825e8186004",
                DateTimeOffset.FromUnixTimeSeconds(1470989538)
            ));
        }
    }
}
