using Black_Swan.MVC.Models;
using Black_Swan.MVC.Services.Base;

namespace Black_Swan.MVC.Contracts
{
    public interface IProductService
    {
        Task<List<ProductVM>> GetProductList();
        Task<ProductVM> GetProductWithDetails(int id);
        Task<Response<int>> CreateProduct(CreateProductVM createProductVM);
        Task<Response<int>> UpdateProduct(int id, ProductVM ProductVM);
        Task<Response<int>> DeleteProduct(int id);
    }
}
