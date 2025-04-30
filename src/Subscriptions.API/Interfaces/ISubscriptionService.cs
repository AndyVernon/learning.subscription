using Subscriptions.API.Models;

namespace Subscriptions.API.Interfaces
{
    public interface ISubscriptionService
    {
        Task<AddSubscriptionResponse> AddSubscription(AddSubscriptionRequest request);
    }
}
