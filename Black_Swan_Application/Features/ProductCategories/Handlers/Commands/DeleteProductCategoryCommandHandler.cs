using AutoMapper;
using Black_Swan_Application.Exceptions;
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
    public class DeleteProductCategoryCommandHandler : IRequestHandler<DeleteProductCategoryCommand, Unit>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IMapper _mapper;

        public DeleteProductCategoryCommandHandler(IProductCategoryRepository productCategoryRepository,IMapper mapper)
        {
           _productCategoryRepository = productCategoryRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var productCategory = await _productCategoryRepository.Get(request.id);
            if (productCategory == null)
            {
                throw new NotFoundException(nameof(ProductCategory), request.id);
            }
            await _productCategoryRepository.Delete(productCategory);
            return Unit.Value;
        }
    }
}
