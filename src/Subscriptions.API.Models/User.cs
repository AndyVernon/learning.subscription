namespace Subscriptions.API.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required Address Address { get; set; }
    }
}
