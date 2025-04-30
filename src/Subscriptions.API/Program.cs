
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Options;
using Subscriptions.API.Implementations.Services;
using Subscriptions.API.Interfaces;
using Subscriptions.API.Models;

namespace Subscriptions.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.Configure<AzureServiceBusSettings>(builder.Configuration.GetSection(AzureServiceBusSettings.SectionName));
            builder.Services.AddSingleton<ServiceBusClient>(sp =>
            {
                var config = sp.GetRequiredService<IOptions<AzureServiceBusSettings>>().Value;
                return new ServiceBusClient(config.ConnectionString);
            });
            builder.Services.AddSingleton<ISubscriptionService, ServiceBusService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
