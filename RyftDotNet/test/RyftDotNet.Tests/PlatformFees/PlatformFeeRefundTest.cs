using System;
using System.IO;
using RyftDotNet.PlatformFees;
using RyftDotNet.Utility;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.PlatformFees
{
    public sealed class PlatformFeeRefundTest
    {
        [Fact]
        public void FromJson_ShouldReturnExpectedValue()
        {
            string json = File.ReadAllText("assets/platform-fees/refund-response.json");
            JsonUtility.Deserialize<PlatformFeeRefund>(json).ShouldBe(new PlatformFeeRefund(
                "fr_01FM9XMMV1MYDG6NGMHPDE065N_01FM9XNFXDYXAT0BJN5BBN794B",
                "pf_01FM9XMMV1MYDG6NGMHPDE065N",
                5,
                "GBP",
                "Requested by the customer",
                "Succeeded",
                DateTimeOffset.FromUnixTimeSeconds(1470989538),
                DateTimeOffset.FromUnixTimeSeconds(1470989538)
            ));
        }
    }
}
