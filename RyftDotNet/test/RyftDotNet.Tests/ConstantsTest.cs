using Shouldly;
using Xunit;

namespace RyftDotNet.Tests
{
    public sealed class ConstantsTest
    {
        [Theory, MemberData(nameof(ExpectedValues))]
        public void Constants_ShouldHaveExpectedValue(string value, string expected)
            => value.ShouldBe(expected);

        public static TheoryData<string, string> ExpectedValues() => new TheoryData<string, string>
        {
            { Constants.Version, "1.2.0" },
            { Constants.UserAgentPrefix, "ryft-dotnet/" },
            { Constants.SandboxApiUrl, "https://sandbox-api.ryftpay.com" },
            { Constants.ProductionApiUrl, "https://api.ryftpay.com" },
            { Constants.ApiVersions.One, "v1" }
        };
    }
}
