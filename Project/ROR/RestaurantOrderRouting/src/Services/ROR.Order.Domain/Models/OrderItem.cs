using ROR.Core.DomainObjects;
using ROR.Orders.Domain.Enumerations;
using System;

namespace ROR.Orders.Domain.Models
{
    public class OrderItem : Entity<int>
    {
        public int Quantity { get; set; }
        public DateTime? FinishDate { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public OrderStatusEnum OrderStatus { get; set; }
        public KitchenEnum Kitchen { get; set; }

        public OrderItem(int itemId, int quantity, decimal itemPrice, 
            string itemName, OrderStatusEnum orderStatus, KitchenEnum kitchen, DateTime? finishDate = null)
        {
            ItemId = itemId;
            Quantity = quantity;
            ItemPrice = itemPrice;
            ItemName = itemName;
            FinishDate = finishDate;
            OrderStatus = orderStatus;
            Kitchen = kitchen;
        }

        public void NewOrder()
        {
            OrderStatus = OrderStatusEnum.New;
        }

        public void PreparingOrder()
        {
            OrderStatus = OrderStatusEnum.Preparing;
        }

        public void FinisihOrder()
        {
            OrderStatus = OrderStatusEnum.Done;
        }

        public void CancelOrder()
        {
            OrderStatus = OrderStatusEnum.Canceled;
        }

        #region Entity Framework Relationship
        public Order Order { get; set; }
        public Item Item { get; set; }
        protected OrderItem() { }
        #endregion
    }
}
