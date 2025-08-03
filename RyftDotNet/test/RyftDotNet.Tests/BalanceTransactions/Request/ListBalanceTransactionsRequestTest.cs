using System.Collections.Generic;
using RyftDotNet.BalanceTransactions.Request;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.BalanceTransactions.Request
{
    public sealed class ListBalanceTransactionsRequestTest
    {
        [Theory, MemberData(nameof(ExpectedQueryStrings))]
        public void ToQueryString_ShouldReturnExpectedValue(ListBalanceTransactionsRequest request, string expected)
            => request.ToQueryString().ShouldBe(expected);

        public static IEnumerable<object[]> ExpectedQueryStrings()
        {
            yield return
                new object[] { new ListBalanceTransactionsRequest(), string.Empty };
            yield return
                new object[] { new ListBalanceTransactionsRequest { Limit = 2 }, "?limit=2" };
            yield return
                new object[]
                {
                    new ListBalanceTransactionsRequest
                    {
                        Limit = 2, StartsAfter = "bltxn_01G0EYVFR02KBBVE2YWQ8AKMGJ"
                    },
                    "?limit=2&startsAfter=bltxn_01G0EYVFR02KBBVE2YWQ8AKMGJ"
                };
            yield return
                new object[]
                {
                    new ListBalanceTransactionsRequest { PayoutId = "po_01G0EYVFR02KBBVE2YWQ8AKMGJ" },
                    "?payoutId=po_01G0EYVFR02KBBVE2YWQ8AKMGJ"
                };
        }
    }
}
