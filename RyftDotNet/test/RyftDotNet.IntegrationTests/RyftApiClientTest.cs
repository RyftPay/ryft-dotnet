using RyftDotNet.Client;
using RyftDotNet.Client.Error;
using RyftDotNet.Customers;
using Shouldly;

namespace RyftDotNet.IntegrationTests;

public sealed class RyftApiClientTest
{
    private const string ApiKey = "sk_sandbox";

    private readonly RyftApiClient apiClient = new();

    [Theory, InlineData(null), InlineData("    ")]
    public async Task RequestAsync_ShouldThrowException_WhenApiKeyIsMissingOrEmpty(string apiKey)
    {
        var action = async () => await apiClient.RequestAsync<Customer>(
            "customers",
            HttpMethod.Post,
            requestSettings: new ClientRequestSettings { ApiKey = apiKey }
        );
        var exception = await action.ShouldThrowAsync<RyftArgumentException>();
        exception.Message.ShouldBe("Your API key is missing or invalid");
    }

    [Theory, InlineData("1234"), InlineData("ac_1234")]
    public async Task RequestAsync_ShouldThrowException_WhenAccountIdIsInvalid(string accountId)
    {
        var action = async () => await apiClient.RequestAsync<Customer>(
            "customers",
            HttpMethod.Post,
            requestSettings: new ClientRequestSettings { ApiKey = ApiKey, AccountId = accountId }
        );
        var exception = await action.ShouldThrowAsync<RyftArgumentException>();
        exception.Message.ShouldContain($"The supplied account ID of '{accountId}' is invalid");
    }
}
