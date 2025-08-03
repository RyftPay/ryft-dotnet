using RyftDotNet.Client;
using RyftDotNet.Files;
using RyftDotNet.Files.Request;
using Shouldly;
using File = System.IO.File;

namespace RyftDotNet.IntegrationTests;

public sealed class FilesApiClientTest
{
    private readonly FilesApiClient apiClient = new(new RyftApiClient(
        requestSettings: new ClientRequestSettings { ApiKey = TestUtility.SecretApiKey }
    ));

    [Fact]
    public async Task Client_ShouldBeAbleToCreateGetAndListResources()
    {
        await using var stream = File.Open("assets/ryft-logo.png", FileMode.Open);
        var request = CreateFileRequest.Create(
            stream,
            FileCategory.Evidence,
            new Dictionary<string, string> { { "custom", "123" } }
        );
        var result = await apiClient.CreateAsync(request);
        result.ShouldSatisfyAllConditions(
            r => r.Name.ShouldBe("ryft-logo.png"),
            r => r.Metadata.ShouldNotBeNull(),
            r => r.Metadata?.ShouldContainKeyAndValue("custom", "123")
        );
        var fetched = await apiClient.GetAsync(result.Id);
        fetched.Id.ShouldBe(result.Id);

        var listed = await apiClient.ListAsync();
        listed.Items.ShouldNotBeEmpty();
    }
}
