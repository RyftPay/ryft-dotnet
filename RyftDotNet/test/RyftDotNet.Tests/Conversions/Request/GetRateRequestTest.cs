using RyftDotNet.Conversions.Request;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Conversions.Request
{
    public sealed class GetRateRequestTest
    {
        [Fact]
        public void ToQueryString_ShouldReturnExpectedValue()
        {
            var request = new GetRateRequest(buyCurrency: "USD", sellCurrency: "GBP", amount: 1000L);
            request.ToQueryString().ShouldBe("?buyCurrency=USD&sellCurrency=GBP&amount=1000");
        }
    }
}
