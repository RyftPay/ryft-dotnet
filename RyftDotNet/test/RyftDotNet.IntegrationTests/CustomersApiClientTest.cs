using RyftDotNet.Client;
using RyftDotNet.Common;
using RyftDotNet.Customers;
using RyftDotNet.Customers.Request;
using Shouldly;

namespace RyftDotNet.IntegrationTests;

public sealed class CustomersApiClientTest
{
    private readonly CustomersApiClient apiClient = new(new RyftApiClient(
        requestSettings: new ClientRequestSettings { ApiKey = TestUtility.SecretApiKey }
    ));

    [Fact]
    public async Task Client_ShouldBeAbleToCreateCustomer()
    {
        var result = await apiClient.CreateAsync(
            new CreateCustomerRequest($"{TestUtility.ResourcePrefix()}@ryftpay.com")
        );
        var fetched = await apiClient.GetAsync(result.Id);
        fetched.Id.ShouldBe(result.Id);
        var deleted = await apiClient.DeleteAsync(result.Id);
        deleted.Id.ShouldBe(result.Id);
    }

    [Fact]
    public async Task Client_ShouldBeAbleToUpdateCustomer()
    {
        var result = await apiClient.CreateAsync(
            new CreateCustomerRequest($"{TestUtility.ResourcePrefix()}@ryftpay.com")
        );
        var request = new UpdateCustomerRequest
        {
            FirstName = "Integration",
            LastName = "Tester",
            HomePhoneNumber = "+447900000001",
            MobilePhoneNumber = "+447900000002"
        };
        var updated = await apiClient.UpdateAsync(result.Id, request);
        updated.ShouldBe(new Customer(
            result.Id,
            result.Email,
            result.CreatedTimestamp,
            request.FirstName,
            request.LastName,
            request.HomePhoneNumber,
            request.MobilePhoneNumber,
            result.DefaultPaymentMethod,
            result.Metadata
        ));
    }

    [Fact]
    public async Task Client_ShouldBeAbleToDeleteCustomer()
    {
        var result = await apiClient.CreateAsync(
            new CreateCustomerRequest($"{TestUtility.ResourcePrefix()}@ryftpay.com")
        );
        var deleted = await apiClient.DeleteAsync(result.Id);
        deleted.ShouldBe(new DeletedResource(result.Id));
    }
}
