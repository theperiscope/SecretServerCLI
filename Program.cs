using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Spectre.Console.Cli;
using SecretServerCLI.Configuration;
using SecretServerCLI.Framework;
using SecretServerCLI.Spectre;
using SecretServerCLI.API;

namespace SecretServerCLI
{
    internal class Program
    {
        private static async Task<int> Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += (s, ev) =>
            {
                //Console.WriteLine("process exit");
            };

            Console.CancelKeyPress += (s, ev) =>
            {
                Console.WriteLine("Ctrl+C pressed");
            };

            using (var host = CreateHostBuilder(args).Build())
            {
                // RunAsync = StartAsync + WaitForShutdownAsync
                await host.RunAsync();
                host.Dispose();
            }

            return 0;
        }

        static IHostBuilder CreateHostBuilder(string[] args)
        {
            // .NET Core apps configure and launch a host. The host is responsible for app startup and lifetime management.
            return Host
                   // CreateDefaultBuilder() to setup a Host with default settings
                   // https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.hosting.host.createdefaultbuilder?view=dotnet-plat-ext-5.0
                   //
                   // The following defaults are applied to the returned HostBuilder:
                   //    - set the ContentRootPath to the result of GetCurrentDirectory()
                   //    - load host IConfiguration from "DOTNET_" prefixed environment variables
                   //    - load app IConfiguration from 'appsettings.json' and 'appsettings.[EnvironmentName].json'
                   //    - load app IConfiguration from User Secrets when EnvironmentName is 'Development' using the entry assembly
                   //    - load app IConfiguration from environment variables
                   //    - configure the ILoggerFactory to log to the console, debug, and event source output
                   //    - enables scope validation on the dependency injection container when EnvironmentName is 'Development'
                   .CreateDefaultBuilder(args)
                   // used to configure the properties of the IHostEnvironment; can be called multiple times
                   .ConfigureHostConfiguration(configHost =>
                   {
                       // configHost.SetBasePath(Directory.GetCurrentDirectory());

                       // can load configuration from environment variables, .json, command line, etc.

                       // configHost.AddEnvironmentVariables(prefix: "SPECTREDEMO_");

                       // configHost.AddJsonFile("hostsettings.json", optional: true);

                       // configHost.AddCommandLine(args);
                   })
                   // The configuration created by ConfigureAppConfiguration is available at HostBuilderContext.Configuration
                   // for subsequent operations and as a service from DI. The host configuration is also added to the app configuration.
                   .ConfigureAppConfiguration((hostContext, builder) =>
                   {
                       // builder.Sources.Clear();

                       builder
                           // for single .exes AppContext.BaseDirectory is where .exe is, not where it gets unpacked or current directory
                           .SetBasePath(AppContext.BaseDirectory)
                           .AddJsonFile("ss.appSettings.json", optional: true)
                           .AddJsonFile($"ss.appSettings.{hostContext.HostingEnvironment.EnvironmentName}.json", optional: true)
                           .AddCommandLine(args);

                       if (hostContext.HostingEnvironment.IsDevelopment())
                       {
                           builder.AddUserSecrets<SharedSpectreCommandSettings>();
                       }
                   })
                   .ConfigureServices((hostContext, services) =>
                   {
                       // dynamic hosted services
                       services.AddHostedServices(new List<Assembly> { Assembly.GetExecutingAssembly() });

                       // how Spectre Console registers types
                       services.AddSingleton<ITypeRegistrar>(new SpectreTypeRegistrar(services));

                       // Register IHttpClientFactory 
                       //   - https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-6.0
                       //   - https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests
                       services.AddHttpClient();

                       // for simple, one-operation CLIs, we do not want to see host lifetime messages
                       services.Configure<ConsoleLifetimeOptions>(options => options.SuppressStatusMessages = true);

                       services.AddSingleton(hostContext.Configuration.GetSection(nameof(CLIConfiguration)).Get<CLIConfiguration>());

                       services.AddTransient<AuthTokenInjectorDelegatingHandler>();
                       services.AddSingleton<IAuthTokenStore>(new AuthTokenFileSystemStore(System.IO.Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".ss")));
                       services.AddSingleton<IAuthTokenService>(new AuthTokenService());
                       services.AddSingleton<ICredentialsProvider<UsernamePasswordOTPCredentials>>(new InteractiveCredentialsProvider());
                       services.AddSingleton<IAuthTokenProvider, SecretServerCachedOAuthTokenProvider>();

                       services.AddHttpClient();

                       services
                           .AddHttpClient("oauth", (provider, client) =>
                           {
                               var settings = provider.GetRequiredService<CLIConfiguration>();
                               client.BaseAddress = new Uri(settings.SecretServerUrl);
                           })
                           .AddTypedClient(c => Refit.RestService.For<ISecretServerOAuthAPI>(c));

                       services
                           .AddHttpClient("api", (provider, client) => 
                           { 
                               var settings = provider.GetRequiredService<CLIConfiguration>();
                               client.BaseAddress = new Uri(settings.SecretServerUrl); 
                           })
                          .AddHttpMessageHandler<AuthTokenInjectorDelegatingHandler>()
                          .AddTypedClient(c => Refit.RestService.For<ISecretServerSecretAPI>(c));

                   })
                   .ConfigureLogging((hostContext, builder) =>
                   {
                       builder.AddConsole()
                        .AddConfiguration(hostContext.Configuration.GetSection("Logging"));
                   });
        }
    }
}
