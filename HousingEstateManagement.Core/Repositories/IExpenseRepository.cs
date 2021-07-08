using System.Collections.Generic;
using System.Threading.Tasks;
using HousingEstateManagement.Core.Entities;

namespace HousingEstateManagement.Core.Repositories
{
    public interface IExpenseRepository: IRepository<Expense>
    {
        Task<List<Expense>> GetExpensesWithRelations();
    }
}