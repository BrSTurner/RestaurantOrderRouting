using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ROR.Core.Utils;
using ROR.Kitchen.API.Services;
using ROR.MessageBus.DependencyInjection;

namespace ROR.Kitchen.API.Configuration
{
    public static class MessageBusConfig
    {
        public static void AddMessageBusConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"))
                .AddHostedService<KitchenIntegrationHandler>();
        }
    }
}
