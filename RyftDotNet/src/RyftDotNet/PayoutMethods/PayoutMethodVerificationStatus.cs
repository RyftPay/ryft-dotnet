using RyftDotNet.Common;

namespace RyftDotNet.PayoutMethods
{
    public sealed class PayoutMethodVerificationStatus : ConstantValue
    {
        public PayoutMethodVerificationStatus(string value) : base(value) { }

        public static readonly PayoutMethodVerificationStatus Unverified = new PayoutMethodVerificationStatus("Unverified");
        public static readonly PayoutMethodVerificationStatus Pending = new PayoutMethodVerificationStatus("Pending");
        public static readonly PayoutMethodVerificationStatus NotSupported = new PayoutMethodVerificationStatus("NotSupported");
        public static readonly PayoutMethodVerificationStatus Verified = new PayoutMethodVerificationStatus("Verified");
        public static readonly PayoutMethodVerificationStatus Rejected = new PayoutMethodVerificationStatus("Rejected");
    }
}
