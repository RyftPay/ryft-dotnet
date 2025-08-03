namespace RyftDotNet.Common
{
    public sealed class AccountDocumentCategory : ConstantValue
    {
        public AccountDocumentCategory(string value) : base(value) { }

        public static readonly AccountDocumentCategory Authorization = new AccountDocumentCategory("Authorization");
        public static readonly AccountDocumentCategory ProofOfAddress = new AccountDocumentCategory("ProofOfAddress");
        public static readonly AccountDocumentCategory ProofOfBusiness = new AccountDocumentCategory("ProofOfBusiness");
        public static readonly AccountDocumentCategory ProofOfIdentity = new AccountDocumentCategory("ProofOfIdentity");
    }
}
