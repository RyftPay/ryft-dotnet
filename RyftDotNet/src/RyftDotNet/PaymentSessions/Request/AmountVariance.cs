using System.Runtime.Serialization;

namespace RyftDotNet.PaymentSessions.Request
{
    public enum AmountVariance
    {
        [EnumMember(Value = "Fixed")]
        Fixed,

        [EnumMember(Value = "Variable")]
        Variable
    }
}
