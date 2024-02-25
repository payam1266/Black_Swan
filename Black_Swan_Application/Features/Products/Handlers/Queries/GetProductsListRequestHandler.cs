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
    public class GetProductsListRequestHandler : IRequestHandler<GetProductsListRequest, List<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductsListRequestHandler(IProductRepository productRepository,IMapper mapper)
        {
            _productRepository = productRepository;
           _mapper = mapper;
        }
        public async Task<List<ProductDto>> Handle(GetProductsListRequest request, CancellationToken cancellationToken)
        {
            var productList = await _productRepository.GetListProductsWithDetails();
            return _mapper.Map<List<ProductDto>>(productList);
        }
    }
}
