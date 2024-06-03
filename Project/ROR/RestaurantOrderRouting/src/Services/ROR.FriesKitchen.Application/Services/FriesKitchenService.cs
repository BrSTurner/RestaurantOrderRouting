using FluentValidation.Results;
using ROR.Kitchen.Core.Models;
using ROR.Kitchen.Core.Services;
using System.Threading.Tasks;

namespace ROR.FriesKitchen.Application.Services
{
    public class FriesKitchenService : KitchenService, IFriesKitchenService
    {
        public async Task<ValidationResult> ProcessNewOrder(OrderItem orderItem)
        {
            //Do Something Here
            //Add this Order Item to Fries Kitchen Display System
            //Do Specific Stuff about Fries (Example: Turn on an automatic Fridge using IoT integration)

            return ValidationResult;
        }

        public async Task<ValidationResult> UpdateOrder(OrderItem orderItem) => ValidationResult;
    }
}
