using Black_Swan_Application.DTOs.Order;
using Black_Swan_Application.Responses;
using Black_Swan_Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Black_Swan_Application.Persistence.Contracts
{
    public interface IOrderRepository:IGenericRepository<Order>
    {
        Task<Order> GetOrder(int id);
        Task<List<Order>> GetListOrders();
       
       
        
    }
}
