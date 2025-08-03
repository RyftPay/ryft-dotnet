using System;
using System.Collections.Generic;
using System.IO;
using RyftDotNet.Customers;
using RyftDotNet.Utility;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Customers
{
    public sealed class CustomerTest
    {
        [Fact]
        public void FromJson_ShouldReturnExpectedValue_WhenMinimumRequiredFieldsReturned()
        {
            string json = File.ReadAllText("assets/customers/response-min.json");
            JsonUtility.Deserialize<Customer>(json).ShouldBe(new Customer(
                "cus_01JW5YE0Z28N23C3HHG34JHZ0G",
                "test@ryftpay.com",
                DateTimeOffset.FromUnixTimeSeconds(1716716232)
            ));
        }

        [Fact]
        public void FromJson_ShouldReturnExpectedValue_WhenAllFieldsReturned()
        {
            string json = File.ReadAllText("assets/customers/response-full.json");
            JsonUtility.Deserialize<Customer>(json).ShouldBe(new Customer(
                "cus_01JW5YE0Z28N23C3HHG34JHZ0G",
                "test@ryftpay.com",
                DateTimeOffset.FromUnixTimeSeconds(1716716232),
                "Jeff",
                "Bridges",
                "+447900000000",
                "+447900000000",
                "pmt_01G0EYVFR02KBBVE2YWQ8AKMGJ",
                new Dictionary<string, string>
                {
                    ["customerId"] = "1",
                    ["registered"] = "123"
                }
            ));
        }
    }
}
