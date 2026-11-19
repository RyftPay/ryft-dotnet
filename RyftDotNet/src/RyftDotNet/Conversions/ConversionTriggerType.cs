using RyftDotNet.Common;

namespace RyftDotNet.Conversions
{
    public sealed class ConversionTriggerType : ConstantValue
    {
        public ConversionTriggerType(string value) : base(value) { }

        public static readonly ConversionTriggerType Manual = new ConversionTriggerType("Manual");
        public static readonly ConversionTriggerType Automatic = new ConversionTriggerType("Automatic");
    }
}
