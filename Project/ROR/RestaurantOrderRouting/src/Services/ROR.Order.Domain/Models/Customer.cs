using ROR.Core.DomainObjects;
using System.Collections.Generic;

namespace ROR.Orders.Domain.Models
{
    public class Customer : Entity<int>
    {
        private readonly List<Order> _orders;
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public virtual IReadOnlyCollection<Order> Orders => _orders;
        protected Customer() { }
        public Customer(string name, string phoneNumber, List<Order> orders)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            _orders = orders;
        }
    }
}
