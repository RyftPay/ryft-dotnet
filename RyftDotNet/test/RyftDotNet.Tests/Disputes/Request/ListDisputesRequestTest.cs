using System;
using System.Collections.Generic;
using RyftDotNet.Disputes.Request;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Disputes.Request
{
    public sealed class ListDisputesRequestTest
    {
        [Theory, MemberData(nameof(ExpectedQueryStrings))]
        public void ToQueryString_ShouldReturnExpectedValue(ListDisputesRequest request, string expected)
            => request.ToQueryString().ShouldBe(expected);

        public static IEnumerable<object[]> ExpectedQueryStrings()
        {
            yield return new object[] { new ListDisputesRequest(), string.Empty };
            yield return new object[] { new ListDisputesRequest { Limit = 5 }, "?limit=5" };
            yield return new object[] { new ListDisputesRequest { Ascending = true }, "?ascending=true" };
            yield return new object[] { new ListDisputesRequest { Limit = 2, Ascending = false }, "?ascending=false&limit=2" };
            yield return new object[]
            {
                new ListDisputesRequest
                {
                    Limit = 2, Ascending = false, StartsAfter = "dsp_01G0EYVFR02KBBVE2YWQ8AKMGJ"
                },
                "?ascending=false&limit=2&startsAfter=dsp_01G0EYVFR02KBBVE2YWQ8AKMGJ"
            };
            yield return new object[]
            {
                new ListDisputesRequest
                {
                    Limit = 2,
                    Ascending = false,
                    StartTimestamp = DateTimeOffset.FromUnixTimeSeconds(1631696701),
                    EndTimestamp = DateTimeOffset.FromUnixTimeSeconds(1631696705)
                },
                "?ascending=false&limit=2&startTimestamp=1631696701&endTimestamp=1631696705"
            };
        }
    }
}
