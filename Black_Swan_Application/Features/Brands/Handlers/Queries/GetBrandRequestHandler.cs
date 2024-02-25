using AutoMapper;
using Black_Swan_Application.DTOs.Brand;
using Black_Swan_Application.Features.Brands.Requests.Queries;
using Black_Swan_Application.Persistence.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Black_Swan_Application.Features.Brands.Handlers.Queries
{
    public class GetBrandRequestHandler : IRequestHandler<GetBrandRequest, BrandDto>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public GetBrandRequestHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }
        public async Task<BrandDto> Handle(GetBrandRequest request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.GetBrand(request.id);
            return _mapper.Map<BrandDto>(brand);
        }
    }
}
