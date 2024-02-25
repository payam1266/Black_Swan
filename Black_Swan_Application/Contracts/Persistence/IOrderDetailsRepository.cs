using Black_Swan_Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Black_Swan_Application.Persistence.Contracts
{
    public interface IOrderDetailsRepository:IGenericRepository<OrderDetails>
    {
        Task<OrderDetails> GetOrderDetailsWithDetails(int id);
        Task<List<OrderDetails>> GetListOrderDetailsWithDetails();
    }
}
