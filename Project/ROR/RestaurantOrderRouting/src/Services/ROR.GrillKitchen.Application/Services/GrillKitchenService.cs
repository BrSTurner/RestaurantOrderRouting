using FluentValidation.Results;
using ROR.Kitchen.Core.Models;
using ROR.Kitchen.Core.Services;
using System.Threading.Tasks;

namespace ROR.GrillKitchen.Application.Services
{
    public class GrillKitchenService : KitchenService, IGrillKitchenService
    {
        public async Task<ValidationResult> ProcessNewOrder(OrderItem orderItem)
        {
            //Do Something Here
            //Add this Order Item to Grill Kitchen Display System
            //Do Specific Stuff about Grill

            return ValidationResult;
        }

        public async Task<ValidationResult> UpdateOrder(OrderItem orderItem) => ValidationResult;
    }
}
