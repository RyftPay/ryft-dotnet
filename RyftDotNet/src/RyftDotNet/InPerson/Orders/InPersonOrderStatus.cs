namespace RyftDotNet.InPerson.Orders
{
    public sealed class InPersonOrderStatus : Common.ConstantValue
    {
        public InPersonOrderStatus(string value) : base(value) { }

        public static readonly InPersonOrderStatus AwaitingPayment = new InPersonOrderStatus("AwaitingPayment");
        public static readonly InPersonOrderStatus ReadyToShip = new InPersonOrderStatus("ReadyToShip");
        public static readonly InPersonOrderStatus Shipped = new InPersonOrderStatus("Shipped");
        public static readonly InPersonOrderStatus Cancelled = new InPersonOrderStatus("Cancelled");
    }
}