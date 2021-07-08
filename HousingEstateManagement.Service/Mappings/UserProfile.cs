using AutoMapper;
using HousingEstateManagement.Core.Dtos;
using HousingEstateManagement.Core.Entities;

namespace HousingEstateManagement.Service.Mappings
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto,User>().ReverseMap();
            CreateMap<RegisterDto,User>().ReverseMap();
            CreateMap<LoginDto,User>().ReverseMap();
        }
    }
}