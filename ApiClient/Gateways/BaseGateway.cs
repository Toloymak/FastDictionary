namespace ApiClient.Gateways
{
    public class BaseGateway
    {
        protected readonly InternalApiClient _internalApiClient;
        
        public BaseGateway()
        {
            _internalApiClient = new InternalApiClient();
        }
    }
}