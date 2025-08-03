using System;
using RyftDotNet.Accounts;
using RyftDotNet.Customers;
using RyftDotNet.Disputes;
using RyftDotNet.PaymentSessions;
using RyftDotNet.PayoutMethods;
using RyftDotNet.Payouts;
using RyftDotNet.Persons;
using RyftDotNet.PlatformFees;
using RyftDotNet.Subscriptions;
using RyftDotNet.Transfers;
using RyftDotNet.Utility;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Utility
{
    public sealed class EventTypeFactoryTest
    {
        [Fact]
        public void GetApiObjectType_ShouldReturnNull_WhenGivenUnknownValue()
            => EventTypeFactory.GetApiObjectType("unknown").ShouldBeNull();

        [Theory, MemberData(nameof(ExpectedTypes))]
        public void GetApiObjectType_ShouldReturnExpectedType_ForEvent(string eventType, Type expectedType)
            => EventTypeFactory.GetApiObjectType(eventType).ShouldBe(expectedType);

        [Fact]
        public void GetApiObjectType_ShouldBeAbleToHandleNewlyIntroducedEvent()
        {
            /*
             * This test just ensures event types which are added to the API
             * can be mapped still prior to being officially added to the SDK
             */
            const string newEventType = "PaymentSession.brand_new_event";
            EventTypeFactory.GetApiObjectType(newEventType).ShouldBe(typeof(PaymentSession));
        }

        public static TheoryData<string, Type> ExpectedTypes() => new TheoryData<string, Type>
        {
            { "PaymentSession.declined", typeof(PaymentSession) },
            { "PaymentSession.approved", typeof(PaymentSession) },
            { "PaymentSession.voided", typeof(PaymentSession) },
            { "PaymentSession.void_failed", typeof(PaymentSession) },
            { "PaymentSession.captured", typeof(PaymentSession) },
            { "PaymentSession.capture_failed", typeof(PaymentSession) },
            { "PaymentSession.refunded", typeof(PaymentSession) },
            { "PaymentSession.refund_failed", typeof(PaymentSession) },

            { "Payout.created", typeof(Payout) },
            { "Payout.status_updated", typeof(Payout) },

            { "PlatformFee.created", typeof(PlatformFee) },
            { "PlatformFee.refunded", typeof(PlatformFee) },

            { "Customer.created", typeof(Customer) },
            { "Customer.updated", typeof(Customer) },
            { "Customer.deleted", typeof(Customer) },

            { "Subscription.created", typeof(Subscription) },
            { "Subscription.updated", typeof(Subscription) },
            { "Subscription.paused", typeof(Subscription) },
            { "Subscription.resumed", typeof(Subscription) },
            { "Subscription.cancelled", typeof(Subscription) },
            { "Subscription.ended", typeof(Subscription) },

            { "Dispute.created", typeof(Dispute) },
            { "Dispute.challenged", typeof(Dispute) },
            { "Dispute.closed", typeof(Dispute) },

            { "Account.created", typeof(Account) },
            { "Account.updated", typeof(Account) },

            { "Person.created", typeof(Person) },
            { "Person.updated", typeof(Person) },
            { "Person.deleted", typeof(Person) },

            { "PayoutMethod.created", typeof(PayoutMethod) },
            { "PayoutMethod.updated", typeof(PayoutMethod) },
            { "PayoutMethod.deleted", typeof(PayoutMethod) },

            { "Transfer.created", typeof(Transfer) },
            { "Transfer.updated", typeof(Transfer) },
        };
    }
}
