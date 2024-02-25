using AutoMapper;
using Black_Swan_Application.DTOs.OrderDetails;
using Black_Swan_Application.Features.OrderDetail.Requests.Queries;
using Black_Swan_Application.Persistence.Contracts;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Black_Swan_Application.Features.OrderDetail.Handlers.Queries
{
    public class GetListOrderDetailsRequestHandler : IRequestHandler<GetListOrderDetailsRequest, List<OrderDetailsDto>>
    {
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        private readonly IMapper _mapper;

        public GetListOrderDetailsRequestHandler(IOrderDetailsRepository orderDetailsRepository,IMapper mapper)
        {
            _orderDetailsRepository = orderDetailsRepository;
           _mapper = mapper;
        }
        public async Task<List<OrderDetailsDto>> Handle(GetListOrderDetailsRequest request, CancellationToken cancellationToken)
        {
            var OrderDetails = await _orderDetailsRepository.GetListOrderDetailsWithDetails();
            return _mapper.Map<List<OrderDetailsDto>>(OrderDetails);
        }
    }
}
