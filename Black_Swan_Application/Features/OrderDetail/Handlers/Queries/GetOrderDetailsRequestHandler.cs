using AutoMapper;
using Black_Swan_Application.DTOs.OrderDetails;
using Black_Swan_Application.Features.OrderDetail.Requests.Queries;
using Black_Swan_Application.Persistence.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Black_Swan_Application.Features.OrderDetail.Handlers.Queries
{
    public class GetOrderDetailsRequestHandler : IRequestHandler<GetOrderDetailsRequest, OrderDetailsDto>
    {
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        private readonly IMapper _mapper;

        public GetOrderDetailsRequestHandler(IOrderDetailsRepository orderDetailsRepository, IMapper mapper)
        {
           _mapper = mapper;
            _orderDetailsRepository = orderDetailsRepository;
        }

        public async Task<OrderDetailsDto> Handle(GetOrderDetailsRequest request, CancellationToken cancellationToken)
        {
            var orderDetail = await _orderDetailsRepository.GetOrderDetailsWithDetails(request.id);
            return _mapper.Map<OrderDetailsDto>(orderDetail);
        }
    }
}
