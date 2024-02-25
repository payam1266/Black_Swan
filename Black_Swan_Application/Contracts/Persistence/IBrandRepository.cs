using Black_Swan_Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Black_Swan_Application.Persistence.Contracts
{
    public interface IBrandRepository:IGenericRepository<Brand>
    {
        Task<Brand> GetBrand(int id);
        Task<List<Brand>> GetListBrand();
        Task<bool> Unique(string name);
    }
}
