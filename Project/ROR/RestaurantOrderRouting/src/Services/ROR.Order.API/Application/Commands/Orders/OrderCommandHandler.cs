using FluentValidation.Results;
using MediatR;
using ROR.Core.Messages;
using ROR.Core.Messages.Integration.Kitchens;
using ROR.Core.Messages.Integration.Orders;
using ROR.MessageBus;
using ROR.Orders.API.Application.DTO;
using ROR.Orders.Domain.Interfaces.Repositories;
using ROR.Orders.Domain.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ROR.Orders.API.Application.Commands.Orders
{
    public class OrderCommandHandler : CommandHandler, IRequestHandler<NewOrderCommand, ValidationResult>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMessageBus _messageBus;
        public OrderCommandHandler(
            IOrderRepository orderRepository,
            IMessageBus messageBus)        
        {
            _orderRepository = orderRepository;
            _messageBus = messageBus;
        }

        public async Task<ValidationResult> Handle(NewOrderCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                return request.ValidationResult;
            }

            var order = MapOrder(request);

            order.CalculateFinalPrice();
            order.NewOrder();

            _orderRepository.Add(order);

            await SaveChanges(_orderRepository.UnitOfWork);

            if (ValidationResult.IsValid && await SendOrderToPrepare(order))
            {
                return ValidationResult;
            }
            
            AddError($"The Order {order.Id} has been canceled");

            await _messageBus.PublishAsync(new OrderCanceledIntegrationEvent()
            {
                OrderId = order.Id
            });

            return ValidationResult;
        }
        private Order MapOrder(NewOrderCommand newOrderCommand)
        {
            return new Order(
                newOrderCommand.CustomerId,
                newOrderCommand.OrderStatus,
                newOrderCommand.OrderType,
                newOrderCommand.OrderItems.Select(OrderItemDTO.ToOrderItem).ToList(),
                newOrderCommand.FinalPrice,
                newOrderCommand.TableNumnber
            );
        }

        private async Task<bool> SendOrderToPrepare(Order order)
        {
            foreach (var orderItem in order.OrderItems)
            {
                var kitchen = new KitchenIntegrationEvent()
                {

                    ItemId = orderItem.ItemId,
                    OrderId = orderItem.OrderId,
                    Quantity = orderItem.Quantity,
                    ItemName = orderItem.ItemName,
                    OrderItemId = orderItem.Id,
                    OrderStatus = (int)order.OrderStatus,
                    Kitchen = (int)orderItem.Kitchen,
                };

                await _messageBus.PublishAsync(kitchen);
            }

            return true;
        }
    }
}
