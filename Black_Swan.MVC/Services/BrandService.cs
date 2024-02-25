using AutoMapper;
using Black_Swan.MVC.Contracts;
using Black_Swan.MVC.Models;
using Black_Swan.MVC.Services.Base;
using Hanssens.Net;

namespace Black_Swan.MVC.Services
{
    public class BrandService:BaseHttpService,IBrandService
    {
        private readonly IMapper _mapper;
        private readonly IClient _httpclient;
        private readonly IlocalStorageService _localStorage;

        public BrandService(IMapper mapper,IClient httpclient,IlocalStorageService localStorage)
           :base(httpclient, localStorage)
        {
           _mapper = mapper;
           _httpclient = httpclient;
            _localStorage = localStorage;
        }

        public async Task<Response<int>> CreateBrand(CreateBrandVM createBrandVM)
        {
            try
            {
                var response = new Response<int>();
                CreateBrandDto createBrandDto = _mapper.Map<CreateBrandDto>(createBrandVM);

                //Add Auth
                AddBearerToken();
                var apiResponse =await _httpclient.BrandPOSTAsync(createBrandDto);
                if (apiResponse.Success)
                {
                    response.Data = apiResponse.Id;
                    response.Success = true;
                }
                else
                {
                    foreach(var err in apiResponse.Errors)
                    {
                        response.ValidationErrors += err + Environment.NewLine;
                    }
                }
                return response;
            }
        
            catch (ApiException ex) 
            {
                return ConvertApiExceptions<int>(ex);
            }
            
        }

        public async Task<Response<int>> DeleteBrand(int id)
        {
            try
            {
                AddBearerToken();
                await _httpclient.BrandDELETEAsync(id);
                return new Response<int> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<BrandVM> GetBrand(int id)
        {
            AddBearerToken();
            var brand = await _httpclient.GetBrandAsync(id);
            return _mapper.Map<BrandVM>(brand);
        }

        public async Task<List<BrandVM>> GetBrandsList()
        {
            AddBearerToken();
            var brands = await _httpclient.BrandAllAsync();
            return _mapper.Map<List<BrandVM>>(brands);
        }

        public async Task<Response<int>> UpdateBrand(int id,BrandVM brandVM)
        {
            try
            {
                BrandDto brandDto = _mapper.Map<BrandDto>(brandVM);
                AddBearerToken();
                await _httpclient.BrandPUTAsync(id, brandDto);
                return new Response<int> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }
    }
}
