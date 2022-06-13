using System.Net.Http;

namespace AzureServiceBusClient
{
    public class ServiceBusResponse : HttpResponseMessage
    {
        private bool Successful { get; }
        private string Error { get; }

        public ServiceBusResponse(bool successful, string error = null)
        {
            Successful = successful;
            Error = error;
        }


    }
}