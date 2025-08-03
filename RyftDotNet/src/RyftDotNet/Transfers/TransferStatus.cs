using RyftDotNet.Common;

namespace RyftDotNet.Transfers
{
    public sealed class TransferStatus : ConstantValue
    {
        public TransferStatus(string value) : base(value) { }

        public static readonly TransferStatus Pending = new TransferStatus("Pending");
        public static readonly TransferStatus Declined = new TransferStatus("Declined");
        public static readonly TransferStatus Completed = new TransferStatus("Completed");
    }
}
