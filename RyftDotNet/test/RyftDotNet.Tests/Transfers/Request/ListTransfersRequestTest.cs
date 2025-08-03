using System.Collections.Generic;
using RyftDotNet.Transfers.Request;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Transfers.Request
{
    public sealed class ListTransfersRequestTest
    {
        [Theory, MemberData(nameof(ExpectedQueryStrings))]
        public void ToQueryString_ShouldReturnExpectedValue(ListTransfersRequest request, string expected)
            => request.ToQueryString().ShouldBe(expected);

        public static IEnumerable<object[]> ExpectedQueryStrings()
        {
            yield return
                new object[] { new ListTransfersRequest(), string.Empty };
            yield return
                new object[] { new ListTransfersRequest { Limit = 5 }, "?limit=5" };
            yield return
                new object[] { new ListTransfersRequest { Ascending = true }, "?ascending=true" };
            yield return
                new object[] { new ListTransfersRequest { Limit = 2, Ascending = false }, "?ascending=false&limit=2" };
            yield return
                new object[]
                {
                    new ListTransfersRequest
                    {
                        Limit = 2, Ascending = false, StartsAfter = "tfr_01G0EYVFR02KBBVE2YWQ8AKMGJ"
                    },
                    "?ascending=false&limit=2&startsAfter=tfr_01G0EYVFR02KBBVE2YWQ8AKMGJ"
                };
        }
    }
}
