using Black_Swan_Application.Persistence.Contracts;
using Black_Swan_Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Black_Swan.Persistence.Repositories
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        private readonly BlackSwanManagementDbContext _dbContext;

        public CityRepository(BlackSwanManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<City> GetCity(int id)
        {
            var city = await _dbContext.cities.FirstOrDefaultAsync(x => x.id == id);
            return city;
        }

        public async Task<List<City>> GetListCities()
        {
            var lstCity = await _dbContext.cities.ToListAsync();
            return lstCity;
        }

        public async Task<bool> Unique(string name)
        {
            var validName = await GetListCities();
            foreach (var city in validName)
            {
                if (city.name?.ToLower() == name.ToLower())
                {
                    return false;
                }
            }
            return  true;
        }
    }
} 

