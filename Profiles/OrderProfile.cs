using AutoMapper;
using EcommerceClothes.Entities;
using EcommerceClothes.Models;

namespace EcommerceClothes.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile() {
            CreateMap<OrderDTO, Order>();
            CreateMap<Order, OrderDTO>();
        }
    }
}
