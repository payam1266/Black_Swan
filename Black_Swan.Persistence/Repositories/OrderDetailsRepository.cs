using Black_Swan_Application.Persistence.Contracts;
using Black_Swan_Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black_Swan.Persistence.Repositories
{
    public class OrderDetailsRepository:GenericRepository<OrderDetails>,IOrderDetailsRepository
    {
        private readonly BlackSwanManagementDbContext _dbContext;

        public OrderDetailsRepository(BlackSwanManagementDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<OrderDetails>> GetListOrderDetailsWithDetails()
        {
            var lstOrderDetails = await _dbContext.OrderDetails
                .Include(x => x.Order).ToListAsync();
            return lstOrderDetails;
        }

        public async Task<OrderDetails> GetOrderDetailsWithDetails(int id)
        {
            var orderDetails = await _dbContext.OrderDetails.Include(x=> x.Order).FirstOrDefaultAsync(x => x.id == id);
            return orderDetails;
        }
    }
}
