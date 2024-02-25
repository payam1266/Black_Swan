using Black_Swan_Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Black_Swan_Application.Persistence.Contracts
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        Task<Product> GetProductWithDetails(int id);
        Task<List<Product>> GetListProductsWithDetails();
        Task<bool> Unique(string name);
    }
}
