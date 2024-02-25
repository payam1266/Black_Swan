using Black_Swan.MVC.Models;
using Black_Swan.MVC.Services.Base;

namespace Black_Swan.MVC.Contracts
{
    public interface IBrandService
    {
        Task<List<BrandVM>> GetBrandsList();
        Task<BrandVM> GetBrand(int id);
        Task<Response<int>> CreateBrand(CreateBrandVM createBrandVM);
        Task<Response<int>> UpdateBrand(int id,BrandVM brandVM);
        Task<Response<int>> DeleteBrand(int id);
    }
}
