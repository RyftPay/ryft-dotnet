using RyftDotNet.Common;

namespace RyftDotNet.Disputes
{
    public sealed class DisputeEvidenceTextIdentifier : ConstantValue
    {
        public DisputeEvidenceTextIdentifier(string value) : base(value) { }

        public static readonly DisputeEvidenceTextIdentifier BillingAddress =
            new DisputeEvidenceTextIdentifier("billingAddress");

        public static readonly DisputeEvidenceTextIdentifier ShippingAddress =
            new DisputeEvidenceTextIdentifier("shippingAddress");

        public static readonly DisputeEvidenceTextIdentifier DuplicateTransaction =
            new DisputeEvidenceTextIdentifier("duplicateTransaction");

        public static readonly DisputeEvidenceTextIdentifier UnCategorised =
            new DisputeEvidenceTextIdentifier("uncategorised");
    }
}
