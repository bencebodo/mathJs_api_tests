using MathJs.Core.Enum;
using MathJs.Core.Models;

namespace MathJs.Core.Interfaces
{
    public interface IMathService
    {
        Task<MathOperationResult> ExecuteExpression(string expression, OperationType type);

    }
}
