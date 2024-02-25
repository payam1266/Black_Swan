using AutoMapper;
using Black_Swan_Application.Features.OrderDetail.Requests.Commands;
using Black_Swan_Application.Persistence.Contracts;
using Black_Swan_Application.Responses;
using Black_Swan_Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Black_Swan_Application.Features.OrderDetail.Handlers.Commands
{
    public class CreateOrderDetailsCommandHandler : IRequestHandler<CreateOrderDetailsCommand, BaseCommandResponse>
    {
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public CreateOrderDetailsCommandHandler(IOrderDetailsRepository orderDetailsRepository,IMapper mapper,IProductRepository productRepository)
        {
            _orderDetailsRepository = orderDetailsRepository;
            _mapper = mapper;
           _productRepository = productRepository;
        }
        public async Task<BaseCommandResponse> Handle(CreateOrderDetailsCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var orderDetail = _mapper.Map<OrderDetails>(request.OrderDetailsDto);

            orderDetail = await _orderDetailsRepository.Add(orderDetail);
            var product = await _productRepository.Get(request.OrderDetailsDto.productId);
            product.count -= request.OrderDetailsDto.quantity;
            await _productRepository.Update(product);
            response.success = true;
            response.message = "Creation Successful.";
            response.id = orderDetail.id;
            return response;
         

        }
    }
}
