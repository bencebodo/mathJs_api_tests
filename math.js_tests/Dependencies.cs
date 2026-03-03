using mathJS_Service.Client;
using mathJS_Service.Interfaces;
using mathJS_Service.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Testing.Platform.Logging;
using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace math.js_tests
{
    public static class Dependencies
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
