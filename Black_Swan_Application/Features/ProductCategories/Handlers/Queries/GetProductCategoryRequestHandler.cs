using AutoMapper;
using Black_Swan_Application.DTOs.ProductCategory;
using Black_Swan_Application.Features.ProductCategories.Requests.Queries;
using Black_Swan_Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Black_Swan_Application.Features.ProductCategories.Handlers.Queries
{
    public class GetProductCategoryRequestHandler : IRequestHandler<GetProductCategoryRequest, ProductCategoryDto>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IMapper _mapper;

        public GetProductCategoryRequestHandler(IProductCategoryRepository productCategoryRepository,IMapper mapper)
        {
            _productCategoryRepository = productCategoryRepository;
            _mapper = mapper;
        }
        public async Task<ProductCategoryDto> Handle(GetProductCategoryRequest request, CancellationToken cancellationToken)
        {
            var productCategory = await _productCategoryRepository.GetProductCategory(request.id);
            return _mapper.Map<ProductCategoryDto>(productCategory);
        }
    }
}
