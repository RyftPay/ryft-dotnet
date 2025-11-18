using System.Text.Json.Serialization;

namespace RyftDotNet.InPerson.Orders
{
    public sealed class InPersonOrderCustomer
    {
        [JsonPropertyName("email")]
        public string Email { get; }

        [JsonPropertyName("firstName")]
        public string? FirstName { get; }

        [JsonPropertyName("lastName")]
        public string? LastName { get; }

        public InPersonOrderCustomer(
            string email,
            string? firstName,
            string? lastName)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
