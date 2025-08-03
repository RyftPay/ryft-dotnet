using RyftDotNet.Common;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Accounts
{
    public sealed class AccountDocumentCategoryTest
    {
        [Theory, MemberData(nameof(ExpectedValues))]
        public void StaticValues_ShouldReturnExpectedValue(AccountDocumentCategory actual, AccountDocumentCategory expected)
            => actual.ShouldBe(expected);

        public static TheoryData<AccountDocumentCategory, AccountDocumentCategory> ExpectedValues() =>
            new TheoryData<AccountDocumentCategory, AccountDocumentCategory>
            {
                { AccountDocumentCategory.Authorization, new AccountDocumentCategory("Authorization") },
                { AccountDocumentCategory.ProofOfAddress, new AccountDocumentCategory("ProofOfAddress") },
                { AccountDocumentCategory.ProofOfBusiness, new AccountDocumentCategory("ProofOfBusiness") },
                { AccountDocumentCategory.ProofOfIdentity, new AccountDocumentCategory("ProofOfIdentity") }
            };
    }
}
