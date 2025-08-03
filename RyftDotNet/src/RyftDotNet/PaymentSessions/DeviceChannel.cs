using RyftDotNet.Common;

namespace RyftDotNet.PaymentSessions
{
    public sealed class DeviceChannel : ConstantValue
    {
        public DeviceChannel(string value) : base(value) { }

        public static readonly DeviceChannel Browser = new DeviceChannel("Browser");
        public static readonly DeviceChannel Application = new DeviceChannel("Application");
    }
}
