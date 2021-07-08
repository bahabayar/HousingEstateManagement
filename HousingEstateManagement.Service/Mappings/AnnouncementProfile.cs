using AutoMapper;
using HousingEstateManagement.Core.Dtos;
using HousingEstateManagement.Core.Entities;

namespace HousingEstateManagement.Service.Mappings
{
    public class AnnouncementProfile:Profile
    {
        public AnnouncementProfile()
        {
            CreateMap<AnnouncementDto, Announcement>().ReverseMap();
        }
    }
}