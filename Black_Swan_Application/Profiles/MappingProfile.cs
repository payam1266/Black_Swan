using AutoMapper;
using AutoMapper.Configuration;
using Black_Swan_Application.Contracts.Identity;
using Black_Swan_Application.DTOs.Brand;
using Black_Swan_Application.DTOs.CardItem;
using Black_Swan_Application.DTOs.City;
using Black_Swan_Application.DTOs.Order;
using Black_Swan_Application.DTOs.OrderDetails;
using Black_Swan_Application.DTOs.Product;
using Black_Swan_Application.DTOs.ProductCategory;
using Black_Swan_Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Black_Swan_Application.Profiles
{
    public class MappingProfile : Profile
    {
       

        public MappingProfile()
        {
            #region Product Mapping
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
          
            #endregion

            #region ProductCategory Mapping
            CreateMap<ProductCategory, ProductCategoryDto>().ReverseMap();
            #endregion
            #region City Mapping
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<City, CreateCityDto>().ReverseMap();
            #endregion
            #region Brand Mapping
            CreateMap<Brand, BrandDto>().ReverseMap();
            CreateMap<Brand, CreateBrandDto>().ReverseMap();
            #endregion
            #region Order Mapping
            CreateMap<Order, OrderDto>().ReverseMap();
            #endregion
            #region OrderDetails Mapping
            CreateMap<OrderDetails, OrderDetailsDto>().ReverseMap();
            #endregion
            #region CardItem Mapping
            //CreateMap<CardItemDto, CardItem>().ForMember(dest => dest.userid, opt => opt.MapFrom(src => GetUserId(src.userid)));
            CreateMap<CardItem, CardItemDto>().ReverseMap();
         


            #endregion
            //CreateMap<Product, CreateProductDto>().ReverseMap()
            //     .ForMember(dest => dest.img, opt => opt.MapFrom(src => src.img?.ReadAsByteArrayAsync()));
            //.ForMember(dest => dest.UserName, i => i.MapFrom(src => src.FirstName + " " + src.LastName))
            //CreateMap<User, UserViewModel>()
            //    .ForMember(dest => dest.UserName, i => i.MapFrom(src => src.FirstName + " " + src.LastName))
            //    .ForMember(dest => dest.Age, i =>
            //    {
            //        i.PreCondition(src => src.Age > 21);
            //        i.MapFrom(src => src.Age);
            //    });
            //CreateMap<User, UserViewModel>()
            //    .ForMember(dest => dest.UserName, i => i.MapFrom(src => src.FirstName + " " + src.LastName))
            //    .ForMember(dest => dest.Age, i => i.MapFrom(src => src.Age > 21 ? src.Age : -1));

            //var userQueryable = users.AsQueryable();

            //var usersViewModel = _mapper.ProjectTo<UserViewModel>(userQueryable);
        }
     
    }
}
