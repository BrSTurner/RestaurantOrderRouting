using ROR.Core.Messages;
using ROR.Orders.API.Application.DTO;
using ROR.Orders.Domain.Enumerations;
using System.Collections.Generic;

namespace ROR.Orders.API.Application.Commands.Orders
{
    public class NewOrderCommand : Command
    {
        public int? TableNumnber { get; set; }
        public decimal FinalPrice { get; set; }
        public int CustomerId { get; set; }
        public OrderStatusEnum OrderStatus { get; set; }
        public OrderTypeEnum OrderType { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new NewOrderValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
