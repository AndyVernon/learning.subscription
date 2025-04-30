using System.ComponentModel.DataAnnotations;

namespace Subscriptions.API.Models
{
    public class AddSubscriptionRequest
    {
        [Required]
        [MinLength(1)]
        public required string Name { get; set; }
    }
}
