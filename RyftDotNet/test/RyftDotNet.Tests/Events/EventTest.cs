using System;
using System.Collections.Generic;
using System.IO;
using RyftDotNet.Common;
using RyftDotNet.Customers;
using RyftDotNet.Events;
using RyftDotNet.Utility;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Events
{
    public sealed class EventTest
    {
        [Fact]
        public void FromJson_ShouldReturnExpectedValue()
        {
            string json = File.ReadAllText("assets/events/customer-created-event.json");
            var @event = JsonUtility.Deserialize<Event>(json);
            @event.ShouldBe(new Event(
                "ev_01FGNPAY1DB5TKPB35M1MNT6PN",
                EventType.CustomerCreated,
                new EventData(new Customer(
                    "cus_01JW5YE0Z28N23C3HHG34JHZ0G",
                    "test@ryftpay.com",
                    DateTimeOffset.FromUnixTimeSeconds(1716716232),
                    "Jeff",
                    "Bridges",
                    "+447900000000",
                    "+447900000000",
                    "pmt_01G0EYVFR02KBBVE2YWQ8AKMGJ",
                    new Dictionary<string, string> { ["customerId"] = "1", ["registered"] = "123" }
                )),
                new List<EventEndpoint>
                {
                    new EventEndpoint(
                        "wh_31fba123-0fef-41d6-92ad-fd7089f49f8a",
                        true,
                        2
                    )
                },
                "ac_b83f2653-06d7-44a9-a548-5825e8186004",
                DateTimeOffset.FromUnixTimeSeconds(1570989538)
            ));
        }

        [Fact]
        public void FromJson_ShouldReturnExpectedValue_WhenNoEndpointsInResponse()
        {
            string json = File.ReadAllText("assets/events/customer-created-event-no-endpoints.json");
            var @event = JsonUtility.Deserialize<Event>(json);
            @event.ShouldBe(new Event(
                "ev_01FGNPAY1DB5TKPB35M1MNT6PN",
                EventType.CustomerCreated,
                new EventData(new Customer(
                    "cus_01JW5YE0Z28N23C3HHG34JHZ0G",
                    "test@ryftpay.com",
                    DateTimeOffset.FromUnixTimeSeconds(1716716232),
                    "Jeff",
                    "Bridges",
                    "+447900000000",
                    "+447900000000",
                    "pmt_01G0EYVFR02KBBVE2YWQ8AKMGJ",
                    new Dictionary<string, string> { ["customerId"] = "1", ["registered"] = "123" }
                )),
                new List<EventEndpoint>(),
                "ac_b83f2653-06d7-44a9-a548-5825e8186004",
                DateTimeOffset.FromUnixTimeSeconds(1570989538)
            ));
        }

        [Fact]
        public void FromJson_ShouldReturnExpectedValue_WhenNoAccountIdInResponse()
        {
            string json = File.ReadAllText("assets/events/customer-created-event-no-account.json");
            var @event = JsonUtility.Deserialize<Event>(json);
            @event.ShouldBe(new Event(
                "ev_01FGNPAY1DB5TKPB35M1MNT6PN",
                EventType.CustomerCreated,
                new EventData(new Customer(
                    "cus_01JW5YE0Z28N23C3HHG34JHZ0G",
                    "test@ryftpay.com",
                    DateTimeOffset.FromUnixTimeSeconds(1716716232),
                    "Jeff",
                    "Bridges",
                    "+447900000000",
                    "+447900000000",
                    "pmt_01G0EYVFR02KBBVE2YWQ8AKMGJ",
                    new Dictionary<string, string> { ["customerId"] = "1", ["registered"] = "123" }
                )),
                new List<EventEndpoint>
                {
                    new EventEndpoint(
                        "wh_31fba123-0fef-41d6-92ad-fd7089f49f8a",
                        true,
                        2
                    )
                },
                null,
                DateTimeOffset.FromUnixTimeSeconds(1570989538)
            ));
        }

        [Fact]
        public void EventDataObject_ShouldBeConvertableToApiResponse()
        {
            string json = File.ReadAllText("assets/events/customer-created-event.json");
            var @event = JsonUtility.Deserialize<Event>(json)!;
            var customer = @event.Data.Object as Customer;
            customer.ShouldNotBeNull();
        }
    }
}
