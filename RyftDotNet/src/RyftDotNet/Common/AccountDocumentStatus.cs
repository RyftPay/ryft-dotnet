namespace RyftDotNet.Common
{
    public sealed class AccountDocumentStatus : ConstantValue
    {
        public AccountDocumentStatus(string value) : base(value) { }

        public static readonly AccountDocumentStatus Invalid = new AccountDocumentStatus("Invalid");
        public static readonly AccountDocumentStatus Pending = new AccountDocumentStatus("Pending");
        public static readonly AccountDocumentStatus Valid = new AccountDocumentStatus("Valid");
    }
}
