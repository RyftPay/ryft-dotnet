using RyftDotNet.Common;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Accounts
{
    public sealed class AccountDocumentStatusTest
    {
        [Theory, MemberData(nameof(ExpectedValues))]
        public void StaticValues_ShouldReturnExpectedValue(AccountDocumentStatus actual, AccountDocumentStatus expected)
            => actual.ShouldBe(expected);

        public static TheoryData<AccountDocumentStatus, AccountDocumentStatus> ExpectedValues() =>
            new TheoryData<AccountDocumentStatus, AccountDocumentStatus>
            {
                { AccountDocumentStatus.Invalid, new AccountDocumentStatus("Invalid") },
                { AccountDocumentStatus.Pending, new AccountDocumentStatus("Pending") },
                { AccountDocumentStatus.Valid, new AccountDocumentStatus("Valid") }
            };
    }
}
