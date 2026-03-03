using RestSharp;

namespace mathJS_Service.Interfaces
{
    public interface IMathOperation
    {
        Task<RestResponse> CalculateAsync(string expression);
    }
}