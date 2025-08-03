using RyftDotNet.Common;

namespace RyftDotNet.PaymentSessions
{
    public sealed class CaptureType : ConstantValue
    {
        public CaptureType(string value) : base(value) { }

        public static readonly CaptureType Final = new CaptureType("Final");
        public static readonly CaptureType NotFinal = new CaptureType("NotFinal");
    }
}
