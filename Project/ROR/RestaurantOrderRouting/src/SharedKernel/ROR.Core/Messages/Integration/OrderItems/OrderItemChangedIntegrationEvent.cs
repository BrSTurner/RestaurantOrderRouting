namespace ROR.Core.Messages.Integration.OrderItems
{
    public class OrderItemChangedIntegrationEvent : IntegrationEvent
    {
        public int OrderId { get; set; }
        public int OrderItemId { get; set; }
        public int OrderStatus { get; set; }
    }
}
