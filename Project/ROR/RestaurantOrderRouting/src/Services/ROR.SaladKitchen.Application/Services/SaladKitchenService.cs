using FluentValidation.Results;
using ROR.Kitchen.Core.Models;
using ROR.Kitchen.Core.Services;
using System.Threading.Tasks;

namespace ROR.SaladKitchen.Application.Services
{
    public class SaladKitchenService : KitchenService, ISaladKitchenService
    {
        public async Task<ValidationResult> ProcessNewOrder(OrderItem orderItem)
        {
            //Do Something Here
            //Add this Order Item to Salad Kitchen Display System
            //Do Specific Stuff about Salads

            return ValidationResult;
        }

        public async Task<ValidationResult> UpdateOrder(OrderItem orderItem) => ValidationResult;
    }
}
