using Black_Swan.MVC.Models;
using Black_Swan.MVC.Services.Base;

namespace Black_Swan.MVC.Contracts
{
    public interface ICardItemService
    {
        Task<List<CardItemVM>> GetCardItemsList();
        Task<CardItemVM> GetCardItem(int id);
        Task<Response<int>> CreateCardItem(CardItemVM cardItemVM);
        Task<Response<int>> UpdateCardItem(int id, CardItemVM cardItemVM);
        Task<Response<int>> DeleteCardItem(int id);
    }
}
