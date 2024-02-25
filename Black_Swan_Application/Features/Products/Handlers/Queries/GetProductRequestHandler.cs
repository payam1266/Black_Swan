using AutoMapper;
using Black_Swan_Application.DTOs.Product;
using Black_Swan_Application.Features.Products.Requests.Queries;
using Black_Swan_Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Black_Swan_Application.Features.Products.Handlers.Queries
{
    public class GetProductRequestHandler : IRequestHandler<GetProductRequest, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductRequestHandler(IProductRepository productRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<ProductDto> Handle(GetProductRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductWithDetails(request.id);
            return _mapper.Map<ProductDto>(product);
        }
    }
}
