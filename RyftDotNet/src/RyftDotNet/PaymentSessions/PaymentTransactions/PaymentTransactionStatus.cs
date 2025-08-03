using RyftDotNet.Common;

namespace RyftDotNet.PaymentSessions.PaymentTransactions
{
    public sealed class PaymentTransactionStatus : ConstantValue
    {
        public PaymentTransactionStatus(string value) : base(value) { }

        public static readonly PaymentTransactionStatus Pending = new PaymentTransactionStatus("Pending");
        public static readonly PaymentTransactionStatus Failed = new PaymentTransactionStatus("Failed");
        public static readonly PaymentTransactionStatus Succeeded = new PaymentTransactionStatus("Succeeded");
    }
}
