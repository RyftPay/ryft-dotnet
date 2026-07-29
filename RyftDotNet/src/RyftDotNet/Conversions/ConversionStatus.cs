using RyftDotNet.Common;

namespace RyftDotNet.Conversions
{
    public sealed class ConversionStatus : ConstantValue
    {
        public ConversionStatus(string value) : base(value) { }

        public static readonly ConversionStatus InProgress = new ConversionStatus("InProgress");
        public static readonly ConversionStatus Settled = new ConversionStatus("Settled");
    }
}
