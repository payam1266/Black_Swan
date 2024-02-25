using AutoMapper;
using Black_Swan.MVC.Contracts;
using Black_Swan.MVC.Models;
using Black_Swan.MVC.Services.Base;


namespace Black_Swan.MVC.Services
{
    public class OrderDetailsService : BaseHttpService, IOrderDetailsService
    {
        private readonly IMapper _mapper;
        private readonly IClient _httpclient;
        private readonly IlocalStorageService _localStorage;

        public OrderDetailsService(IMapper mapper, IClient httpclient, IlocalStorageService localStorage)
           :base(httpclient, localStorage)
        {
            _mapper = mapper;
            _httpclient = httpclient;
            _localStorage = localStorage;
        }

        public async Task<Response<int>> CreateOrderDetails(OrderDetailsVM orderVM)
        {
            try
            {
                var response = new Response<int>();
                OrderDetailsDto orderDetails = _mapper.Map<OrderDetailsDto>(orderVM);

                //Add Auth
                AddBearerToken();
                var apiResponse = await _httpclient.CreateOrderDetailsAsync(orderDetails);
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

        public Task<Response<int>> DeleteOrderDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDetailsVM> GetOrderDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderDetailsVM>> GetOrderDetailsList()
        {
            throw new NotImplementedException();
        }

        public Task<Response<int>> UpdateOrderDetails(int id, OrderDetailsVM orderVM)
        {
            throw new NotImplementedException();
        }
    } }



