using System.Collections.Generic;
using RyftDotNet.PlatformFees.Request;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.PlatformFees.Request
{
    public sealed class ListPlatformFeesRequestTest
    {
        [Theory, MemberData(nameof(ExpectedQueryStrings))]
        public void ToQueryString_ShouldReturnExpectedValue(ListPlatformFeesRequest request, string expected)
            => request.ToQueryString().ShouldBe(expected);

        public static IEnumerable<object[]> ExpectedQueryStrings()
        {
            yield return
                new object[] { new ListPlatformFeesRequest(), string.Empty };
            yield return
                new object[] { new ListPlatformFeesRequest { Limit = 5 }, "?limit=5" };
            yield return
                new object[] { new ListPlatformFeesRequest { Ascending = true }, "?ascending=true" };
            yield return
                new object[]
                {
                    new ListPlatformFeesRequest { StartsAfter = "pf_01FCTS1XMKH9FF43CAFA4CXT3P" },
                    "?startsAfter=pf_01FCTS1XMKH9FF43CAFA4CXT3P"
                };
            yield return
                new object[]
                {
                    new ListPlatformFeesRequest
                    {
                        Limit = 2,
                        Ascending = false,
                        StartsAfter = "pf_01FCTS1XMKH9FF43CAFA4CXT3P"
                    },
                    "?ascending=false&limit=2&startsAfter=pf_01FCTS1XMKH9FF43CAFA4CXT3P"
                };
            yield return
                new object[]
                {
                    new ListPlatformFeesRequest { Limit = 2, Ascending = false }, "?ascending=false&limit=2"
                };
        }
    }
}
