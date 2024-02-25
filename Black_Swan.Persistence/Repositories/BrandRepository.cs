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
    public class BrandRepository:GenericRepository<Brand>,IBrandRepository
    {
        private readonly BlackSwanManagementDbContext _dbContext;

        public BrandRepository(BlackSwanManagementDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Brand> GetBrand(int id)
        {
            var brand = await _dbContext.brands.FirstOrDefaultAsync(x => x.id == id);
            return brand;
        }

        public async Task<List<Brand>> GetListBrand()
        {
            var brands = await _dbContext.brands.ToListAsync();
            return brands;
        }

        public async Task<bool> Unique(string name)
        {
            return !await _dbContext.brands.AnyAsync(x => x.name.ToLower() == name.ToLower());
            
        }
    }
}
