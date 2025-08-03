using RyftDotNet.Accounts;
using RyftDotNet.Accounts.Request;
using RyftDotNet.Client;
using RyftDotNet.Common.Request;
using Shouldly;

namespace RyftDotNet.IntegrationTests;

public sealed class AccountsApiClientTest
{
    private readonly AccountsApiClient apiClient = new(new RyftApiClient(
        requestSettings: new ClientRequestSettings { ApiKey = TestUtility.SecretApiKey }
    ));

    [Fact]
    public async Task Client_ShouldSuccessfullyInteractWithEndpoints()
    {
        var result = await apiClient.CreateAsync(
            new CreateAccountRequest { OnboardingFlow = OnboardingFlow.NonHosted }
        );
        result.ShouldSatisfyAllConditions(
            r => r.OnboardingFlow.ShouldBe(OnboardingFlow.NonHosted),
            r => r.Verification.ShouldNotBeNull()
        );

        var retrieved = await apiClient.GetAsync(result.Id);
        retrieved.Id.ShouldBe(result.Id);

        var updated = await apiClient.UpdateAsync(
            result.Id,
            new UpdateAccountRequest
            {
                EntityType = EntityType.Business,
                Business = new UpdateAccountBusinessRequest
                {
                    Name = "Ryft Ltd",
                    PhoneNumber = "+447900000000",
                    ContactEmail = $"{TestUtility.ResourcePrefix()}@ryftpay.com",
                    Type = BusinessType.PrivateCompany,
                    RegistrationNumber = "0000000010",
                    RegisteredAddress = new AccountAddressRequest(
                        "123 Test Street",
                        "Manchester",
                        "GB",
                        "ABC 123"
                    )
                },
                Metadata = new Dictionary<string, string> { ["reference"] = "1234567890" }
            }
        );
        updated.ShouldSatisfyAllConditions(
            u => u.EntityType.ShouldBe(EntityType.Business),
            u => u.Metadata.ShouldNotBeNull(),
            u => u.Metadata?.ShouldContainKeyAndValue("reference", "1234567890")
        );
    }
}
