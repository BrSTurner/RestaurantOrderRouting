using FluentValidation.Results;
using ROR.Kitchen.Core.Models;
using ROR.Kitchen.Core.Services;
using System.Threading.Tasks;

namespace ROR.DrinkKitchen.Application.Services
{
    public class DrinkKitchenService : KitchenService, IDrinkKitchenService
    {
        public async Task<ValidationResult> ProcessNewOrder(OrderItem orderItem)
        {
            //Do Something Here
            //Add this Order Item to Drink Kitchen Display System
            //Do Specific Stuff about Drink

            return ValidationResult;
        }

        public async Task<ValidationResult> UpdateOrder(OrderItem orderItem) => ValidationResult;
    }
}
