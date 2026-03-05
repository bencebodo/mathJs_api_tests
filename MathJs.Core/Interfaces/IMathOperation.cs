using RestSharp;

namespace MathJs.Core.Interfaces
{
    public interface IMathOperation
    {
        Task<RestResponse> CalculateAsync(string expression);
    }
}