using RyftDotNet.Common;

namespace RyftDotNet.PaymentSessions
{
    public sealed class PaymentType : ConstantValue
    {
        public PaymentType(string value) : base(value) { }

        public static readonly PaymentType Standard = new PaymentType("Standard");
        public static readonly PaymentType Recurring = new PaymentType("Recurring");
        public static readonly PaymentType Unscheduled = new PaymentType("Unscheduled");
    }
}
