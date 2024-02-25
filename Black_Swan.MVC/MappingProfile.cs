using AutoMapper;
using Black_Swan.MVC.Models;
using Black_Swan.MVC.Services.Base;


namespace Black_Swan.MVC
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<BrandDto, BrandVM>().ReverseMap();
            CreateMap<CreateBrandDto, CreateBrandVM>().ReverseMap();
            CreateMap<CreateProductDto, CreateProductVM>().ReverseMap();
            CreateMap<ProductDto, ProductVM>().ReverseMap();
            CreateMap<UpdateProductDto, ProductVM>().ReverseMap();
            CreateMap<CityDto, CityVM>().ReverseMap();
            CreateMap<ProductCategoryDto, ProductCategoryVM>().ReverseMap();
            CreateMap<CardItemDto, CardItemVM>().ReverseMap();
            CreateMap<OrderDto, OrderVM>().ReverseMap();
            CreateMap<OrderDetailsDto, OrderDetailsVM>().ReverseMap();
           
        }
    }
}
