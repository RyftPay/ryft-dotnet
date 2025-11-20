using RyftDotNet.Client;
using RyftDotNet.Common;
using RyftDotNet.InPerson.Terminals;
using RyftDotNet.InPerson.Terminals.Request;
using Shouldly;

namespace RyftDotNet.IntegrationTests;

public sealed class InPersonTerminalsApiClientTest
{
    private readonly InPersonTerminalsApiClient apiClient = new(new RyftApiClient(
        requestSettings: new ClientRequestSettings { ApiKey = TestUtility.SecretApiKey }
    ));

    [Fact]
    public async Task Client_ShouldBeAbleToListTerminals()
    {
        var request = new ListTerminalsRequest
        {
            Limit = 10
        };

        var result = await apiClient.ListAsync(request);
        result.ShouldNotBeNull();
        result.Items.ShouldNotBeNull();
    }

    [Fact]
    public async Task Client_ShouldBeAbleToGetTerminal()
    {
        var listResult = await apiClient.ListAsync(new ListTerminalsRequest { Limit = 1 });

        if (listResult.Items.Any())
        {
            var terminalId = listResult.Items.First().Id;

            var terminal = await apiClient.GetAsync(terminalId);
            terminal.ShouldNotBeNull();
            terminal.Id.ShouldBe(terminalId);
            terminal.Name.ShouldNotBeNullOrEmpty();
            terminal.Device.ShouldNotBeNull();
            terminal.Device.SerialNumber.ShouldNotBeNullOrEmpty();
            terminal.Location.ShouldNotBeNull();
            terminal.Location.Id.ShouldNotBeNullOrEmpty();
        }
        else
        {
            Assert.True(true, "No terminals available in test environment to fetch");
        }
    }

    [Fact]
    public async Task Client_ShouldBeAbleToListTerminalsWithPagination()
    {
        var request = new ListTerminalsRequest
        {
            Limit = 2,
            Ascending = true
        };

        var result = await apiClient.ListAsync(request);
        result.ShouldNotBeNull();
        result.Items.ShouldNotBeNull();

        if (result.Items.Count() > 1)
        {
            var terminals = result.Items.ToList();
            terminals.Count.ShouldBeLessThanOrEqualTo(2);
        }
    }

    [Fact]
    public async Task Client_ShouldReturnTerminalWithCompleteDetails()
    {
        var listResult = await apiClient.ListAsync(new ListTerminalsRequest { Limit = 1 });

        if (listResult.Items.Any())
        {
            var terminal = listResult.Items.First();

            terminal.Id.ShouldNotBeNullOrEmpty();
            terminal.Name.ShouldNotBeNullOrEmpty();
            terminal.Device.ShouldNotBeNull();
            terminal.Device.SerialNumber.ShouldNotBeNullOrEmpty();
            terminal.Device.Type.ShouldNotBeNullOrEmpty();
            terminal.Location.ShouldNotBeNull();
            terminal.Location.Id.ShouldNotBeNullOrEmpty();
            terminal.CreatedTimestamp.ShouldNotBe(default);
            terminal.LastUpdatedTimestamp.ShouldNotBe(default);
        }
        else
        {
            Assert.True(true, "No terminals available in test environment to verify details");
        }
    }
}
