using RyftDotNet.Common;

namespace RyftDotNet.Disputes
{
    public sealed class DisputeStatus : ConstantValue
    {
        public DisputeStatus(string value) : base(value) { }

        public static readonly DisputeStatus Open = new DisputeStatus("Open");
        public static readonly DisputeStatus Cancelled = new DisputeStatus("Cancelled");
        public static readonly DisputeStatus Accepted = new DisputeStatus("Accepted");
        public static readonly DisputeStatus Challenged = new DisputeStatus("Challenged");
        public static readonly DisputeStatus Lost = new DisputeStatus("Lost");
        public static readonly DisputeStatus Won = new DisputeStatus("Won");
        public static readonly DisputeStatus Expired = new DisputeStatus("Expired");
    }
}
