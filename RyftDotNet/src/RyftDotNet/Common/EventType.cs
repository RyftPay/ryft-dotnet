using System;
using RyftDotNet.Utility;

namespace RyftDotNet.Common
{
    public sealed class EventType : ConstantValue
    {
        internal Type? ApiObjectType { get; private set; }

        public EventType(string value) : base(value)
        {
            ApiObjectType = EventTypeFactory.GetApiObjectType(value);
        }

        public static readonly EventType PaymentSessionDeclined = new EventType("PaymentSession.declined");
        public static readonly EventType PaymentSessionApproved = new EventType("PaymentSession.approved");
        public static readonly EventType PaymentSessionVoided = new EventType("PaymentSession.voided");
        public static readonly EventType PaymentSessionVoidFailed = new EventType("PaymentSession.void_failed");
        public static readonly EventType PaymentSessionCaptured = new EventType("PaymentSession.captured");
        public static readonly EventType PaymentSessionCaptureFailed = new EventType("PaymentSession.capture_failed");
        public static readonly EventType PaymentSessionRefunded = new EventType("PaymentSession.refunded");
        public static readonly EventType PaymentSessionRefundFailed = new EventType("PaymentSession.refund_failed");
        public static readonly EventType PayoutCreated = new EventType("Payout.created");
        public static readonly EventType PayoutStatusUpdated = new EventType("Payout.status_updated");
        public static readonly EventType PlatformFeeCreated = new EventType("PlatformFee.created");
        public static readonly EventType PlatformFeeRefunded = new EventType("PlatformFee.refunded");
        public static readonly EventType CustomerCreated = new EventType("Customer.created");
        public static readonly EventType CustomerUpdated = new EventType("Customer.updated");
        public static readonly EventType CustomerDeleted = new EventType("Customer.deleted");
        public static readonly EventType SubscriptionCreated = new EventType("Subscription.created");
        public static readonly EventType SubscriptionUpdated = new EventType("Subscription.updated");
        public static readonly EventType SubscriptionPaused = new EventType("Subscription.paused");
        public static readonly EventType SubscriptionResumed = new EventType("Subscription.resumed");
        public static readonly EventType SubscriptionCancelled = new EventType("Subscription.cancelled");
        public static readonly EventType SubscriptionEnded = new EventType("Subscription.ended");
        public static readonly EventType DisputeCreated = new EventType("Dispute.created");
        public static readonly EventType DisputeChallenged = new EventType("Dispute.challenged");
        public static readonly EventType DisputeClosed = new EventType("Dispute.closed");
        public static readonly EventType AccountCreated = new EventType("Account.created");
        public static readonly EventType AccountUpdated = new EventType("Account.updated");
        public static readonly EventType PersonCreated = new EventType("Person.created");
        public static readonly EventType PersonUpdated = new EventType("Person.updated");
        public static readonly EventType PersonDeleted = new EventType("Person.deleted");
        public static readonly EventType PayoutMethodCreated = new EventType("PayoutMethod.created");
        public static readonly EventType PayoutMethodUpdated = new EventType("PayoutMethod.updated");
        public static readonly EventType PayoutMethodDeleted = new EventType("PayoutMethod.deleted");
        public static readonly EventType TransferCreated = new EventType("Transfer.created");
        public static readonly EventType TransferUpdated = new EventType("Transfer.updated");
    }
}
