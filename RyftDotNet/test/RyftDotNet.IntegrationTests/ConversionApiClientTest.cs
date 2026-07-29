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
    public async Task Client_ShouldBeAbleToGetRate()
    {
        var result = await apiClient.GetRatesAsync(new GetRateRequest
        {
            BuyCurrency = "EUR",
            SellCurrency = "GBP",
            Amount = 1000
        });
        result.ShouldSatisfyAllConditions(
            r => r.Sell.ShouldNotBeNull(),
            r => r.Buy.ShouldNotBeNull(),
            r => r.Rate.ShouldBeGreaterThan(0)
        );
    }

    [Fact]
    public async Task Client_ShouldBeAbleToListResources()
    {
        var result = await apiClient.ListAsync(new ListConversionsRequest { Limit = 1 });
        result.ShouldSatisfyAllConditions(
            r => r.Items.ShouldNotBeNull()
        );
    }

    [Fact]
    public async Task Client_ShouldBeAbleToCreateAndGetConversion()
    {
        var request = new CreateConversionRequest(
            sell: new ConversionSideRequest("GBP") { Amount = 1000 },
            buy: new ConversionSideRequest("EUR"),
            termAgreement: true
        );
        var created = await apiClient.CreateAsync(request);
        created.ShouldSatisfyAllConditions(
            r => r.Id.ShouldNotBeNullOrEmpty(),
            r => r.Sell.Currency.ShouldBe("GBP"),
            r => r.Buy.Currency.ShouldBe("EUR")
        );
        var fetched = await apiClient.GetAsync(created.Id);
        fetched.Id.ShouldBe(created.Id);
    }
}
