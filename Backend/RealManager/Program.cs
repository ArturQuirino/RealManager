using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using Microsoft.Extensions.Hosting;

namespace RealManager
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((ctx, builder) =>
                {
                    string appsettingsJsonVolume = Environment.GetEnvironmentVariable("APPSETTINGS_VOLUME");

                    builder
                        .SetBasePath(ctx.HostingEnvironment.ContentRootPath)
                        .AddJsonFile($"{appsettingsJsonVolume}/appsettings.json", true, true)
                        .AddJsonFile($"{appsettingsJsonVolume}/appsettings.{ctx.HostingEnvironment.EnvironmentName}.json", true, true)
                        .AddEnvironmentVariables()
                        .AddAzureKeyVault(
                            Environment.GetEnvironmentVariable("KeyVaultEndpoint"),
                            Environment.GetEnvironmentVariable("KeyVaultClientId"),
                            Environment.GetEnvironmentVariable("KeyVaultClientSecret"),
                            new DefaultKeyVaultSecretManager());
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
