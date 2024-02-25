using AutoMapper;
using Black_Swan_Application.Features.ProductCategories.Requests.Commands;
using Black_Swan_Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Black_Swan_Application.Features.ProductCategories.Handlers.Commands
{
    public class UpdateProductCategoryCommandHandler : IRequestHandler<UpdateProductCategoryCommand, Unit>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IMapper _mapper;

        public UpdateProductCategoryCommandHandler(IProductCategoryRepository productCategoryRepository,IMapper mapper)
        {
           _productCategoryRepository = productCategoryRepository;
           _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var productCategory = await _productCategoryRepository.Get(request.ProductCategoryDto.id);
            _mapper.Map(request.ProductCategoryDto, productCategory);
            await _productCategoryRepository.Update(productCategory);
            return Unit.Value;
        }
    }
}
