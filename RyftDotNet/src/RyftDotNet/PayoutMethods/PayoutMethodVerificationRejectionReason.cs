using RyftDotNet.Common;

namespace RyftDotNet.PayoutMethods
{
    public sealed class PayoutMethodVerificationRejectionReason : ConstantValue
    {
        public PayoutMethodVerificationRejectionReason(string value) : base(value) { }

        public static readonly PayoutMethodVerificationRejectionReason NameMismatch = new PayoutMethodVerificationRejectionReason("NameMismatch");
        public static readonly PayoutMethodVerificationRejectionReason CheckUnavailable = new PayoutMethodVerificationRejectionReason("CheckUnavailable");
    }
}
