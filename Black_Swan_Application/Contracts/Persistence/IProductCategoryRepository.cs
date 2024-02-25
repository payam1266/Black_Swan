using Black_Swan_Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Black_Swan_Application.Persistence.Contracts
{
    public interface IProductCategoryRepository:IGenericRepository<ProductCategory>
    {
        Task<ProductCategory> GetProductCategory(int id);
        Task<List<ProductCategory>> GetListProductCategories();
    }
}
