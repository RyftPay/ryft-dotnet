using System.Collections.Generic;
using RyftDotNet.Balances.Request;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Balances.Request
{
    public sealed class ListBalancesRequestTest
    {
        [Theory, MemberData(nameof(ExpectedQueryStrings))]
        public void ToQueryString_ShouldReturnExpectedValue(ListBalancesRequest request, string expected)
            => request.ToQueryString().ShouldBe(expected);

        public static IEnumerable<object[]> ExpectedQueryStrings()
        {
            yield return
                new object[] { new ListBalancesRequest(), string.Empty };
            yield return
                new object[] { new ListBalancesRequest { Currency = new[] { "EUR" } }, "?currency=EUR" };
            yield return
                new object[]
                {
                    new ListBalancesRequest { Currency = new[] { "GBP", "EUR", "USD" } },
                    "?currency=GBP&currency=EUR&currency=USD"
                };
        }
    }
}
