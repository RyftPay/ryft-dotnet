using RyftDotNet.Client;
using RyftDotNet.Common;
using RyftDotNet.Common.Request;
using RyftDotNet.PaymentMethods;
using RyftDotNet.PaymentMethods.Request;
using Shouldly;

namespace RyftDotNet.IntegrationTests;

public sealed class PaymentMethodsApiClientTest
{
    private readonly PaymentMethodsApiClient apiClient = new(new RyftApiClient(
        requestSettings: new ClientRequestSettings { ApiKey = TestUtility.SecretApiKey }
    ));

    private static readonly string PaymentMethodId = TestUtility.ExistingPaymentMethodId;

    [Fact]
    public async Task Client_ShouldBeAbleToGetExistingResource()
    {
        var result = await apiClient.GetAsync(PaymentMethodId);
        result.ShouldSatisfyAllConditions(
            f => f.Id.ShouldBe(PaymentMethodId),
            f => f.Type.ShouldBe(PaymentMethodType.Card),
            f => f.Card.ShouldBe(new PaymentMethodCard(
                CardScheme.Visa,
                "0085",
                "10",
                "2030"
            )),
            f => f.CreatedTimestamp.ShouldBe(DateTimeOffset.FromUnixTimeSeconds(1750696652))
        );
    }

    [Fact]
    public async Task Client_ShouldBeAbleToUpdateExistingResource()
    {
        string lineOne = Guid.NewGuid().ToString();
        var result = await apiClient.UpdateAsync(
            PaymentMethodId,
            new UpdatePaymentMethodRequest
            {
                BillingAddress = new AddressRequest(
                    country: "GB",
                    postalCode: "M3 3EB"
                )
                { LineOne = lineOne }
            }
        );
        result.BillingAddress.ShouldBe(new Address(
            null,
            null,
            lineOne: lineOne,
            null,
            null,
            "GB",
            "M3 3EB",
            null
        ));
    }
}
