using RyftDotNet.Utility;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Utility
{
    public sealed class ValidationUtilityTest
    {
        [Theory, MemberData(nameof(ExpectedIsValidResults))]
        public void IsValidAccountId_ShouldReturnExpectedResult(string accountId, bool expected)
            => accountId.IsValidAccountId().ShouldBe(expected);

        public static TheoryData<string, bool> ExpectedIsValidResults() =>
            new TheoryData<string, bool>
            {
                { "1234", false },
                { "ac_", false },
                { "ac_1234", false },
                { "ac_98cc2960-9571-4b92-8b42", false },
                { "ac_98cc2960-9571-4b92-8b42-9cbb846f3a5", false },
                { "ab_98cc2960-9571-4b92-8b42-9cbb846f3a5c", false },
                { "ac_6075e73e-90e7-43bb-8d9d-3b502c071ced", true },
                { "ac_98cc2960-9571-4b92-8b42-9cbb846f3a5c", true },
                { "ac_6075e73e-90e7-43bb-8d9d-3b502c071ced_98cc2960-9571-4b92-8b42-9cbb846f3a5c", false }
            };
    }
}
