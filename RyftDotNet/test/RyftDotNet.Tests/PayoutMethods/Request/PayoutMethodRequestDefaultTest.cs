using RyftDotNet.PayoutMethods.Request;
using RyftDotNet.Utility;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.PayoutMethods.Request
{
    public sealed class PayoutMethodRequestDefaultTest
    {
        [Fact]
        public void UpdateToJson_ShouldIncludeDefault_WhenNominatingDefault()
            => JsonUtility.Serialize(new UpdatePayoutMethodRequest { Default = true })
                .ShouldBe("{\"default\":true}");

        [Fact]
        public void UpdateToJson_ShouldOmitDefault_WhenNotSet()
            => JsonUtility.Serialize(new UpdatePayoutMethodRequest { DisplayName = "My new name" })
                .ShouldBe("{\"displayName\":\"My new name\"}");

        [Fact]
        public void CreateToJson_ShouldIncludeDefault_WhenNominatingDefault()
        {
            var request = TestData.CreatePayoutMethodRequest();
            request.Default = true;
            JsonUtility.Serialize(request).ShouldContain("\"default\":true");
        }

        [Fact]
        public void CreateToJson_ShouldOmitDefault_WhenNotSet()
            => JsonUtility.Serialize(TestData.CreatePayoutMethodRequest()).ShouldNotContain("default");
    }
}
