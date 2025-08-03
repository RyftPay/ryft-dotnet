using RyftDotNet.Common;

namespace RyftDotNet.Accounts
{
    public sealed class AccountCapabilityStatus : ConstantValue
    {
        public AccountCapabilityStatus(string value) : base(value) { }

        public static readonly AccountCapabilityStatus NotRequested = new AccountCapabilityStatus("NotRequested");
        public static readonly AccountCapabilityStatus Pending = new AccountCapabilityStatus("Pending");
        public static readonly AccountCapabilityStatus Disabled = new AccountCapabilityStatus("Disabled");
        public static readonly AccountCapabilityStatus Enabled = new AccountCapabilityStatus("Enabled");
    }
}
