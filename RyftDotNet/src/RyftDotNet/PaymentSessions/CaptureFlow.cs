using RyftDotNet.Common;

namespace RyftDotNet.PaymentSessions
{
    public sealed class CaptureFlow : ConstantValue
    {
        public CaptureFlow(string value) : base(value) { }

        public static readonly CaptureFlow Manual = new CaptureFlow("Manual");
        public static readonly CaptureFlow Automatic = new CaptureFlow("Automatic");
    }
}
