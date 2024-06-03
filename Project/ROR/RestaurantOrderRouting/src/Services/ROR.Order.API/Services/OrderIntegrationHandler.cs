using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ROR.Core.DomainObjects;
using ROR.Core.Messages.Integration.OrderItems;
using ROR.Core.Messages.Integration.Orders;
using ROR.MessageBus;
using ROR.Orders.Domain.Enumerations;
using ROR.Orders.Domain.Interfaces.Repositories;
using ROR.Orders.Domain.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ROR.Orders.API.Services
{
    public class OrderIntegrationHandler : BackgroundService
    {
        private readonly IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;
        public OrderIntegrationHandler(IServiceProvider serviceProvider, IMessageBus bus)
        {
            _serviceProvider = serviceProvider;
            _bus = bus;
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            SetSubscribers();
            return Task.CompletedTask;
        }

        private void SetSubscribers()
        {
            _bus.SubscribeAsync<OrderCanceledIntegrationEvent>("OrderCanceled",
                async request => await CancelOrder(request));         

            _bus.SubscribeAsync<OrderItemChangedIntegrationEvent>("OrderItemChanged",
                async request => await OrderItemChanged(request));
        }

        public async Task CancelOrder(OrderCanceledIntegrationEvent message)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var orderRepository = scope.ServiceProvider.GetRequiredService<IOrderRepository>();

                var order = await orderRepository.GetById(message.OrderId);
                order.CancelOrder();

                orderRepository.Update(order);

                if (!await orderRepository.UnitOfWork.Commit())
                {
                    throw new DomainException($"We found a problem canceling the Order {message.OrderId}");
                }
            }
        }

        public async Task OrderItemChanged(OrderItemChangedIntegrationEvent message)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var orderRepository = scope.ServiceProvider.GetRequiredService<IOrderRepository>();

                var order = await orderRepository.GetById(message.OrderId);

                order.OrderItems.ToList().ForEach(x => {
                    if (x.Id == message.OrderItemId)
                    {
                        x.OrderStatus = (OrderStatusEnum)message.OrderStatus;
                        if(message.OrderStatus == (int)OrderStatusEnum.Canceled || message.OrderStatus == (int)OrderStatusEnum.Canceled)
                        {
                            x.FinishDate = DateTime.Now;
                        }
                    }
                });

                CheckOrderStatus(message, order);

                orderRepository.Update(order);

                if (!await orderRepository.UnitOfWork.Commit())
                {
                    throw new DomainException($"We found a problem updating the Order {message.OrderId}");
                }
            }
        }

        private void CheckOrderStatus(OrderItemChangedIntegrationEvent message, Order order)
        {
            if (order.OrderStatus != OrderStatusEnum.Preparing && (OrderStatusEnum)message.OrderStatus == OrderStatusEnum.Preparing) //Change status to Preparing if any item starts to be prepare
            {
                order.OrderStatus = OrderStatusEnum.Preparing;
            }
            else if (order.OrderItems.All(x => x.OrderStatus == OrderStatusEnum.Done)) //Change status to Done if the Items were finished
            {
                order.OrderStatus = OrderStatusEnum.Done;
                order.FinishDate = DateTime.Now;
            }
            else if (order.OrderItems.All(x => x.OrderStatus == OrderStatusEnum.Canceled)) //Change status to Canceled if the Items were canceled
            {
                order.OrderStatus = OrderStatusEnum.Canceled;
                order.FinishDate = DateTime.Now;
            }
            else if (!order.OrderItems.Any(x => x.OrderStatus != OrderStatusEnum.Canceled && x.OrderStatus != OrderStatusEnum.Done)) //If any item was canceled but not the whole Order
            {
                order.OrderStatus = OrderStatusEnum.Done;
                order.FinishDate = DateTime.Now;
            }
        }
    }
}
