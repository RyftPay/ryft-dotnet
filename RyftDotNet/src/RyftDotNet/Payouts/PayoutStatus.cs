using RyftDotNet.Common;

namespace RyftDotNet.Payouts
{
    public sealed class PayoutStatus : ConstantValue
    {
        public PayoutStatus(string value) : base(value) { }

        public static readonly PayoutStatus Completed = new PayoutStatus("Completed");
        public static readonly PayoutStatus Failed = new PayoutStatus("Failed");
        public static readonly PayoutStatus Pending = new PayoutStatus("Pending");
        public static readonly PayoutStatus PendingAccountVerification = new PayoutStatus("PendingAccountVerification");
        public static readonly PayoutStatus PendingTransactionVerification = new PayoutStatus("PendingTransactionVerification");
        public static readonly PayoutStatus PendingPayoutMethodAction = new PayoutStatus("PendingPayoutMethodAction");
        public static readonly PayoutStatus PendingAccountAction = new PayoutStatus("PendingAccountAction");
        public static readonly PayoutStatus InProgress = new PayoutStatus("InProgress");
        public static readonly PayoutStatus Cancelled = new PayoutStatus("Cancelled");
        public static readonly PayoutStatus Expired = new PayoutStatus("Expired");
        public static readonly PayoutStatus Recalled = new PayoutStatus("Recalled");
        public static readonly PayoutStatus Returned = new PayoutStatus("Returned");
    }
}
