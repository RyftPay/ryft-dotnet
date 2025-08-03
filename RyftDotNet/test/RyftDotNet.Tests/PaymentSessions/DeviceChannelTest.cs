using RyftDotNet.PaymentSessions;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.PaymentSessions
{
    public sealed class DeviceChannelTest
    {
        [Theory, MemberData(nameof(ExpectedValues))]
        public void StaticValues_ShouldReturnExpectedValue(DeviceChannel actual, DeviceChannel expected)
            => actual.ShouldBe(expected);

        public static TheoryData<DeviceChannel, DeviceChannel> ExpectedValues() =>
            new TheoryData<DeviceChannel, DeviceChannel>
            {
                { DeviceChannel.Browser, new DeviceChannel("Browser") },
                { DeviceChannel.Application, new DeviceChannel("Application") }
            };
    }
}
