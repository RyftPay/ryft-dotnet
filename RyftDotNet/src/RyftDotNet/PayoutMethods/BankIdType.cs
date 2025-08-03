using RyftDotNet.Common;

namespace RyftDotNet.PayoutMethods
{
    public sealed class BankIdType : ConstantValue
    {
        public BankIdType(string value) : base(value) { }

        public static readonly BankIdType RoutingNumber = new BankIdType("RoutingNumber");
        public static readonly BankIdType SortCode = new BankIdType("SortCode");
    }
}
