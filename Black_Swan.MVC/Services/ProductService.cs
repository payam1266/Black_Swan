using AutoMapper;
using Black_Swan.MVC.Contracts;
using Black_Swan.MVC.Models;
using Black_Swan.MVC.Services.Base;
using System.Net.Http;

namespace Black_Swan.MVC.Services
{
    public class ProductService: BaseHttpService, IProductService
    {
        private readonly IClient _httpclient;
        private readonly IlocalStorageService _localStorageService;
      
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IClient httpclient,IlocalStorageService localStorageService)
            :base(httpclient, localStorageService)
        {
            _httpclient = httpclient;
            _localStorageService = localStorageService;
        
         _mapper = mapper;
        }

        public  async Task<Response<int>> CreateProduct(CreateProductVM createProductVM)
        {

            try
            {
                var response = new Response<int>();
                CreateProductDto createProductDto = _mapper.Map<CreateProductDto>(createProductVM);

                //Add Auth
                AddBearerToken();
                var apiResponse =await  _httpclient.CreateProductAsync(createProductDto);
                if (apiResponse.Success)
                {
                    response.Data = apiResponse.Id;
                    response.Success = true;
                }
                else
                {
                    foreach (var err in apiResponse.Errors)
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

        public async Task<Response<int>> DeleteProduct(int id)
        {
            try
            {
                AddBearerToken();
                await _httpclient.DeleteProductAsync(id);
                return new Response<int> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<List<ProductVM>> GetProductList()
        {
            AddBearerToken();
            var products = await _httpclient.ProductAsync();
            return _mapper.Map<List<ProductVM>>(products);
        }

        public async Task<ProductVM> GetProductWithDetails(int id)
        {
            AddBearerToken();
            var product = await _httpclient.GetProductDtoAsync(id);
            return _mapper.Map<ProductVM>(product);
        }

        public async Task<Response<int>> UpdateProduct(int id, ProductVM productVM)
        {
            try
            {
                UpdateProductDto updateProductDto = _mapper.Map<UpdateProductDto>(productVM);
                AddBearerToken();
                await _httpclient.UpdateProductDtoAsync(id, updateProductDto);
                return new Response<int> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

       
    }
}
