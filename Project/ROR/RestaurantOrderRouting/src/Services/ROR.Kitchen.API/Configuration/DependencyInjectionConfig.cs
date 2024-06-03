using Microsoft.Extensions.DependencyInjection;
using ROR.DesertKitchen.Application.Services;
using ROR.DrinkKitchen.Application.Services;
using ROR.FriesKitchen.Application.Services;
using ROR.GrillKitchen.Application.Services;
using ROR.SaladKitchen.Application.Services;

namespace ROR.Kitchen.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //Services
            services.AddScoped<IDesertKitchenService, DesertKitchenService>();
            services.AddScoped<IDrinkKitchenService, DrinkKitchenService>();
            services.AddScoped<IFriesKitchenService, FriesKitchenService>();
            services.AddScoped<IGrillKitchenService, GrillKitchenService>();
            services.AddScoped<ISaladKitchenService, SaladKitchenService>();
        }
    }
}
