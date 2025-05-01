using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Subscriptions.FunctionApps.Models;
using System.Text.Json;

namespace Subscriptions.FunctionApps
{
    public class AddSubscriptionToDatabase
    {
        private readonly ILogger _logger;

        public AddSubscriptionToDatabase(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<AddSubscriptionToDatabase>();
        }

        [Function("AddSubscriptionToDatabase")]
        [CosmosDBOutput(
            databaseName: "SubscriptionsDB",
            containerName: "Subscriptions",
            Connection = "CosmosDbConnectionString")]
        public Subscription? Run(
            [QueueTrigger(
            "customer-subscriptions", 
            Connection = "AzureWebJobsStorage")] string queueItem)
        {
            _logger.LogInformation($"Received queue message: {queueItem}");

            var subscription = JsonSerializer.Deserialize<Subscription>(queueItem);

            if (subscription == null)
            {
                _logger.LogError("Failed to deserialize queue item into Subscription object.");
                return null;
            }

            return subscription;
        }
    }
}
