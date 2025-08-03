using System;
using RyftDotNet.Client;
using RyftDotNet.Utility;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Utility
{
    public sealed class UtilitiesTest
    {
        [Theory,
         InlineData("sk_sandbox_1234", Constants.SandboxApiUrl),
         InlineData("sk_1234", Constants.ProductionApiUrl)]
        public void DetermineBaseUri_ShouldReturnExpectedUri_BasedOnApiKey(string apiKey, string expected)
            => Utilities.DetermineBaseUri(null, null, apiKey)
                .ShouldBe(new Uri(expected));

        [Fact]
        public void DetermineBaseUrl_ShouldReturnExpectedUri_BasedOnClientRequestSettings()
            => Utilities.DetermineBaseUri(
                new ClientRequestSettings { BaseUri = new Uri("https://localhost:9000") },
                null,
                "sk_sandbox_1234"
            ).ShouldBe(new Uri("https://localhost:9000"));

        [Fact]
        public void DetermineBaseUrl_ShouldReturnExpectedUri_BasedOnPerRequestSettings()
            => Utilities.DetermineBaseUri(
                new ClientRequestSettings { BaseUri = new Uri("https://localhost:9000") },
                new ClientRequestSettings { BaseUri = new Uri("https://localhost:9001") },
                "sk_sandbox_1234"
            ).ShouldBe(new Uri("https://localhost:9001"));

        [Fact]
        public void DetermineBaseUrl_ShouldReturnExpectedValue_WhenNoVersionSpecifiedOnRequestSettings()
            => Utilities.DetermineApiVersion(null, null)
                .ShouldBe(Constants.ApiVersions.One);

        [Fact]
        public void DetermineBaseUrl_ShouldReturnExpectedValue_WhenVersionSpecifiedOnClientRequestSettings()
            => Utilities.DetermineApiVersion(
                new ClientRequestSettings { Version = "v2" },
                null
            ).ShouldBe("v2");

        [Fact]
        public void DetermineBaseUrl_ShouldReturnExpectedValue_WhenVersionSpecifiedOnPerRequestSettings()
            => Utilities.DetermineApiVersion(
                new ClientRequestSettings { Version = "v2" },
                new ClientRequestSettings { Version = "v3" }
            ).ShouldBe("v3");
    }
}
