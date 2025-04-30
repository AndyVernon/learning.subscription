namespace Subscriptions.API.Models
{
    public class Address
    {
        public Guid Id { get; set; }
        public required string LineOne { get; set; }
        public string? LineTwo { get; set; }
        public required string Postcode { get; set; }
    }
}
