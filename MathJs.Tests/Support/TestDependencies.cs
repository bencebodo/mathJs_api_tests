using MathJs.Infrastructure.Client;
using MathJs.Core.Interfaces;
using MathJs.Infrastructure.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Testing.Platform.Logging;
using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace MathJs.Tests.Support
{
    public static class TestDependencies
    {
        public static IServiceProvider ConfigureService()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddSingleton<IApiClient, ApiClient>();
            var serilogLogger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console()
            .CreateLogger();

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.AddSerilog(serilogLogger, dispose: true);
            });
            services.AddScoped<IMathService, MathService>();

            return services.BuildServiceProvider();
        }
    }
}
