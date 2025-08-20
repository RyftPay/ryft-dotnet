using RyftDotNet.Common;

namespace RyftDotNet.PaymentSessions
{
    public sealed class AmountVariance : ConstantValue
    {
        public AmountVariance(string value) : base(value) { }

        public static readonly AmountVariance Fixed = new AmountVariance("Fixed");
        public static readonly AmountVariance Variable = new AmountVariance("Variable");
    }
}
