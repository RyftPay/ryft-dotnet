using RyftDotNet.Common;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Common
{
    public sealed class AccountDocumentTypeTest
    {
        [Theory, MemberData(nameof(ExpectedValues))]
        public void StaticValues_ShouldReturnExpectedValue(AccountDocumentType actual, AccountDocumentType expected)
            => actual.ShouldBe(expected);

        public static TheoryData<AccountDocumentType, AccountDocumentType> ExpectedValues() =>
            new TheoryData<AccountDocumentType, AccountDocumentType>
            {
                { AccountDocumentType.BankStatement, new AccountDocumentType("BankStatement") },
                { AccountDocumentType.BusinessRegistration, new AccountDocumentType("BusinessRegistration") },
                { AccountDocumentType.CreditCardStatement, new AccountDocumentType("CreditCardStatement") },
                { AccountDocumentType.DriversLicense, new AccountDocumentType("DriversLicense") },
                { AccountDocumentType.LetterOfAuthorization, new AccountDocumentType("LetterOfAuthorization") },
                { AccountDocumentType.NationalId, new AccountDocumentType("NationalId") },
                {
                    AccountDocumentType.OfficialGovernmentLetter,
                    new AccountDocumentType("OfficialGovernmentLetter")
                },
                { AccountDocumentType.Passport, new AccountDocumentType("Passport") },
                { AccountDocumentType.PropertyTaxAssessment, new AccountDocumentType("PropertyTaxAssessment") },
                { AccountDocumentType.TaxReturn, new AccountDocumentType("TaxReturn") },
                { AccountDocumentType.UtilityBill, new AccountDocumentType("UtilityBill") }
            };
    }
}
