using AutoMapper;
using Black_Swan_Application.Features.ProductCategories.Requests.Commands;
using Black_Swan_Application.Persistence.Contracts;
using Black_Swan_Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Black_Swan_Application.Features.ProductCategories.Handlers.Commands
{
    public class CreateProductCategoryCommandHandler : IRequestHandler<CreateProductCategoryCommand, int>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IMapper _mapper;

        public CreateProductCategoryCommandHandler(IProductCategoryRepository productCategoryRepository,IMapper mapper)
        {
            _productCategoryRepository = productCategoryRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var productCategory = _mapper.Map<ProductCategory>(request.ProductCategoryDto);
            productCategory = await _productCategoryRepository.Add(productCategory);
            return productCategory.id;

        }
    }
}
