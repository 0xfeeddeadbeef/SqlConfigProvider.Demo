namespace SqlConfigProvider.Demo
{
    using System;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;

    internal static class Program
    {
        private static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    // config.Sources.Clear();

                    IHostEnvironment env = hostingContext.HostingEnvironment;
                    IConfigurationRoot builtConfig = config.Build();
                    string configDb = builtConfig.GetSection("Demo:ConnectionStrings")["Config"];

                    if (!string.IsNullOrWhiteSpace(configDb))
                    {
                        const string appName = "SqlConfigProvider.Demo";

                        var interval = TimeSpan.FromMinutes(10d);

                        // Common to all environments:
                        config.AddSqlServerTable(configDb, appName, "", reloadInterval: interval);

                        // Specific to current environment (overrides previous values):
                        config.AddSqlServerTable(configDb, appName, env.EnvironmentName, reloadInterval: interval);
                    }
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
