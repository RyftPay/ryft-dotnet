using RyftDotNet.Client;
using RyftDotNet.Common;
using RyftDotNet.InPerson.Locations;
using RyftDotNet.InPerson.Locations.Request;
using Shouldly;

namespace RyftDotNet.IntegrationTests;

public sealed class InPersonLocationsApiClientTest
{
    private readonly InPersonLocationsApiClient apiClient = new(new RyftApiClient(
        requestSettings: new ClientRequestSettings { ApiKey = TestUtility.SecretApiKey }
    ));

    [Fact]
    public async Task Client_ShouldBeAbleToCreateLocation()
    {
        var request = new CreateInPersonLocationRequest(
            $"Test Location {TestUtility.ResourcePrefix()}",
            new InPersonLocationAddressRequest(
                "123 Test Street",
                "London",
                "GB",
                "SW1A 1AA"
            )
        )
        {
            Metadata = new Dictionary<string, string> { { "test", "integration" } }
        };

        var result = await apiClient.CreateAsync(request);
        result.Name.ShouldBe(request.Name);
        result.Address.LineOne.ShouldBe(request.Address.LineOne);
        result.Address.City.ShouldBe(request.Address.City);
        result.Address.Country.ShouldBe(request.Address.Country);
        result.Address.PostalCode.ShouldBe(request.Address.PostalCode);

        var fetched = await apiClient.GetAsync(result.Id);
        fetched.Id.ShouldBe(result.Id);
        fetched.Name.ShouldBe(result.Name);

        var deleted = await apiClient.DeleteAsync(result.Id);
        deleted.Id.ShouldBe(result.Id);
    }

    [Fact]
    public async Task Client_ShouldBeAbleToUpdateLocation()
    {
        var createRequest = new CreateInPersonLocationRequest(
            $"Test Location {TestUtility.ResourcePrefix()}",
            new InPersonLocationAddressRequest(
                "123 Test Street",
                "London",
                "GB",
                "SW1A 1AA"
            )
        );

        var created = await apiClient.CreateAsync(createRequest);

        var updateRequest = new UpdateInPersonLocationRequest
        {
            Name = $"Updated Location {TestUtility.ResourcePrefix()}",
            Metadata = new Dictionary<string, string> { { "updated", "true" } }
        };

        var updated = await apiClient.UpdateAsync(created.Id, updateRequest);
        updated.Id.ShouldBe(created.Id);
        updated.Name.ShouldBe(updateRequest.Name);
        updated.Metadata.ShouldNotBeNull();
        updated.Metadata!["updated"].ShouldBe("true");

        await apiClient.DeleteAsync(created.Id);
    }

    [Fact]
    public async Task Client_ShouldBeAbleToDeleteLocation()
    {
        var request = new CreateInPersonLocationRequest(
            $"Test Location {TestUtility.ResourcePrefix()}",
            new InPersonLocationAddressRequest(
                "123 Test Street",
                "London",
                "GB",
                "SW1A 1AA"
            )
        );

        var result = await apiClient.CreateAsync(request);
        var deleted = await apiClient.DeleteAsync(result.Id);
        deleted.ShouldBe(new InPersonLocationDeleted(result.Id));
    }

    [Fact]
    public async Task Client_ShouldBeAbleToListLocations()
    {
        var request1 = new CreateInPersonLocationRequest(
            $"Test Location 1 {TestUtility.ResourcePrefix()}",
            new InPersonLocationAddressRequest(
                "123 Test Street",
                "London",
                "GB",
                "SW1A 1AA"
            )
        );

        var request2 = new CreateInPersonLocationRequest(
            $"Test Location 2 {TestUtility.ResourcePrefix()}",
            new InPersonLocationAddressRequest(
                "456 Test Avenue",
                "Manchester",
                "GB",
                "M1 1AA"
            )
        );

        var created1 = await apiClient.CreateAsync(request1);
        var created2 = await apiClient.CreateAsync(request2);

        var listRequest = new ListInPersonLocationsRequest
        {
            Limit = 10
        };

        var result = await apiClient.ListAsync(listRequest);
        result.Items.ShouldNotBeEmpty();
        result.Items.ShouldContain(l => l.Id == created1.Id);
        result.Items.ShouldContain(l => l.Id == created2.Id);

        await apiClient.DeleteAsync(created1.Id);
        await apiClient.DeleteAsync(created2.Id);
    }

    [Fact]
    public async Task Client_ShouldBeAbleToCreateLocationWithGeoCoordinates()
    {
        var request = new CreateInPersonLocationRequest(
            $"Test Location {TestUtility.ResourcePrefix()}",
            new InPersonLocationAddressRequest(
                "123 Oxford Street",
                "London",
                "GB",
                "W1D 1BS"
            )
        )
        {
            GeoCoordinates = new GeoCoordinatesRequest(51.5074, -0.1278)
        };

        var result = await apiClient.CreateAsync(request);
        result.GeoCoordinates.ShouldNotBeNull();
        result.GeoCoordinates!.Latitude.ShouldBe(request.GeoCoordinates.Latitude);
        result.GeoCoordinates.Longitude.ShouldBe(request.GeoCoordinates.Longitude);

        await apiClient.DeleteAsync(result.Id);
    }
}