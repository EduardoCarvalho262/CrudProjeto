using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Exceptions;
using System;
using System.IO;

namespace CrudProjeto
{
    public class Program
    {
        // Serilog - Instance of Configuration
        public static IConfiguration Configuration { get; private set; }

        public static void Main(string[] args)
        {

            //Build Configuration

            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .CreateLogger();

            try
            {
                Log.Information("Starting up...");
                CreateHostBuilder(args).Build().Run();
                Log.Information("Shutting down...");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Api host Terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            } 
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                              //.UseConfiguration(Configuration)
                                        
                });
    }
}
