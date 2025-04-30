namespace Subscriptions.API.Models
{
    public class Subscription
    {
        public Guid Id { get; set; }
        public required User User { get; set; }
    }
}
