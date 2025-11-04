using System;
using System.Collections.Generic;
using System.Text;
using RyftDotNet.PaymentMethods;

namespace RyftDotNet.Customers
{
    public sealed class CustomerPaymentMethods
    {
        public IEnumerable<PaymentMethod> Items { get; set; } = new List<PaymentMethod>();
    }
}
