using AutoMapper;
using EcommerceClothes.Entities;
using EcommerceClothes.Models;

namespace EcommerceClothes.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<UserDTO, Admin>();
            CreateMap<UserDTO, Client>();
        }

    }
}
