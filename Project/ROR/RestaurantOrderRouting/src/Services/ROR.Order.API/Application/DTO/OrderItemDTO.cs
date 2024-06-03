using ROR.Orders.Domain.Enumerations;
using ROR.Orders.Domain.Models;

namespace ROR.Orders.API.Application.DTO
{
    public class OrderItemDTO
    {
        public int Quantity { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public OrderStatusEnum OrderStatus { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public KitchenEnum Kitchen { get; set; }
        public static OrderItem ToOrderItem(OrderItemDTO orderItemDTO)
        {
            return new OrderItem(orderItemDTO.ItemId, orderItemDTO.Quantity, orderItemDTO.ItemPrice, orderItemDTO.ItemName, orderItemDTO.OrderStatus, orderItemDTO.Kitchen);
        }
    }
}
