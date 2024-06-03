using ROR.Core.Messages;

namespace ROR.Orders.API.Application.Events
{
    public class OrderPlacedEvent : Event
    {
        public int OrderId { get; private set; }
        public int CustomerId { get; private set; }
        public OrderPlacedEvent(int orderId, int customerId)
        {
            OrderId = orderId;
            CustomerId = customerId;
        }
    }
}
