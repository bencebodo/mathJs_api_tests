using mathJS_Service.Interfaces;

namespace mathJS_Service.Operations.Base
{
    public abstract class BaseOperation
    {
        protected readonly IApiClient _apiClient;

        public BaseOperation(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }
    }
}
