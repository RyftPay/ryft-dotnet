using RyftDotNet.Client;
using RyftDotNet.Conversions;
using RyftDotNet.Conversions.Request;
using Shouldly;

namespace RyftDotNet.IntegrationTests;

public sealed class ConversionApiClientTest
{
    private readonly ConversionApiClient apiClient = new(new RyftApiClient(
        requestSettings: new ClientRequestSettings { ApiKey = TestUtility.SecretApiKey }
    ));

    [Fact]
    public async Task Client_ShouldBeAbleToCreateConversion()
    {
        var request = new CreateConversionRequest(
            sell: new SellConversionRequest("GBP", 500),
            buy: new BuyConversionRequest("EUR"),
            termAgreement: true
        );
        var created = await apiClient.CreateAsync(request);
        created.ShouldSatisfyAllConditions(
            r => r.Id.ShouldNotBeNullOrEmpty(),
            r => r.Sell.Currency.ShouldBe("GBP"),
            r => r.Buy.Currency.ShouldBe("EUR")
        );
    }

    [Fact]
    public async Task Client_ShouldBeAbleToGetConversion()
    {
        var request = new CreateConversionRequest(
            sell: new SellConversionRequest("GBP", 500),
            buy: new BuyConversionRequest("EUR"),
            termAgreement: true
        );
        var created = await apiClient.CreateAsync(request);

        var fetched = await apiClient.GetAsync(created.Id);
        fetched.Id.ShouldBe(created.Id);
    }

    [Fact]
    public async Task Client_ShouldBeAbleToListResources()
    {
        var request = new CreateConversionRequest(
            sell: new SellConversionRequest("GBP", 500),
            buy: new BuyConversionRequest("EUR"),
            termAgreement: true
        );
        var created = await apiClient.CreateAsync(request);

        var listed = await apiClient.ListAsync(new ListConversionsRequest { Limit = 1 });
        listed.Items.ShouldContain(created);
    }

    [Fact]
    public async Task Client_ShouldBeAbleToGetRate()
    {
        var result = await apiClient.GetRateAsync(
            new GetRateRequest(buyCurrency: "EUR", sellCurrency: "GBP", amount: 1000));
        result.ShouldSatisfyAllConditions(
            r => r.Sell.ShouldNotBeNull(),
            r => r.Buy.ShouldNotBeNull(),
            r => r.Rate.ShouldBeGreaterThan(0)
        );
    }
}
