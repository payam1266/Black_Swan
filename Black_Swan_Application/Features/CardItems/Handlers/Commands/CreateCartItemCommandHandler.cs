using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Black_Swan_Application.Contracts.Identity;
using Black_Swan_Application.DTOs.CardItem.Validators;
using Black_Swan_Application.DTOs.Product.Validators;
using Black_Swan_Application.Features.CardItems.Requests.Commands;
using Black_Swan_Application.Persistence.Contracts;
using Black_Swan_Application.Responses;
using Black_Swan_Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Black_Swan_Application.Features.CardItems.Handlers.Commands
{
    public class CreateCartItemCommandHandler : IRequestHandler<CreateCartItemCommand, BaseCommandResponse>
    {
        private readonly ICardItemRepository _cardItemRepository;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IAuthService _authService;

        public CreateCartItemCommandHandler(ICardItemRepository cardItemRepository, IMapper mapper, IProductRepository productRepository,IAuthService authService)
        {
            _cardItemRepository = cardItemRepository;
            _mapper = mapper;
            _productRepository = productRepository;
           _authService = authService;
        }
        public async Task<BaseCommandResponse> Handle(CreateCartItemCommand request, CancellationToken cancellationToken)
        {

            

            var response = new BaseCommandResponse();


            var validator = new CardItemDtoValidator(
                _productRepository);
            var validatorResult = await validator.ValidateAsync(request.CardItemDto);
            if (validatorResult.IsValid == false)
            {
                
                response.success = false;
                response.message = "creation failed";
                response.errors = validatorResult.Errors.Select(x => x.ErrorMessage).ToList();

            }
            else
            {

                var userid =  _authService.GetUserDetails(request.CardItemDto.userid);
             
                var cartItem = _mapper.Map<CardItem>(request.CardItemDto);
                var cardItem = await _cardItemRepository.Add(cartItem);
                response.success = true;
                response.message = "creation Success";
                response.id = cardItem.id;
            }
            return response;

        }
    }
}
