using ROR.Core.DomainObjects;
using ROR.Orders.Domain.Enumerations;
using System.Collections.Generic;

namespace ROR.Orders.Domain.Models
{
    public class Item : StaticEntity<int>
    {
        public decimal Price { get; set; }
        public KitchenEnum Kitchen { get; set; } 
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        protected Item(){}
    }
}
