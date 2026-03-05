using MathJs.Tests.Support;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using MathJs.Core.Interfaces;

namespace MathJs.Tests.Test.Base;

[TestFixture]
public class BaseTest
{
    private IServiceProvider _serviceProvider;
    protected IMathService _mathService;
    protected ILogger<BaseTest> _logger;

    [OneTimeSetUp]
    public void Setup()
    {
        _serviceProvider = TestDependencies.ConfigureService();
        _mathService = _serviceProvider.GetRequiredService<IMathService>();
        _logger = _serviceProvider.GetRequiredService<ILogger<BaseTest>>();
    }

    [OneTimeTearDown]
    public void LoggerTearDown()
    {
        _logger.LogInformation("MathJS test is completed.", DateTime.Now);
        if (_serviceProvider is IDisposable disposable)
        {
            disposable.Dispose();
        }

        Log.CloseAndFlush();
    }
}
