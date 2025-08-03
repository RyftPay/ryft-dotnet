using RyftDotNet.Common;

namespace RyftDotNet.PaymentSessions
{
    public sealed class PaymentSessionStatus : ConstantValue
    {
        public PaymentSessionStatus(string value) : base(value) { }

        public static readonly PaymentSessionStatus PendingPayment = new PaymentSessionStatus("PendingPayment");
        public static readonly PaymentSessionStatus PendingAction = new PaymentSessionStatus("PendingAction");
        public static readonly PaymentSessionStatus Processing = new PaymentSessionStatus("Processing");
        public static readonly PaymentSessionStatus Approved = new PaymentSessionStatus("Approved");
        public static readonly PaymentSessionStatus Captured = new PaymentSessionStatus("Captured");
        public static readonly PaymentSessionStatus Voided = new PaymentSessionStatus("Voided");
    }
}
