using HousingEstateManagement.Core.Entities;
using HousingEstateManagement.Core.Repositories;
using HousingEstateManagement.Data.Context;
namespace HousingEstateManagement.Data.Repositories
{
    public class ExpenseTypeRepository: Repository<ExpenseType>, IExpenseTypeRepository
    {
        public ExpenseTypeRepository(AppDbContext context) : base(context)
        {
        }
    }
}