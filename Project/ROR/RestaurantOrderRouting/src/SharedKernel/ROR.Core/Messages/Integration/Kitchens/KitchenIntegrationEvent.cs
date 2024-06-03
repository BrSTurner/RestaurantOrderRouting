namespace ROR.Core.Messages.Integration.Kitchens
{
    public class KitchenIntegrationEvent : IntegrationEvent
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public string ItemName { get; set; }
        public int Kitchen { get; set; }
        public int OrderStatus { get; set; }
    }
}
