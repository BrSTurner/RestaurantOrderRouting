using FluentValidation.Results;
using ROR.Kitchen.Core.Models;
using System.Threading.Tasks;

namespace ROR.Kitchen.Core.Services
{
    public interface IKitchenService
    {
        Task<ValidationResult> ProcessNewOrder(OrderItem orderItem);
        Task<ValidationResult> UpdateOrder(OrderItem orderItem);
    }
}
