using System;
using System.Collections.Generic;
using System.Linq;
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

namespace RyftDotNet.Utility
{
    internal static class EventTypeFactory
    {
        private static readonly Dictionary<string, Type> EventApiObjectTypeLookup = new Dictionary<string, Type>
        {
            { "Account", typeof(Account) },
            { "Customer", typeof(Customer) },
            { "Dispute", typeof(Dispute) },
            { "PaymentSession", typeof(PaymentSession) },
            { "Payout", typeof(Payout) },
            { "PayoutMethod", typeof(PayoutMethod) },
            { "Person", typeof(Person) },
            { "PlatformFee", typeof(PlatformFee) },
            { "Subscription", typeof(Subscription) },
            { "Transfer", typeof(Transfer) }
        };

        internal static Type? GetApiObjectType(string eventType)
        {
            string rootEventNamespace = eventType.Split('.').FirstOrDefault() ?? string.Empty;
            return EventApiObjectTypeLookup.TryGetValue(rootEventNamespace, out var type) ? type : null;
        }
    }
}
