using mathJS_Service.Enum;
using mathJS_Service.Models;

namespace mathJS_Service.Interfaces
{
    public interface IMathService
    {
        Task<MathOperationResult> ExecuteExpression(string expression, OperationType type);

    }
}
