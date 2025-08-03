using RyftDotNet.Accounts;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Accounts
{
    public sealed class BusinessTypeTest
    {
        [Theory, MemberData(nameof(ExpectedValues))]
        public void StaticValues_ShouldReturnExpectedValue(BusinessType actual, BusinessType expected)
            => actual.ShouldBe(expected);

        public static TheoryData<BusinessType, BusinessType> ExpectedValues() =>
            new TheoryData<BusinessType, BusinessType>
            {
                { BusinessType.Corporation, new BusinessType("Corporation") },
                { BusinessType.GovernmentEntity, new BusinessType("GovernmentEntity") },
                { BusinessType.Charity, new BusinessType("Charity") },
                { BusinessType.LimitedPartnership, new BusinessType("LimitedPartnership") },
                { BusinessType.PrivateCompany, new BusinessType("PrivateCompany") },
                { BusinessType.PublicCompany, new BusinessType("PublicCompany") }
            };
    }
}
