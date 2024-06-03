using ROR.Core.DomainObjects;
using ROR.Orders.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ROR.Orders.Domain.Models
{
    public class Order : Entity<int>, IAggregateRoot
    {
        private readonly List<OrderItem> _orderItems;
        
        public int? TableNumber { get; set; }
        public DateTime? FinishDate { get; set; }
        public decimal FinalPrice { get; set; }
        public OrderStatusEnum OrderStatus { get; set; }
        public int CustomerId { get; set; }
        public OrderTypeEnum OrderType{ get; set; }
        public virtual IReadOnlyCollection<OrderItem> OrderItems => _orderItems; 

        public Order(int customerId, OrderStatusEnum orderStatus, OrderTypeEnum orderType, 
            List<OrderItem> orderItems, decimal finalPrice, int? tableNumber, DateTime? finishDate = null)
        {
            CustomerId = customerId;
            OrderStatus = orderStatus;
            OrderType = orderType;
            _orderItems = orderItems;
            TableNumber = tableNumber;
            FinishDate = finishDate;
            FinalPrice = finalPrice;
        }

        public void CalculateFinalPrice()
        {
            FinalPrice += OrderItems.Sum(x => x.ItemPrice * x.Quantity);
        }

        public void NewOrder()
        {
            OrderStatus = OrderStatusEnum.New;
            OrderItems.ToList().ForEach(x => x.NewOrder());
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
            OrderItems.ToList().ForEach(x => x.CancelOrder());
        }

        #region Entity Framework Relationship
        public Customer Customer { get; set; }
        protected Order() { }
        #endregion
    }
}
