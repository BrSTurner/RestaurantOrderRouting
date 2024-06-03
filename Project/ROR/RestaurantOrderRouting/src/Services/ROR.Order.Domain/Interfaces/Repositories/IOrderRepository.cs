using ROR.Core.Data;
using ROR.Orders.Domain.Models;
using System.Threading.Tasks;

namespace ROR.Orders.Domain.Interfaces.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        void Add(Order order);
        void Update(Order order);
        Task<Order> GetById(int id);
    }
}
