using AutoMapper;
using Black_Swan.MVC.Contracts;
using Black_Swan.MVC.Models;
using Black_Swan.MVC.Services.Base;

namespace Black_Swan.MVC.Services
{
    public class CardItemService:BaseHttpService,ICardItemService
    {
        private readonly IMapper _mapper;
        private readonly IClient _httpclient;
        private readonly IlocalStorageService _localStorage;

        public CardItemService(IMapper mapper, IClient httpclient, IlocalStorageService localStorage)
           : base(httpclient, localStorage)
        {
            _mapper = mapper;
            _httpclient = httpclient;
            _localStorage = localStorage;
        }

        public async Task<Response<int>> CreateCardItem(CardItemVM cardItemVM)
        {
            try
            {
                var response = new Response<int>();
                CardItemDto cardItemDto = _mapper.Map<CardItemDto>(cardItemVM);
                AddBearerToken();
                var apiresponse = await _httpclient.CardItemPOSTAsync(cardItemDto);
                if (apiresponse.Success)
                {
                    response.Data = apiresponse.Id;
                    response.Success = true;
                }
                else
                {
                    foreach (var err in apiresponse.Errors)
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

        public async Task<Response<int>> DeleteCardItem(int id)
        {
            try
            {
                AddBearerToken();
                await _httpclient.CardItemDELETEAsync(id);
                return new Response<int> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<CardItemVM> GetCardItem(int id)
        {
            AddBearerToken();
            var cardItem = await _httpclient.GetCardItemAsync(id);
            return _mapper.Map<CardItemVM>(cardItem);
        }

        public async Task<List<CardItemVM>> GetCardItemsList()
        {
            AddBearerToken();
            var cardItems = await _httpclient.CardItemAllAsync();
            return _mapper.Map<List<CardItemVM>>(cardItems);
        }

        public async Task<Response<int>> UpdateCardItem(int id, CardItemVM cardItemVM)
        {
            try
            {
                CardItemDto cardItemDto = _mapper.Map<CardItemDto>(cardItemVM);
                AddBearerToken();
                await _httpclient.UpdateCardItemAsync(id, cardItemDto);
                return new Response<int> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }
    }
}
