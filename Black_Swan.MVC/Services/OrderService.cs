using AutoMapper;
using Black_Swan.MVC.Contracts;
using Black_Swan.MVC.Models;
using Black_Swan.MVC.Services.Base;

namespace Black_Swan.MVC.Services
{
    public class OrderService:BaseHttpService, IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IClient _httpclient;
        private readonly IlocalStorageService _localStorage;

        public OrderService(IMapper mapper, IClient httpclient, IlocalStorageService localStorage)
           : base(httpclient, localStorage)
        {
            _mapper = mapper;
            _httpclient = httpclient;
            _localStorage = localStorage;
        }

        public async Task<Response<int>> CreateOrder(OrderVM orderVM)
        {
            try
            {
                var response = new Response<int>();
                OrderDto orderDto = _mapper.Map<OrderDto>(orderVM);

                //Add Auth
                AddBearerToken();
                var apiResponse = await _httpclient.CreateOrderAsync(orderDto);
                if (apiResponse.Success)
                {
                    response.Data = apiResponse.Id;
                    response.Success = true;
                }
                else
                {
                    foreach (var err in apiResponse.Errors)
                    {
                        response.ValidationErrors += err + Environment.NewLine;
                    }
                }
                return response;
            }

            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }

        }

        public async Task<Response<int>> DeleteOrder(int id)
        {
            try
            {
                AddBearerToken();
                await _httpclient.DeleteOrderAsync(id);
                return new Response<int> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<OrderVM> GetOrder(int id)
        {
            AddBearerToken();
            var orders = await _httpclient.GetOrderDtoAsync(id);
            return _mapper.Map<OrderVM>(orders);
        }

        public async Task<List<OrderVM>> GetOrders()
        {
            AddBearerToken();
            var orders = await _httpclient.OrderAsync();
            return _mapper.Map<List<OrderVM>>(orders);
        }

        public Task<Response<int>> UpdateOrder(int id, OrderVM orderVM)
        {
            throw new NotImplementedException();
        }
    }
}
