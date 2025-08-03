using RyftDotNet.Common;

namespace RyftDotNet.PaymentSessions.PaymentTransactions
{
    public sealed class PaymentTransactionType : ConstantValue
    {
        public PaymentTransactionType(string value) : base(value) { }

        public static readonly PaymentTransactionType Authorization = new PaymentTransactionType("Authorization");
        public static readonly PaymentTransactionType Void = new PaymentTransactionType("Void");
        public static readonly PaymentTransactionType Capture = new PaymentTransactionType("Capture");
        public static readonly PaymentTransactionType Refund = new PaymentTransactionType("Refund");
        public static readonly PaymentTransactionType Chargeback = new PaymentTransactionType("Chargeback");
        public static readonly PaymentTransactionType ChargebackReversal = new PaymentTransactionType("ChargebackReversal");
    }
}
