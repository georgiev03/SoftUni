using AutoMapper;
using Microsoft.EntityFrameworkCore.Migrations;
using ProductShop.Dtos.Input;
using ProductShop.Dtos.Output;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<UserInputDto, User>();

            this.CreateMap<ProductInputDto, Product>();

            this.CreateMap<CategoryInputDto, Category>();

            this.CreateMap<CategoryProductInputDto, CategoryProduct>();

            this.CreateMap<Product, ProductOutputDto>()
                .ForMember(x => x.Seller,
                    y => y.MapFrom
                        (s => $"{s.Seller.FirstName} {s.Seller.LastName}"));
        }
    }
}
