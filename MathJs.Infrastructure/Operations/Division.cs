using MathJs.Infrastructure.Client;
using MathJs.Core.Interfaces;
using RestSharp;
using MathJs.Infrastructure.Operations.Base;

namespace MathJs.Infrastructure.Operations
{
    public class Division : BaseOperation, IMathOperation
    {
        public Division(IApiClient apiClient) : base(apiClient) { }
        public async Task<RestResponse> CalculateAsync(string expression)
        {
            return await _apiClient.ExecutePOSTRequestWithParameters("expr", expression);
        }
    }
}
