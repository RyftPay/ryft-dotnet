using System;
using System.Collections.Generic;
using RyftDotNet.Accounts;
using RyftDotNet.Common;
using RyftDotNet.Customers;
using RyftDotNet.Disputes;
using RyftDotNet.PaymentSessions;
using RyftDotNet.PayoutMethods;
using RyftDotNet.Payouts;
using RyftDotNet.Persons;
using RyftDotNet.PlatformFees;
using RyftDotNet.Subscriptions;
using RyftDotNet.Transfers;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Common
{
    public sealed class EventTypeTest
    {
        [Theory, MemberData(nameof(ExpectedValues))]
        public void EventType_ShouldHaveExpectedValue(
            EventType actual,
            string expectedType,
            Type expectedApiObjectType)
            => actual.ShouldSatisfyAllConditions(
                a => a.Value.ShouldBe(expectedType),
                a => a.ApiObjectType.ShouldBe(expectedApiObjectType)
            );

        public static IEnumerable<object[]> ExpectedValues()
        {
            yield return new object[] { EventType.PaymentSessionApproved, "PaymentSession.approved", typeof(PaymentSession) };
            yield return new object[] { EventType.PaymentSessionVoided, "PaymentSession.voided", typeof(PaymentSession) };
            yield return new object[] { EventType.PaymentSessionVoidFailed, "PaymentSession.void_failed", typeof(PaymentSession) };
            yield return new object[] { EventType.PaymentSessionCaptured, "PaymentSession.captured", typeof(PaymentSession) };
            yield return new object[]
            {
                EventType.PaymentSessionCaptureFailed, "PaymentSession.capture_failed", typeof(PaymentSession)
            };
            yield return new object[] { EventType.PaymentSessionDeclined, "PaymentSession.declined", typeof(PaymentSession) };
            yield return new object[] { EventType.PaymentSessionRefunded, "PaymentSession.refunded", typeof(PaymentSession) };
            yield return new object[] { EventType.PaymentSessionRefundFailed, "PaymentSession.refund_failed", typeof(PaymentSession) };
            yield return new object[] { EventType.PayoutCreated, "Payout.created", typeof(Payout) };
            yield return new object[] { EventType.PayoutStatusUpdated, "Payout.status_updated", typeof(Payout) };
            yield return new object[] { EventType.PlatformFeeCreated, "PlatformFee.created", typeof(PlatformFee) };
            yield return new object[] { EventType.PlatformFeeRefunded, "PlatformFee.refunded", typeof(PlatformFee) };
            yield return new object[] { EventType.CustomerCreated, "Customer.created", typeof(Customer) };
            yield return new object[] { EventType.CustomerUpdated, "Customer.updated", typeof(Customer) };
            yield return new object[] { EventType.CustomerDeleted, "Customer.deleted", typeof(Customer) };
            yield return new object[] { EventType.SubscriptionCreated, "Subscription.created", typeof(Subscription) };
            yield return new object[] { EventType.SubscriptionUpdated, "Subscription.updated", typeof(Subscription) };
            yield return new object[] { EventType.SubscriptionPaused, "Subscription.paused", typeof(Subscription) };
            yield return new object[] { EventType.SubscriptionResumed, "Subscription.resumed", typeof(Subscription) };
            yield return new object[] { EventType.SubscriptionCancelled, "Subscription.cancelled", typeof(Subscription) };
            yield return new object[] { EventType.SubscriptionEnded, "Subscription.ended", typeof(Subscription) };
            yield return new object[] { EventType.DisputeCreated, "Dispute.created", typeof(Dispute) };
            yield return new object[] { EventType.DisputeChallenged, "Dispute.challenged", typeof(Dispute) };
            yield return new object[] { EventType.DisputeClosed, "Dispute.closed", typeof(Dispute) };
            yield return new object[] { EventType.AccountCreated, "Account.created", typeof(Account) };
            yield return new object[] { EventType.AccountUpdated, "Account.updated", typeof(Account) };
            yield return new object[] { EventType.PersonCreated, "Person.created", typeof(Person) };
            yield return new object[] { EventType.PersonUpdated, "Person.updated", typeof(Person) };
            yield return new object[] { EventType.PersonDeleted, "Person.deleted", typeof(Person) };
            yield return new object[] { EventType.PayoutMethodCreated, "PayoutMethod.created", typeof(PayoutMethod) };
            yield return new object[] { EventType.PayoutMethodUpdated, "PayoutMethod.updated", typeof(PayoutMethod) };
            yield return new object[] { EventType.PayoutMethodDeleted, "PayoutMethod.deleted", typeof(PayoutMethod) };
            yield return new object[] { EventType.TransferCreated, "Transfer.created", typeof(Transfer) };
            yield return new object[] { EventType.TransferUpdated, "Transfer.updated", typeof(Transfer) };
        }
    }
}
