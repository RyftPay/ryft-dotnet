using System.Collections.Generic;
using RyftDotNet.Conversions.Request;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Conversions.Request
{
    public sealed class ListConversionsRequestTest
    {
        [Theory, MemberData(nameof(ExpectedQueryStrings))]
        public void ToQueryString_ShouldReturnExpectedValue(ListConversionsRequest request, string expected)
            => request.ToQueryString().ShouldBe(expected);

        public static IEnumerable<object[]> ExpectedQueryStrings()
        {
            yield return
                new object[] { new ListConversionsRequest(), string.Empty };
            yield return
                new object[] { new ListConversionsRequest { Limit = 5 }, "?limit=5" };
            yield return
                new object[] { new ListConversionsRequest { Ascending = true }, "?ascending=true" };
            yield return
                new object[] { new ListConversionsRequest { Ascending = false, Limit = 2 }, "?limit=2&ascending=false" };
            yield return
                new object[]
                {
                    new ListConversionsRequest { StartsAfter = "con_01FCTS1XMKH9FF43CAFA4CXT3P" },
                    "?startsAfter=con_01FCTS1XMKH9FF43CAFA4CXT3P"
                };
            yield return
                new object[]
                {
                    new ListConversionsRequest
                    {
                        Limit = 2,
                        Ascending = false,
                        StartTimestamp = 1631696701L,
                        EndTimestamp = 1631696705L
                    },
                    "?startTimestamp=1631696701&endTimestamp=1631696705&limit=2&ascending=false"
                };
        }
    }
}
