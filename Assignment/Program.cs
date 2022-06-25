using Assignment.Calculation;
using Assignment.Extractor;
using Assignment.Interfaces;
using Assignment.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.IO;

namespace Assignment
{
    class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(Configuration).CreateLogger();

            var services = new ServiceCollection();
            ConfigureServices(services);
            services.AddSingleton<Executor>()
                .BuildServiceProvider()
                .GetService<Executor>()
                .Execute();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IExtractor, FileDataExtractor>();
            services.AddTransient<ICalculator, SumCalculator>();
            services.AddTransient<IPersister, ConsolePersister>();
            services.AddSingleton(Log.Logger);
        }
    }
}
