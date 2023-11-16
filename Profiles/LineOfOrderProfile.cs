using AutoMapper;
using EcommerceClothes.Entities;
using EcommerceClothes.Models;

namespace EcommerceClothes.Profiles
{
    public class LineOfOrderProfile : Profile
    {
        public LineOfOrderProfile() 
        {
            CreateMap<LineOfOrderDTO, LineOfOrder>();
        }
    }
}
