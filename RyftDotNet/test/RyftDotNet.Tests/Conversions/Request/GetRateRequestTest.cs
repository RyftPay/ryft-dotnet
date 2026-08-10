using System.Collections.Generic;
using RyftDotNet.Conversions.Request;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Conversions.Request
{
    public sealed class GetRateRequestTest
    {
        [Theory, MemberData(nameof(ExpectedQueryStrings))]
        public void ToQueryString_ShouldReturnExpectedValue(GetRateRequest request, string expected)
            => request.ToQueryString().ShouldBe(expected);

        public static IEnumerable<object[]> ExpectedQueryStrings()
        {
            yield return
                new object[] { new GetRateRequest(), string.Empty };
            yield return
                new object[] { new GetRateRequest { SellCurrency = "GBP" }, "?sellCurrency=GBP" };
            yield return
                new object[] { new GetRateRequest { BuyCurrency = "USD" }, "?buyCurrency=USD" };
            yield return
                new object[] { new GetRateRequest { Amount = 1000L }, "?amount=1000" };
            yield return
                new object[]
                {
                    new GetRateRequest { SellCurrency = "GBP", BuyCurrency = "USD", Amount = 1000L },
                    "?buyCurrency=USD&sellCurrency=GBP&amount=1000"
                };
        }
    }
}
