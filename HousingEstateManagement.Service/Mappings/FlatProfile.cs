using AutoMapper;
using HousingEstateManagement.Core.Dtos;
using HousingEstateManagement.Core.Entities;

namespace BuildingManager.Service.Mappings
{
    public class FlatProfile:Profile
    {
        public FlatProfile()
        {
            CreateMap<FlatDto,Flat>().ReverseMap();
            CreateMap<FlatCreateDto,Flat>().ReverseMap();
            CreateMap<FlatUpdateDto,Flat>().ReverseMap();
        }
    }
}