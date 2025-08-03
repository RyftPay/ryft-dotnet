using RyftDotNet.Common;

namespace RyftDotNet.PaymentSessions
{
    public sealed class AuthorizationType : ConstantValue
    {
        public AuthorizationType(string value) : base(value) { }

        public static readonly AuthorizationType PreAuth = new AuthorizationType("PreAuth");
        public static readonly AuthorizationType FinalAuth = new AuthorizationType("FinalAuth");
    }
}
