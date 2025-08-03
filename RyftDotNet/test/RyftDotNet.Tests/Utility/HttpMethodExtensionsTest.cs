using System.Net.Http;
using RyftDotNet.Utility;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Utility
{
    public sealed class HttpMethodExtensionsTest
    {
        [Fact]
        public void Patch_ShouldReturnExpectedValue()
            => HttpMethodExtensions.Patch.ShouldBe(new HttpMethod("PATCH"));
    }
}
