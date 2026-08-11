using System;
using RyftDotNet.Client.Error;
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

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void Constructor_ShouldThrow_WhenBuyCurrencyIsMissing(string? buyCurrency)
        {
            Func<GetRateRequest> action = () => new GetRateRequest(buyCurrency!, sellCurrency: "GBP", amount: 1000L);
            var exception = action.ShouldThrow<RyftArgumentException>();
            exception.Message.ShouldContain("buyCurrency is required");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void Constructor_ShouldThrow_WhenSellCurrencyIsMissing(string? sellCurrency)
        {
            Func<GetRateRequest> action = () => new GetRateRequest(buyCurrency: "USD", sellCurrency!, amount: 1000L);
            var exception = action.ShouldThrow<RyftArgumentException>();
            exception.Message.ShouldContain("sellCurrency is required");
        }
    }
}
