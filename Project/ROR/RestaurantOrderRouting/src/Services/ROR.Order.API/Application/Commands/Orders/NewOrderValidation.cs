using FluentValidation;

namespace ROR.Orders.API.Application.Commands.Orders
{
    public class NewOrderValidation : AbstractValidator<NewOrderCommand>
    {
        public NewOrderValidation()
        {
            RuleFor(x => x.CustomerId)
                .GreaterThan(0)
                .WithMessage("Invalid Customer Identification");

            RuleFor(x => x.OrderItems.Count)
                .GreaterThan(0)
                .WithMessage("Order must have at least one Item");

            RuleFor(x => x.FinalPrice)
                .GreaterThan(0)
                .WithMessage("Invalid Final Price");
        }
    }
}
