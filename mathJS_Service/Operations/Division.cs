using mathJS_Service.Client;
using mathJS_Service.Interfaces;
using mathJS_Service.Operations.Base;
using RestSharp;

namespace mathJS_Service.Operations
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
