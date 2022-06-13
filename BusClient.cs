using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace AzureServiceBusClient
{

    public class BusClient : IBusClient
    {
        private readonly ServiceBusSender serviceBusSender;

        public BusClient(ServiceBusSender serviceBusSender)
        {
            this.serviceBusSender = serviceBusSender;
        }

        public async Task<ServiceBusResponse> SendMessage<T>(T message)
        {
            if (serviceBusSender != null)
            {
                try
                {
                    ServiceBusMessage msg = new ServiceBusMessage(JsonConvert.SerializeObject(message));
                    await serviceBusSender.SendMessageAsync(msg);
                }
                catch (Exception ex)
                {
                    return new ServiceBusResponse(false, ex.Message);
                }
            }
            return new ServiceBusResponse(true);
        }
    }
}