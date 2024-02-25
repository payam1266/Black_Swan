using Black_Swan.MVC.Models;
using Black_Swan.MVC.Services.Base;


namespace Black_Swan.MVC.Contracts
{
    public interface IOrderDetailsService
    {
        Task<List<OrderDetailsVM>> GetOrderDetailsList();
        Task<OrderDetailsVM> GetOrderDetails(int id);
        Task<Response<int>> CreateOrderDetails(OrderDetailsVM orderVM);
        Task<Response<int>> UpdateOrderDetails(int id, OrderDetailsVM orderVM);
        Task<Response<int>> DeleteOrderDetails(int id);
    }
}
