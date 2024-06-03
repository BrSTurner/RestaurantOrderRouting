using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ROR.Core.Messages.Integration.Kitchens;
using ROR.Core.Messages.Integration.OrderItems;
using ROR.DesertKitchen.Application.Services;
using ROR.DrinkKitchen.Application.Services;
using ROR.FriesKitchen.Application.Services;
using ROR.GrillKitchen.Application.Services;
using ROR.Kitchen.Core.Enumerations;
using ROR.Kitchen.Core.Models;
using ROR.Kitchen.Core.Services;
using ROR.MessageBus;
using ROR.SaladKitchen.Application.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ROR.Kitchen.API.Services
{
    public class KitchenIntegrationHandler : BackgroundService
    {
        private readonly IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;
        public KitchenIntegrationHandler(IMessageBus bus, IServiceProvider serviceProvider)
        {
            _bus = bus;
            _serviceProvider = serviceProvider;
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            SetSubscribers();
            return Task.CompletedTask;
        }

        private void SetSubscribers()
        {
            _bus.SubscribeAsync<KitchenIntegrationEvent>("KitchenNewOrder",
                async request => await NewOrderReceived(request));
        }

        private async Task NewOrderReceived(KitchenIntegrationEvent order)
        {
            Type serviceType = null;

            switch ((KitchenEnum)order.Kitchen)
            {
                case KitchenEnum.Desert:
                    serviceType = typeof(IDesertKitchenService);
                    break;
                case KitchenEnum.Salad:
                    serviceType = typeof(ISaladKitchenService);
                    break;
                case KitchenEnum.Grill:
                    serviceType = typeof(IGrillKitchenService);
                    break;
                case KitchenEnum.Fries:
                    serviceType = typeof(IFriesKitchenService);
                    break;
                case KitchenEnum.Drink:
                    serviceType = typeof(IDrinkKitchenService);
                    break;
            }

            if (serviceType == null)
            {
                await OrderItemChange(new OrderItemChangedIntegrationEvent {
                    OrderId = order.OrderId,
                    OrderItemId = order.OrderItemId,
                    OrderStatus = (int)OrderStatusEnum.Canceled
                });

                return;
            }

            using (var scope = _serviceProvider.CreateScope())
            {
                var kitchenService = scope.ServiceProvider.GetRequiredService(serviceType) as IKitchenService;
                await ProcessNewOrder(order, kitchenService);
            }
        }
        private async Task ProcessNewOrder(KitchenIntegrationEvent order, IKitchenService kitchenService)
        {
            var result = await kitchenService.ProcessNewOrder(new OrderItem()
            {
                ItemId = order.ItemId,
                ItemName = order.ItemName,
                OrderId = order.OrderId,
                OrderItemId = order.OrderItemId,
                Kitchen = order.Kitchen,
                Quantity = order.Quantity,
                OrderStatus = order.OrderStatus
            });

            await OrderItemChange(new OrderItemChangedIntegrationEvent()
            {
                OrderId = order.OrderId,
                OrderItemId = order.OrderItemId,
                OrderStatus = result.IsValid ? (int)OrderStatusEnum.Preparing : (int)OrderStatusEnum.Canceled
            });
        }

        private async Task OrderItemChange(OrderItemChangedIntegrationEvent orderItemChanged)
        {
            await _bus.PublishAsync(orderItemChanged);
        }
    }
}
