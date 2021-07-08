using AutoMapper;
using HousingEstateManagement.Core.Dtos;
using HousingEstateManagement.Core.Entities;

namespace HousingEstateManagement.Service.Mappings
{
    public class MessageProfile:Profile
    {
        public MessageProfile()
        {
            CreateMap<MessageDto, Message>().ReverseMap();
        }
    }
}