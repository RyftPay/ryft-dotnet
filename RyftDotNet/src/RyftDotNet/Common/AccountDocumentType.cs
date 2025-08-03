namespace RyftDotNet.Common
{
    public sealed class AccountDocumentType : ConstantValue
    {
        public AccountDocumentType(string value) : base(value) { }

        public static readonly AccountDocumentType BankStatement = new AccountDocumentType("BankStatement");
        public static readonly AccountDocumentType BusinessRegistration = new AccountDocumentType("BusinessRegistration");
        public static readonly AccountDocumentType CreditCardStatement = new AccountDocumentType("CreditCardStatement");
        public static readonly AccountDocumentType DriversLicense = new AccountDocumentType("DriversLicense");
        public static readonly AccountDocumentType LetterOfAuthorization = new AccountDocumentType("LetterOfAuthorization");
        public static readonly AccountDocumentType NationalId = new AccountDocumentType("NationalId");
        public static readonly AccountDocumentType OfficialGovernmentLetter =
            new AccountDocumentType("OfficialGovernmentLetter");
        public static readonly AccountDocumentType Passport = new AccountDocumentType("Passport");
        public static readonly AccountDocumentType PropertyTaxAssessment =
            new AccountDocumentType("PropertyTaxAssessment");
        public static readonly AccountDocumentType TaxReturn = new AccountDocumentType("TaxReturn");
        public static readonly AccountDocumentType UtilityBill = new AccountDocumentType("UtilityBill");
    }
}
