using RyftDotNet.Common;

namespace RyftDotNet.Disputes
{
    public sealed class DisputeCategory : ConstantValue
    {
        public DisputeCategory(string value) : base(value) { }

        public static readonly DisputeCategory Fraudulent = new DisputeCategory("Fraudulent");
        public static readonly DisputeCategory Authorization = new DisputeCategory("Authorization");
        public static readonly DisputeCategory ProcessingError = new DisputeCategory("ProcessingError");
        public static readonly DisputeCategory CardholderDispute = new DisputeCategory("CardholderDispute");
        public static readonly DisputeCategory General = new DisputeCategory("General");
    }
}
