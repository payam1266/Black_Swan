using Black_Swan_Application.Persistence.Contracts;
using Black_Swan_Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Black_Swan.Persistence.Repositories
{
    public class OrderRepository:GenericRepository<Order>,IOrderRepository
    {
        private readonly BlackSwanManagementDbContext _dbContext;

        public OrderRepository(BlackSwanManagementDbContext dbContext ):base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Order>> GetListOrders()
        {
            var lstOrder = await _dbContext.orders.ToListAsync();
            return lstOrder;
        }

        public async Task<Order> GetOrder(int id)
        {
            var order = await _dbContext.orders.FirstOrDefaultAsync(x => x.id == id);
            return order;
        }

    }
}
