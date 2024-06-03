using FluentValidation.Results;
using ROR.Kitchen.Core.Models;
using ROR.Kitchen.Core.Services;
using System.Threading.Tasks;

namespace ROR.DesertKitchen.Application.Services
{
    public class DesertKitchenService : KitchenService, IDesertKitchenService
    {
        public async Task<ValidationResult> ProcessNewOrder(OrderItem orderItem)
        {
            //Do Something Here
            //Add this Order Item to Desert Kitchen Display System
            //Do Specific Stuff about Deserts

            return ValidationResult;
        }

        public async Task<ValidationResult> UpdateOrder(OrderItem orderItem)
        {
            //Do Something Here
            //Update this Order Item infomartion on Kitchen Display System

            return ValidationResult;
        }
    }
}
