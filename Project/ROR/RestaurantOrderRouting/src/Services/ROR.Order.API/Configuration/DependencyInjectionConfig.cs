using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ROR.Core.Mediator;
using ROR.Orders.API.Application.Commands.Orders;
using ROR.Orders.Domain.Interfaces.Repositories;
using ROR.Orders.Infra.Data;
using ROR.Orders.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROR.Orders.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // API
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddScoped<IAspNetUser, AspNetUser>();

            // Commands
            services.AddScoped<IRequestHandler<NewOrderCommand, ValidationResult>, OrderCommandHandler>();

            // Events
            //services.AddScoped<INotificationHandler<PedidoRealizadoEvent>, PedidoEventHandler>();

            // Application
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            //services.AddScoped<IVoucherQueries, VoucherQueries>();
            //services.AddScoped<IPedidoQueries, PedidoQueries>();

            // Data
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<OrderContext>();
        }
    }
}
