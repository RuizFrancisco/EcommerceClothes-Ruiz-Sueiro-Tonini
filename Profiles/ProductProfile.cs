using AutoMapper;
using EcommerceClothes.Entities;
using EcommerceClothes.Models;

namespace EcommerceClothes.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile() 
        {
            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>();
        }
    }
}
