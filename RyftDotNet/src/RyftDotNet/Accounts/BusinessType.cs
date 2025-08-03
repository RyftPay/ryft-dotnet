using RyftDotNet.Common;

namespace RyftDotNet.Accounts
{
    public sealed class BusinessType : ConstantValue
    {
        public BusinessType(string value) : base(value) { }

        public static readonly BusinessType Corporation = new BusinessType("Corporation");

        public static readonly BusinessType GovernmentEntity = new BusinessType("GovernmentEntity");

        public static readonly BusinessType Charity = new BusinessType("Charity");

        public static readonly BusinessType LimitedPartnership = new BusinessType("LimitedPartnership");

        public static readonly BusinessType PrivateCompany = new BusinessType("PrivateCompany");

        public static readonly BusinessType PublicCompany = new BusinessType("PublicCompany");
    }
}
