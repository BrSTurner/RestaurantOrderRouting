namespace ROR.Core.Messages.Integration.Orders
{
    public class OrderCanceledIntegrationEvent : IntegrationEvent
    {
        public int OrderId { get; set; }
    }
}
