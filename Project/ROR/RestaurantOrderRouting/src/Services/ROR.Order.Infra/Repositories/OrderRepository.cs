using Microsoft.EntityFrameworkCore;
using ROR.Core.Data;
using ROR.Orders.Domain.Interfaces.Repositories;
using ROR.Orders.Domain.Models;
using ROR.Orders.Infra.Data;
using System.Threading.Tasks;

namespace ROR.Orders.Infra.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _orderContext;
        public IUnitOfWork UnitOfWork => _orderContext;
        public OrderRepository(OrderContext orderContext)
        {
            _orderContext = orderContext;
        }

        public void Dispose() => _orderContext.Dispose();

        public void Add(Order order)
        {
            _orderContext.Add(order);
        }

        public void Update(Order order)
        {
            _orderContext.Update(order);
        }

        public async Task<Order> GetById(int id)
        {
            return await _orderContext
                .Orders
                .Include(x => x.OrderItems)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
