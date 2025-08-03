using RyftDotNet.Common;

namespace RyftDotNet.Payouts
{
    public sealed class PayoutScheme : ConstantValue
    {
        public PayoutScheme(string value) : base(value) { }

        public static readonly PayoutScheme Ach = new PayoutScheme("Ach");
        public static readonly PayoutScheme Bacs = new PayoutScheme("Bacs");
        public static readonly PayoutScheme Chaps = new PayoutScheme("Chaps");
        public static readonly PayoutScheme Fps = new PayoutScheme("Fps");
        public static readonly PayoutScheme Swift = new PayoutScheme("Swift");
        public static readonly PayoutScheme Sepa = new PayoutScheme("Sepa");
        public static readonly PayoutScheme SepaInstant = new PayoutScheme("SepaInstant");
    }
}
