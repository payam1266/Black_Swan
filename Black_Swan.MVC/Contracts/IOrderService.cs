using Black_Swan.MVC.Models;
using Black_Swan.MVC.Services.Base;

namespace Black_Swan.MVC.Contracts
{
    public interface IOrderService
    {
        Task<List<OrderVM>> GetOrders();
        Task<OrderVM> GetOrder(int id);
        Task<Response<int>> CreateOrder(OrderVM orderVM);
        Task<Response<int>> UpdateOrder(int id, OrderVM orderVM);
        Task<Response<int>> DeleteOrder(int id);
    }
}
