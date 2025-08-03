namespace RyftDotNet.Common
{
    public sealed class PayoutScheduleType : ConstantValue
    {
        public PayoutScheduleType(string value) : base(value) { }

        public static readonly PayoutScheduleType Automatic = new PayoutScheduleType("Automatic");
        public static readonly PayoutScheduleType Manual = new PayoutScheduleType("Manual");
    }
}
