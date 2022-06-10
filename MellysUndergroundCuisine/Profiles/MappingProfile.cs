using AutoMapper;
using DataAccessLayer.Entities;
using MellysUndergroundCuisine.Models.ViewModels;

namespace MellysUndergroundCuisine.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, AppUserVM>().ReverseMap();
            CreateMap<Dish, DishVM>().ReverseMap();
            CreateMap<Dish, IndexVM>().ReverseMap();
        }
    }
}