namespace ROR.Kitchen.Core.Models
{
    public class OrderItem
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
