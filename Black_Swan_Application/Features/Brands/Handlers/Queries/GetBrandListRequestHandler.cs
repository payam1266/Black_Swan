using AutoMapper;
using Black_Swan_Application.DTOs.Brand;
using Black_Swan_Application.Features.Brands.Requests.Queries;
using Black_Swan_Application.Persistence.Contracts;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Black_Swan_Application.Features.Brands.Handlers.Queries
{
    public class GetBrandListRequestHandler : IRequestHandler<GetBrandListRequest, List<BrandDto>>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public GetBrandListRequestHandler(IBrandRepository brandRepository,IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }
        public async Task<List<BrandDto>> Handle(GetBrandListRequest request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.GetListBrand();
            return _mapper.Map<List<BrandDto>>(brand);

        }
    }
}
