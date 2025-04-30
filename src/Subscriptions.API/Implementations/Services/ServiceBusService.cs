using Azure.Messaging.ServiceBus;
using Subscriptions.API.Interfaces;
using Subscriptions.API.Models;
using System.Text.Json;

namespace Subscriptions.API.Implementations.Services
{
    public class ServiceBusService : ISubscriptionService
    {
        private readonly ServiceBusClient _serviceBusClient;
        private readonly AzureServiceBusSettings _settings;

        public ServiceBusService(ServiceBusClient serviceBusClient, AzureServiceBusSettings settings)
        {
            _serviceBusClient = serviceBusClient;
            _settings = settings;
        }

        public async Task<AddSubscriptionResponse> AddSubscription(AddSubscriptionRequest request)
        {
            if (string.IsNullOrWhiteSpace(request?.Name))
            {
                throw new ArgumentException("Name cannot be null or empty.", nameof(request.Name));
            }

            var message = new
            {
                Id = Guid.NewGuid(),
                Name = request.Name
            };

            var messageBody = JsonSerializer.Serialize(message);

            var sender = _serviceBusClient.CreateSender(_settings.Queues.Add);

            await sender.SendMessageAsync(new ServiceBusMessage(messageBody));

            return new AddSubscriptionResponse
            {
                SubscriptionId = message.Id
            };
        }
    }
}
