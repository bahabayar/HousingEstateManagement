using AutoMapper;
using HousingEstateManagement.Core.Dtos;
using HousingEstateManagement.Core.Entities;

namespace HousingEstateManagement.Service.Mappings
{
    public class ExpenseTypeProfile:Profile 
    {
        public ExpenseTypeProfile()
        {
            CreateMap<ExpenseTypeDto,ExpenseType>().ReverseMap();
        }
    }
}