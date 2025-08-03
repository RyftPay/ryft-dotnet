using System.Net.Http;
using RyftDotNet.Client;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Client
{
    public sealed class HttpRequestMessageExtensionsTest
    {
        [Theory,
         InlineData(null),
         InlineData(""),
         InlineData("  ")]
        public void AddHeader_ShouldNotAddHeader_WhenNullOrEmpty(string? value)
        {
            var requestMessage = new HttpRequestMessage();
            requestMessage.AddHeader("Authorization", value);
            requestMessage.Headers.ShouldNotContain(e => e.Key == "Authorization");
        }

        [Fact]
        public void AddHeader_ShouldAdHeader_WhenNotNullOrEmpty()
        {
            var requestMessage = new HttpRequestMessage();
            requestMessage.AddHeader("Authorization", "sk_sandbox_123");
            requestMessage.Headers.ShouldContain(e => e.Key == "Authorization");
        }
    }
}
