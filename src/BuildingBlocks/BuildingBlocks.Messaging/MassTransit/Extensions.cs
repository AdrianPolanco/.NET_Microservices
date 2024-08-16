using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BuildingBlocks.Messaging.MassTransit
{
    public static class Extensions
    {
        public static IServiceCollection AddMessageBroker
        (this IServiceCollection services, IConfiguration configuration, Assembly? assembly = null)
        {
            // Add MassTransit
            services.AddMassTransit(config =>
            {
                //Setting the endpoint name formatter to kebab case. Ex: MyEndpointName => my-endpoint-name
                config.SetKebabCaseEndpointNameFormatter();

                // Add consumers from the assembly if provided, will automatically register all consumers and discover them
                if (assembly != null)
                    config.AddConsumers(assembly);

                // Add the message broker configuration
                config.UsingRabbitMq((context, configurator) =>
                {
                    // Connect to the message broker
                    configurator.Host(new Uri(configuration["MessageBroker:Hostname"]!), host =>
                    {
                        host.Username(configuration["MessageBroker:Username"]);
                        host.Password(configuration["MessageBroker:Password"]);
                    });
                    configurator.ConfigureEndpoints(context);
                });
            });

            return services;
        }
    }
}
