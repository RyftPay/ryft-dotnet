using RyftDotNet.PaymentSessions;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.PaymentSessions
{
    public sealed class AuthorizationTypeTest
    {
        [Theory, MemberData(nameof(ExpectedValues))]
        public void StaticValues_ShouldReturnExpectedValue(AuthorizationType actual, AuthorizationType expected)
            => actual.ShouldBe(expected);

        public static TheoryData<AuthorizationType, AuthorizationType> ExpectedValues() =>
            new TheoryData<AuthorizationType, AuthorizationType>
            {
                { AuthorizationType.PreAuth, new AuthorizationType("PreAuth") },
                { AuthorizationType.FinalAuth, new AuthorizationType("FinalAuth") }
            };
    }
}
