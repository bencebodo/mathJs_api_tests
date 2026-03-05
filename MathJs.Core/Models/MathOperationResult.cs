using System;
using System.Collections.Generic;
using System.Text;

namespace MathJs.Core.Models
{
    public record MathOperationResult
    {
        public bool IsSuccess { get; init; }

        public double? NumericResult { get; init; }

        public string? StringResult { get; init; }

        public string? ErrorMessage { get; init; }

        public int StatusCode { get; init; }
    }
}
