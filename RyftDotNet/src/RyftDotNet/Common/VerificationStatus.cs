namespace RyftDotNet.Common
{
    public sealed class VerificationStatus : ConstantValue
    {
        public VerificationStatus(string value) : base(value) { }

        public static VerificationStatus NotRequired = new VerificationStatus("NotRequired");
        public static VerificationStatus Required = new VerificationStatus("Required");
        public static VerificationStatus PendingVerification = new VerificationStatus("PendingVerification");
        public static VerificationStatus Verified = new VerificationStatus("Verified");
    }
}
