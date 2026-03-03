using RestSharp;

namespace mathJS_Service.Interfaces
{
    public interface IApiClient
    {
        Task<RestResponse> ExecuteGETRequestWithParameters(string parameterName, string parameterValue);

        Task<RestResponse> ExecutePOSTRequestWithParameters(string parameterName, string parameterValue);
    }
}
