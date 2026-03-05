using MathJs.Core.Interfaces;

namespace MathJs.Infrastructure.Operations.Base
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
