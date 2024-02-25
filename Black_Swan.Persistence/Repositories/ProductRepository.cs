using Black_Swan_Application.Persistence.Contracts;
using Black_Swan_Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Black_Swan.Persistence.Repositories
{
    public class ProductRepository:GenericRepository<Product>,IProductRepository
    {
        private readonly BlackSwanManagementDbContext _dbContext;

        public ProductRepository(BlackSwanManagementDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Product>> GetListProductsWithDetails()
        {
          var products=await _dbContext.products
                .Include(x => x.brand).Include(x => x.city).Include(x => x.productCategory)
                .ToListAsync();
            return products;
        }

        public async Task<Product> GetProductWithDetails(int id)
        {
            var product =await _dbContext.products
                 .Include(x => x.brand).Include(x => x.city).Include(x => x.productCategory)
                 .FirstOrDefaultAsync(x => x.id==id);
            return product;
        }

        public async Task<bool> Unique(string name)
        {
            return !await _dbContext.products.AnyAsync(x => x.name.ToLower() == name.ToLower());
        }
    }
}
