using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AzureServiceBusClient
{
    public static class ServiceCollectionExcentions
    {
        public static IServiceCollection AddServiceBusClient(this IServiceCollection services, string connectionString, string queueName, bool enabled)
        {
            services.AddSingleton((s) =>
            {
                ServiceBusSender sender = null;
                if (enabled)
                {
                    if (string.IsNullOrEmpty(connectionString))
                    {
                        throw new ArgumentException("Please specify a valid connection string in your Azure Functions Settings.");
                    }

                    if (string.IsNullOrEmpty(queueName))
                    {
                        throw new ArgumentException("Please specify a valid queue name in your Azure Functions Settings.");
                    }

                    ServiceBusClient client = new ServiceBusClient(connectionString);
                    sender = client.CreateSender(queueName);
                }

                IBusClient azureServiceBusQueueFactory = new BusClient(sender);
                return azureServiceBusQueueFactory;
            });

            return services;
        }
    }
}