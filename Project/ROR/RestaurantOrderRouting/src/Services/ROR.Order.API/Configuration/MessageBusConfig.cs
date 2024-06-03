using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ROR.Core.Utils;
using ROR.MessageBus.DependencyInjection;
using ROR.Orders.API.Services;

namespace ROR.Orders.API.Configuration
{
    public static class MessageBusConfig
    {
        public static void AddMessageBusConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"))
                .AddHostedService<OrderIntegrationHandler>();
        }
    }
}
