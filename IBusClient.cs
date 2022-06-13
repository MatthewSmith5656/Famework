using System.Threading.Tasks;

namespace AzureServiceBusClient
{
    public interface IBusClient
    {
        Task<ServiceBusResponse> SendMessage<T>(T message);
    }
}
