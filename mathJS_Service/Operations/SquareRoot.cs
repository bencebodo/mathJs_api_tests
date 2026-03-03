using mathJS_Service.Client;
using mathJS_Service.Interfaces;
using mathJS_Service.Operations.Base;
using RestSharp;

namespace mathJS_Service.Operations
{
    public class SquareRoot : BaseOperation, IMathOperation
    {
        public SquareRoot(IApiClient apiClient) : base(apiClient) { }

        public async Task<RestResponse> CalculateAsync(string expression)
        {
            return await _apiClient.ExecuteGETRequestWithParameters("expr", expression);
        }
    }
}
