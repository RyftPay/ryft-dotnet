using RyftDotNet.Common;

namespace RyftDotNet.Subscriptions
{
    public sealed class SubscriptionStatus : ConstantValue
    {
        public SubscriptionStatus(string value) : base(value) { }

        public static readonly SubscriptionStatus Pending = new SubscriptionStatus("Pending");
        public static readonly SubscriptionStatus Active = new SubscriptionStatus("Active");
        public static readonly SubscriptionStatus Cancelled = new SubscriptionStatus("Cancelled");
        public static readonly SubscriptionStatus PastDue = new SubscriptionStatus("PastDue");
        public static readonly SubscriptionStatus Ended = new SubscriptionStatus("Ended");
        public static readonly SubscriptionStatus Paused = new SubscriptionStatus("Paused");
    }
}
