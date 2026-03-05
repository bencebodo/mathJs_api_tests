using MathJs.Infrastructure.Client;
using MathJs.Core.Interfaces;
using RestSharp;
using MathJs.Infrastructure.Operations.Base;

namespace MathJs.Infrastructure.Operations
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
