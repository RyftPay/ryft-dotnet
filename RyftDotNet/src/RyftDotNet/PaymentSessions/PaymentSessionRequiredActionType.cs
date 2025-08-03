using RyftDotNet.Common;

namespace RyftDotNet.PaymentSessions
{
    public sealed class PaymentSessionRequiredActionType : ConstantValue
    {
        public PaymentSessionRequiredActionType(string value) : base(value) { }

        public static readonly PaymentSessionRequiredActionType Identify =
            new PaymentSessionRequiredActionType("Identify");

        public static readonly PaymentSessionRequiredActionType Challenge =
            new PaymentSessionRequiredActionType("Challenge");
    }
}
