using Azure.Messaging.ServiceBus;
using ClassLibrary1;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        services

            .AddTransient<MyDependency>()
            .AddTransient<ServiceBusClient>(sp =>
            {
                var cfg = sp.GetRequiredService<IConfiguration>();

                var connectionString = cfg.GetValue<string>("AzureWebJobsServiceBus");

                return new ServiceBusClient(connectionString);
            })

            ;
    })
    .Build();

host.Run();