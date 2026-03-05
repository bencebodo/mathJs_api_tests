using MathJs.Infrastructure.Client;
using MathJs.Core.Enum;
using MathJs.Core.Interfaces;
using MathJs.Core.Models;
using MathJs.Infrastructure.Operations;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Globalization;
using System.Text.Json.Nodes;

namespace MathJs.Infrastructure.Service
{
    public class MathService : IMathService
    {
        private readonly Dictionary<OperationType, IMathOperation> _strategies;
        private readonly IApiClient _apiClient;
        private readonly ILogger<MathService> _logger;
        public MathService(IApiClient apiClient, ILogger<MathService> logger)
        {
            _apiClient = apiClient;
            _strategies = new Dictionary<OperationType, IMathOperation>
            {
                {OperationType.Add, new Addition(_apiClient)},
                {OperationType.Divide, new Division(_apiClient)},
                {OperationType.Subtract, new Subtraction(_apiClient)},
                {OperationType.Multiply, new Multiplication(_apiClient)},
                {OperationType.SquareRoot, new SquareRoot(_apiClient)},
            };
            _logger = logger;
        }

        public async Task<MathOperationResult> ExecuteExpression(string expression, OperationType type)
        {
            _logger.LogInformation("Starting Math execution. Type: {OperationType}, Expression: {Expression}", type, expression);

            if (!_strategies.TryGetValue(type, out var operation))
            {
                _logger.LogError("Strategy not found for OperationType: {OperationType}", type);
                return new MathOperationResult { IsSuccess = false, NumericResult = double.NaN, StatusCode = 0};
            }

            var response = await operation.CalculateAsync(expression);
            int statusCode = (int)response.StatusCode;

            _logger.LogDebug("MathJS API responded. StatusCode: {StatusCode}", statusCode);

            if (string.IsNullOrEmpty(response.Content))
            {
                _logger.LogWarning("MathJS API response content is null or empty. StatusCode: {StatusCode}", statusCode);
                return new MathOperationResult { IsSuccess = false, NumericResult = double.NaN, StatusCode = 0 };
            }
            try
            {
                var rootNode = JsonNode.Parse(response.Content);
                if (rootNode == null)
                {
                    _logger.LogError("Failed to parse JSON content. Result is null.");
                    return new MathOperationResult { IsSuccess = false, NumericResult = double.NaN, StatusCode = 0};
                }

                if (rootNode is JsonObject jsonObject)
                {   
                    _logger.LogDebug("Response parsed as JSON Object. Extracting result...");
                    var jsonObjectResult = ExtractJsonObject(jsonObject, statusCode);
                    return jsonObjectResult;
                }
                _logger.LogDebug("Response is not a JSON Object (likely primitive or array). Extracting raw value.");
                string responseResult = rootNode.GetValue<string>().ToString();
                return new MathOperationResult { IsSuccess = true, StringResult = responseResult, StatusCode = statusCode};
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "JSON parsing failed or format unexpected. Falling back to raw content. Content: {Content}", response.Content);
                return new MathOperationResult { IsSuccess = false, StringResult = response.Content, StatusCode = statusCode};
            }
        }

        private MathOperationResult ExtractJsonObject(JsonObject jsonObject, int statuscode)
        {
            if (jsonObject["result"] == null)
            {
                string errorMsg = jsonObject["error"].ToString();
                _logger.LogWarning("MathJS API returned an error: {ErrorMessage}", errorMsg);
                return new MathOperationResult
                {
                    IsSuccess = false,
                    ErrorMessage = errorMsg,
                    StatusCode = statuscode
                };
            }

            string responseResult = jsonObject["result"].ToString();

            if (responseResult.Contains("i"))
            {
                _logger.LogDebug("Result detected as Imaginary/Complex number: {Result}", responseResult);
                return new MathOperationResult
                {
                    IsSuccess = true,
                    StringResult = responseResult,
                    StatusCode = statuscode
                };
            }
            else
            {
                return new MathOperationResult
                {
                    IsSuccess = true,
                    NumericResult = double.Parse(responseResult, CultureInfo.InvariantCulture),
                    StatusCode = statuscode
                };
            }
        }
    }
}
