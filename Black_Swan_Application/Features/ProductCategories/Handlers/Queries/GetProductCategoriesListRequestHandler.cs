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
    public class GetProductCategoriesListRequestHandler : IRequestHandler<GetProductCategoriesListRequest, List<ProductCategoryDto>>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IMapper _mapper;

        public GetProductCategoriesListRequestHandler(IProductCategoryRepository productCategoryRepository,IMapper mapper)
        {
            _productCategoryRepository = productCategoryRepository;
            _mapper = mapper;
        }
        public async Task<List<ProductCategoryDto>> Handle(GetProductCategoriesListRequest request, CancellationToken cancellationToken)
        {
            var productCategory = await _productCategoryRepository.GetListProductCategories();
            return _mapper.Map<List<ProductCategoryDto>>(productCategory);
           
        }
    }
}
