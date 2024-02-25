using Black_Swan_Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Black_Swan_Application.Persistence.Contracts
{
    public interface ICityRepository:IGenericRepository<City>   
    {
        Task<City> GetCity(int id);
        Task<List<City>> GetListCities();
        Task<bool> Unique(string name);
    }
}
