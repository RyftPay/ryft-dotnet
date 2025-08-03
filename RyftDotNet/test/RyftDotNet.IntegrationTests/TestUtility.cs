using Xunit.Sdk;

namespace RyftDotNet.IntegrationTests;

internal static class TestUtility
{
    private const string ApiKeyEnvVar = "RYFT_INTEGRATION_TESTS_API_KEY";
    private const string PaymentMethodIdEnvVar = "RYFT_PAYMENT_METHOD_ID";
    private const string CustomerIdEnvVar = "RYFT_CUSTOMER_ID";
    private const string EventIdEnvVar = "RYFT_EVENT_ID";
    private const string HostedAccountIdEnvVar = "RYFT_HOSTED_ACCOUNT_ID";
    private const string NonHostedAccountIdEnvVar = "RYFT_NON_HOSTED_ACCOUNT_ID";
    private const string PlatformFeeIdEnvVar = "RYFT_PLATFORM_FEE_ID";

    internal static readonly string SecretApiKey =
        Environment.GetEnvironmentVariable(ApiKeyEnvVar)
        ?? throw new TestClassException($"Missing {ApiKeyEnvVar} environment variable");

    internal static readonly string ExistingPaymentMethodId =
        Environment.GetEnvironmentVariable(PaymentMethodIdEnvVar)
        ?? throw new TestClassException($"Missing {ApiKeyEnvVar} environment variable");

    internal static readonly string ExistingCustomerId =
        Environment.GetEnvironmentVariable(CustomerIdEnvVar)
        ?? throw new TestClassException($"Missing {ApiKeyEnvVar} environment variable");

    internal static readonly string ExistingEventId
        = Environment.GetEnvironmentVariable(EventIdEnvVar)
          ?? throw new TestClassException($"Missing {ApiKeyEnvVar} environment variable");

    internal static readonly string ExistingHostedAccountId
        = Environment.GetEnvironmentVariable(HostedAccountIdEnvVar)
          ?? throw new TestClassException($"Missing {ApiKeyEnvVar} environment variable");

    internal static readonly string ExistingNonHostedAccountId
        = Environment.GetEnvironmentVariable(NonHostedAccountIdEnvVar)
          ?? throw new TestClassException($"Missing {ApiKeyEnvVar} environment variable");

    internal static readonly string ExistingPlatformFeeId
        = Environment.GetEnvironmentVariable(PlatformFeeIdEnvVar)
          ?? throw new TestClassException($"Missing {ApiKeyEnvVar} environment variable");

    internal static string ResourcePrefix() =>
        $"ryft-dotnet_{DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}";
}
