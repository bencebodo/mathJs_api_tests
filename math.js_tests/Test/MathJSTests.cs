using mathJS_Service.Enum;
using mathJS_Service.Interfaces;
using mathJS_Service.Models;
using mathJS_Service.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework.Interfaces;
using Serilog;

namespace math.js_tests.Test
{
    [TestFixture]
    public class MathJS_Tests : BaseTest
    {
        [SetUp]
        public void BeforeTest()
        {
            var context = TestContext.CurrentContext;
            var testName = context.Test.Name;
            _logger.LogInformation($"Starting test: {testName}");
        }

        #region OneDigit_AdditionTests
        [TestCase("1 + 2", 3)]
        [TestCase("6 + -4", 2)]
        [TestCase("-1 + 2", 1)]
        [TestCase("-6 + -4", -10)]
        [Category("OneDigit_AdditionTests")]
        public async Task MathJSApi_AdditionOfOneDigitNumbers_ReturnsTheExpectedResult(string parameterValue, double expectedResult)
        {
            var expressionResult = await _mathService.ExecuteExpression(parameterValue, OperationType.Add);

            Assert.Multiple(() =>
            {
                Assert.That(expressionResult.NumericResult, Is.EqualTo(expectedResult).Within(0.001));
                Assert.That(expressionResult.StatusCode, Is.EqualTo(200));
            });
        }
        #endregion

        #region OneDigitWithFraction_AdditionTests
        [TestCase("1.1 + 2.5", 3.6)]
        [TestCase("6.12 + -4.64", 1.48)]
        [TestCase("-1.345 + 2.632", 1.287)]
        [TestCase("-6.6324 + -4.5234", -11.1558)]
        [Category("OneDigitWithFraction_AdditionTests")]
        public async Task MathJSApi_AdditionOfOneDigitNumbersWithFraction_ReturnsTheExpectedResult(string parameterValue, double expectedResult)
        {
            var expressionResult = await _mathService.ExecuteExpression(parameterValue, OperationType.Add);

            Assert.Multiple(() =>
            {
                Assert.That(expressionResult.NumericResult, Is.EqualTo(expectedResult).Within(0.001));
                Assert.That(expressionResult.StatusCode, Is.EqualTo(200));
            });
        }
        #endregion

        #region TwoOrMoreDigit_AdditionTests
        [TestCase("10 + 20", 30)]
        [TestCase("600 + 400", 1000)]
        [TestCase("10000000 + 200", 10000200)]
        [TestCase("-10 + 20", 10)]
        [TestCase("-600 + 400", -200)]
        [TestCase("-10000000 + 200", -9999800)]
        [TestCase("10 + -20", -10)]
        [TestCase("600 + -400", 200)]
        [TestCase("10000000 + -200", 9999800)]
        [TestCase("-10 + -20", -30)]
        [TestCase("-600 + -400", -1000)]
        [TestCase("-10000000 + -200", -10000200)]
        [Category("TwoOrMoreDigit_AdditionTests")]
        public async Task MathJSApi_AdditionOfTwoOrMoreDigitNumbers_ReturnsTheExpectedResult(string parameterValue, double expectedResult)
        {
            var expressionResult = await _mathService.ExecuteExpression(parameterValue, OperationType.Add);

            Assert.Multiple(() =>
            {
                Assert.That(expressionResult.NumericResult, Is.EqualTo(expectedResult).Within(0.001));
                Assert.That(expressionResult.StatusCode, Is.EqualTo(200));
            });
        }
        #endregion

        #region OneDigit_SubtractionTests
        [TestCase("1 - 2", -1)]
        [TestCase("6 - -4", 10)]
        [TestCase("-1 - 2", -3)]
        [TestCase("-6 - -4", -2)]
        [Category("OneDigit_SubtracionTests")]
        public async Task MathJSApi_SubtractionOfOneDigitNumbers_ReturnsTheExpectedResult(string parameterValue, double expectedResult)
        {
            var expressionResult = await _mathService.ExecuteExpression(parameterValue, OperationType.Subtract);

            Assert.Multiple(() =>
            {
                Assert.That(expressionResult.NumericResult, Is.EqualTo(expectedResult).Within(0.001));
                Assert.That(expressionResult.StatusCode, Is.EqualTo(200));
            });
        }

        #endregion
        #region OneDigitWithFraction_SubtractionTests
        [TestCase("1.1 - 2", -0.9)]
        [TestCase("6.14 - -4", 10.14)]
        [TestCase("-1.153 - 2", -3.153)]
        [TestCase("-6.5423 - -4", -2.5423)]
        [Category("OneDigitWithFractions_SubtracionTests")]
        public async Task MathJSApi_SubtractionOfOneDigitNumbersWithFractions_ReturnsTheExpectedResult(string parameterValue, double expectedResult)
        {
            var expressionResult = await _mathService.ExecuteExpression(parameterValue, OperationType.Subtract);

            Assert.Multiple(() =>
            {
                Assert.That(expressionResult.NumericResult, Is.EqualTo(expectedResult).Within(0.001));
                Assert.That(expressionResult.StatusCode, Is.EqualTo(200));
            });
        }
        #endregion
        #region TwoOrMoreDigit_SubtractionTests
        [TestCase("10 - 20", -10)]
        [TestCase("600 - 400", 200)]
        [TestCase("10000000 - 200", 9999800)]
        [TestCase("-10 - 20", -30)]
        [TestCase("-600 - 400", -1000)]
        [TestCase("-10000000 - 200", -10000200)]
        [TestCase("10 - -20", 30)]
        [TestCase("600 - -400", 1000)]
        [TestCase("10000000 - -200", 10000200)]
        [TestCase("-10 - -20", 10)]
        [TestCase("-600 - -400", -200)]
        [TestCase("-10000000 - -200", -9999800)]
        [Category("TwoOrMoreDigit_SubtractionTests")]
        public async Task MathJSApi_SubtractionOfTwoOrMoreDigitNumbers_ReturnsTheExpectedResult(string parameterValue, double expectedResult)
        {
            var expressionResult = await _mathService.ExecuteExpression(parameterValue, OperationType.Subtract);

            Assert.Multiple(() =>
            {
                Assert.That(expressionResult.NumericResult, Is.EqualTo(expectedResult).Within(0.001));
                Assert.That(expressionResult.StatusCode, Is.EqualTo(200));
            });
        }
        #endregion

        #region OneDigit_MultiplicationTests
        [TestCase("1 * 2", 2)]
        [TestCase("6 * -4", -24)]
        [TestCase("-1 * 2", -2)]
        [TestCase("-6 * -4", 24)]
        [Category("OneDigit_MultiplicationTests")]
        public async Task MathJSApi_MultiplicationOfOneDigitNumbers_ReturnsTheExpectedResult(string parameterValue, double expectedResult)
        {
            var expressionResult = await _mathService.ExecuteExpression(parameterValue, OperationType.Multiply);

            Assert.Multiple(() =>
            {
                Assert.That(expressionResult.NumericResult, Is.EqualTo(expectedResult).Within(0.001));
                Assert.That(expressionResult.StatusCode, Is.EqualTo(200));
            });
        }
        #endregion

        #region OneDigitWithFractions_MultiplicationTests
        [TestCase("1.1 * 2", 2.2)]
        [TestCase("6.13 * -4", -24.52)]
        [TestCase("-1.632 * 2", -3.264)]
        [TestCase("-6.1234 * -4", 24.4936)]
        [Category("OneDigitWithFractions_MultiplicationTests")]
        public async Task MathJSApi_MultiplicationOfOneDigitNumbersWithFractions_ReturnsTheExpectedResult(string parameterValue, double expectedResult)
        {
            var expressionResult = await _mathService.ExecuteExpression(parameterValue, OperationType.Multiply);

            Assert.Multiple(() =>
            {
                Assert.That(expressionResult.NumericResult, Is.EqualTo(expectedResult).Within(0.001));
                Assert.That(expressionResult.StatusCode, Is.EqualTo(200));
            });
        }
        #endregion

        #region TwoOrMoreDigit_MultiplicationTests
        [TestCase("10 * 20", 200)]
        [TestCase("600 * 400", 240000)]
        [TestCase("10000000 * 200", 2000000000)]
        [TestCase("-10 * 20", -200)]
        [TestCase("-600 * 400", -240000)]
        [TestCase("-10000000 * 200", -2000000000)]
        [TestCase("10 * -20", -200)]
        [TestCase("600 * -400", -240000)]
        [TestCase("10000000 * -200", -2000000000)]
        [TestCase("-10 * -20", 200)]
        [TestCase("-600 * -400", 240000)]
        [TestCase("-10000000 * -200", 2000000000)]
        [Category("TwoOrMoreDigit_MultiplicationTests")]
        public async Task MathJSApi_MultiplicationOfTwoOrMoreDigitNumbers_ReturnsTheExpectedResult(string parameterValue, double expectedResult)
        {
            var expressionResult = await _mathService.ExecuteExpression(parameterValue, OperationType.Multiply);

            Assert.Multiple(() =>
            {
                Assert.That(expressionResult.NumericResult, Is.EqualTo(expectedResult).Within(0.001));
                Assert.That(expressionResult.StatusCode, Is.EqualTo(200));
            });
        }
        #endregion

        #region OneDigit_DivisionTests
        [TestCase("1 / 2", 0.5)]
        [TestCase("6 / -4", -1.5)]
        [TestCase("-1 / 2", -0.5)]
        [TestCase("-6 / -4", 1.5)]
        [Category("OneDigit_DivisionTests")]
        public async Task MathJSApi_DivisionOfOneDigitNumbers_ReturnsTheExpectedResult(string parameterValue, double expectedResult)
        {
            var expressionResult = await _mathService.ExecuteExpression(parameterValue, OperationType.Divide);

            Assert.Multiple(() =>
            {
                Assert.That(expressionResult.NumericResult, Is.EqualTo(expectedResult).Within(0.001));
                Assert.That(expressionResult.StatusCode, Is.EqualTo(200));
            });
        }
        #endregion

        #region OneDigitWithFractions_DivisionTests
        [TestCase("1.1 / 2", 0.55)]
        [TestCase("6.12 / -4", -1.53)]
        [TestCase("-1.123 / 2", -0.5615)]
        [TestCase("-6.1234 / -4", 1.53085)]
        [Category("OneDigitWithFractions_DivisionTests")]
        public async Task MathJSApi_DivisionOfOneDigitNumbersWithFractions_ReturnsTheExpectedResult(string parameterValue, double expectedResult)
        {
            var expressionResult = await _mathService.ExecuteExpression(parameterValue, OperationType.Divide);

            Assert.Multiple(() =>
            {
                Assert.That(expressionResult.NumericResult, Is.EqualTo(expectedResult).Within(0.001));
                Assert.That(expressionResult.StatusCode, Is.EqualTo(200));
            });
        }
        #endregion

        #region TwoOrMoreDigit_DivisionTests
        [TestCase("10 / 20", 0.5)]
        [TestCase("600 / 400", 1.5)]
        [TestCase("10000000 / 200", 50000)]
        [TestCase("-10 / 20", -0.5)]
        [TestCase("-600 / 400", -1.5)]
        [TestCase("-10000000 / 200", -50000)]
        [TestCase("10 / -20", -0.5)]
        [TestCase("600 / -400", -1.5)]
        [TestCase("10000000 / -200", -50000)]
        [TestCase("-10 / -20", 0.5)]
        [TestCase("-600 / -400", 1.5)]
        [TestCase("-10000000 / -200", 50000)]
        [Category("TwoOrMoreDigit_DivisionTests")]
        public async Task MathJSApi_DivisionOfTwoOrMoreDigitNumbers_ReturnsTheExpectedResult(string parameterValue, double expectedResult)
        {
            var expressionResult = await _mathService.ExecuteExpression(parameterValue, OperationType.Divide);

            Assert.Multiple(() =>
            {
                Assert.That(expressionResult.NumericResult, Is.EqualTo(expectedResult).Within(0.001));
                Assert.That(expressionResult.StatusCode, Is.EqualTo(200));
            });
        }
        #endregion

        [TestCase("10 / 0", "Infinity")]
        [Category("OneDigit_SubstracionTests")]
        public async Task MathJSApi_SubstractionOfOneDigitNumbersbyZero_ReturnsTheExpectedResult(string parameterValue, string expectedResult)
        {
            var expressionResult = await _mathService.ExecuteExpression(parameterValue, OperationType.Divide);

            Assert.Multiple(() =>
            {
                Assert.That(expressionResult.StringResult, Does.Contain(expectedResult));
                Assert.That(expressionResult.StatusCode, Is.EqualTo(200));


            });
        }

        #region SquareRootTests
        [TestCase("sqrt(4)", "2")]
        [TestCase("sqrt(16)", "4")]
        [TestCase("sqrt(256)", "16")]
        [TestCase("sqrt(-16)", "4i")]
        [Category("VariableDigit_SquareRootTest")]
        public async Task MathJSApi_SquareRootOfVariableDigitNumbers_ReturnsTheExpectedResult(string parameterValue, string expectedResult)
        {
            var expressionResult = await _mathService.ExecuteExpression(parameterValue, OperationType.SquareRoot);

            Assert.Multiple(() =>
            {
                Assert.That(expressionResult.StringResult, Does.Contain(expectedResult.ToString()), $"{parameterValue} did not resulted the expected {expressionResult}");
                Assert.That(expressionResult.StatusCode, Is.EqualTo(200));
            });
        }
        #endregion

        #region MissingMember_ExpressionNegativeTests

        [TestCase("1 +  ", "Error")]
        [TestCase("  +  ", "Error")]
        [TestCase("1 -  ", "Error")]
        [TestCase("  -  ", "Error")]
        [TestCase("1 *  ", "Error")]
        [TestCase("  *  ", "Error")]
        [TestCase("1 /  ", "Error")]
        [TestCase("  /  ", "Error")]
        [TestCase("  * 7", "Error")]
        [TestCase("  / 7", "Error")]
        [Category("MissingMember_ExpressionNegativeTests")]
        public async Task MathJSApi_ExpressionsWithMissingMembersNegative_ReturnsError(string parameterValue, string expectedResult)
        {
            var expressionResult = await _mathService.ExecuteExpression(parameterValue, OperationType.Add);

            Assert.Multiple(() =>
            {
                Assert.That(expressionResult.ErrorMessage, Does.Contain(expectedResult), $"{parameterValue} did not resulted the expected {expressionResult}");
                Assert.That(expressionResult.StatusCode, Is.EqualTo(400), $"{parameterValue} did not resulted the expected status code.");
            });
        }
        #endregion

        #region MissingMember_ExpressionPositiveTests
        [TestCase("  + 7", 7)]
        [TestCase("  - 7", -7)]
        [Category("MissingMember_ExpressionPositiveTests")]
        public async Task MathJSApi_ExpressionsWithMissingMembersOnFirstCharPositive_ReturnsValue(string parameterValue, double expectedResult)
        {
            var expressionResult = await _mathService.ExecuteExpression(parameterValue, OperationType.Add);

            Assert.Multiple(() =>
            {
                Assert.That(expressionResult.NumericResult, Is.EqualTo(expectedResult).Within(0.001));
                Assert.That(expressionResult.StatusCode, Is.EqualTo(200));
            });
        }
        #endregion

        [TearDown]
        public void AfterTest()
        {
            var context = TestContext.CurrentContext;
            var status = context.Result.Outcome.Status;
            var testName = context.Test.Name;

            if (status == TestStatus.Failed)
            {
                _logger.LogError($"[Fail] Test '{testName}' failed. Error: {context.Result.Message}");
            }
            else if (status == TestStatus.Passed)
            {
                _logger.LogInformation($"[Pass] Test '{testName}' passed successfully.");
            }
            _logger.LogDebug($"Test '{testName}' finished execution.");
        }
    }
}
