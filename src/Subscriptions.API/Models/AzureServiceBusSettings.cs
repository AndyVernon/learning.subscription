namespace Subscriptions.API.Models
{
    public class AzureServiceBusSettings
    {
        public const string SectionName = "AzureServiceBus";
        public string ConnectionString { get; set; } = string.Empty;
        public AzureServiceBusQueues Queues { get; set; } = new ();
    }

    public class AzureServiceBusQueues
    {
        public string Add { get; set; } = string.Empty;
    }
}
