using AutoMapper;
using HousingEstateManagement.Core.Dtos;
using HousingEstateManagement.Core.Entities;

namespace HousingEstateManagement.Service.Mappings
{
    public class BuildingProfile:Profile
    {
        public BuildingProfile()
        {
            CreateMap<BuildingDto, Building>().ReverseMap();
        }
    }
}