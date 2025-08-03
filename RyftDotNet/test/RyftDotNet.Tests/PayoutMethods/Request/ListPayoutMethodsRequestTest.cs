using System.Collections.Generic;
using RyftDotNet.PayoutMethods.Request;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.PayoutMethods.Request
{
    public sealed class ListPayoutMethodsRequestTest
    {
        [Theory, MemberData(nameof(ExpectedQueryStrings))]
        public void ToQueryString_ShouldReturnExpectedValue(ListPayoutMethodsRequest request, string expected)
            => request.ToQueryString().ShouldBe(expected);

        public static IEnumerable<object[]> ExpectedQueryStrings()
        {
            yield return
                new object[] { new ListPayoutMethodsRequest(), string.Empty };
            yield return
                new object[] { new ListPayoutMethodsRequest { Limit = 5 }, "?limit=5" };
            yield return
                new object[] { new ListPayoutMethodsRequest { Ascending = true }, "?ascending=true" };
            yield return
                new object[]
                {
                    new ListPayoutMethodsRequest { Limit = 2, Ascending = false }, "?ascending=false&limit=2"
                };
            yield return
                new object[]
                {
                    new ListPayoutMethodsRequest
                    {
                        Limit = 2, Ascending = false, StartsAfter = "pm_01G0EYVFR02KBBVE2YWQ8AKMGJ"
                    },
                    "?ascending=false&limit=2&startsAfter=pm_01G0EYVFR02KBBVE2YWQ8AKMGJ"
                };
        }
    }
}
