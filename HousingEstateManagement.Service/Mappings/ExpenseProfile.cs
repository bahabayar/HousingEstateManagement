using AutoMapper;
using HousingEstateManagement.Core.Dtos;
using HousingEstateManagement.Core.Entities;

namespace HousingEstateManagement.Service.Mappings
{
    public class ExpenseProfile:Profile
    {
        public ExpenseProfile()
        {
            CreateMap<ExpenseDto,Expense>().ReverseMap();
            CreateMap<CreateExpenseDto,Expense>().ReverseMap();
            CreateMap<UpdateExpenseDto,Expense>().ReverseMap();
            CreateMap<PaymentExpenseDto, Expense>().ReverseMap();
        }
    }
}