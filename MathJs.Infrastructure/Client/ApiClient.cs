using MathJs.Core.Interfaces;
using RestSharp;
using MathJs.Infrastructure.Client.Config;

namespace MathJs.Infrastructure.Client
{
    public class ApiClient : IApiClient
    {
        RestClient _RestClient { get; set; }

        public ApiClient()
        {
            _RestClient = new RestClient(ApiConfig.BaseUrl);
            _RestClient.AddDefaultHeaders(ApiConfig.Headers);
        }
        public async Task<RestResponse> ExecuteGETRequestWithParameters(string parameterName, string parameterValue)
        {
            var request = new RestRequest(ApiConfig.Endpoint, Method.Get);
            request.AddParameter(parameterName, parameterValue);

            return await _RestClient.ExecuteAsync(request);
        }

        public async Task<RestResponse> ExecutePOSTRequestWithParameters(string parameterName, string parameterValue)
        {
            var request = new RestRequest(ApiConfig.Endpoint, Method.Post);
            Dictionary<string, string> body = new Dictionary<string, string>
            {
                {parameterName, parameterValue},
            };
            request.AddJsonBody(body);

            return await _RestClient.ExecuteAsync(request);
        }
    }
}
