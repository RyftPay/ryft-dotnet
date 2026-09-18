using System.Collections.Generic;
using RyftDotNet.PlatformFees.Request;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.PlatformFees.Request
{
    public sealed class ListPlatformFeeRefundsRequestTest
    {
        [Theory, MemberData(nameof(ExpectedQueryStrings))]
        public void ToQueryString_ShouldReturnExpectedValue(
            ListPlatformFeeRefundsRequest request,
            string expected)
            => request.ToQueryString().ShouldBe(expected);

        public static IEnumerable<object[]> ExpectedQueryStrings()
        {
            yield return
                new object[] { new ListPlatformFeeRefundsRequest(), string.Empty };
            yield return
                new object[] { new ListPlatformFeeRefundsRequest { Limit = 5 }, "?limit=5" };
            yield return
                new object[] { new ListPlatformFeeRefundsRequest { Ascending = true }, "?ascending=true" };
            yield return
                new object[]
                {
                    new ListPlatformFeeRefundsRequest { StartsAfter = "fr_01FM9XMMV1MYDG6NGMHPDE065N_01FM9XNFXDYXAT0BJN5BBN794B" },
                    "?startsAfter=fr_01FM9XMMV1MYDG6NGMHPDE065N_01FM9XNFXDYXAT0BJN5BBN794B"
                };
            yield return
                new object[]
                {
                    new ListPlatformFeeRefundsRequest { Limit = 2, Ascending = false },
                    "?ascending=false&limit=2"
                };
            yield return
                new object[]
                {
                    new ListPlatformFeeRefundsRequest
                    {
                        Limit = 2,
                        Ascending = false,
                        StartsAfter = "fr_01FM9XMMV1MYDG6NGMHPDE065N_01FM9XNFXDYXAT0BJN5BBN794B"
                    },
                    "?ascending=false&limit=2&startsAfter=fr_01FM9XMMV1MYDG6NGMHPDE065N_01FM9XNFXDYXAT0BJN5BBN794B"
                };
        }
    }
}
