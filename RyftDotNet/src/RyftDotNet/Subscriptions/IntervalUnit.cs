using RyftDotNet.Common;

namespace RyftDotNet.Subscriptions
{
    public sealed class IntervalUnit : ConstantValue
    {
        public IntervalUnit(string value) : base(value) { }

        public static readonly IntervalUnit Days = new IntervalUnit("Days");
        public static readonly IntervalUnit Months = new IntervalUnit("Months");

        public static implicit operator string(IntervalUnit intervalUnit) => intervalUnit.Value;
        public static explicit operator IntervalUnit(string value) => new IntervalUnit(value);
    }
}
