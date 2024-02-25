using Black_Swan_Application.Persistence.Contracts;
using Black_Swan_Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Black_Swan.Persistence.Repositories
{
    public class ProductCategoryRepository:GenericRepository<ProductCategory>,IProductCategoryRepository
    {
        private readonly BlackSwanManagementDbContext _dbContext;

        public ProductCategoryRepository(BlackSwanManagementDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ProductCategory>> GetListProductCategories()
        {
            var productCategories = await _dbContext.productCategories.ToListAsync();
            return productCategories;
        }

        public async Task<ProductCategory> GetProductCategory(int id)
        {
            var productCategory= await _dbContext.productCategories.FirstOrDefaultAsync(x => x.id == id);
            return productCategory;
        }
    }
}
