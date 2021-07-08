using System.Collections.Generic;
using System.Threading.Tasks;
using HousingEstateManagement.Core.Entities;
using HousingEstateManagement.Core.Repositories;
using HousingEstateManagement.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace HousingEstateManagement.Data.Repositories
{
    public class ExpenseRepository : Repository<Expense>, IExpenseRepository
    {
        public ExpenseRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Expense>> GetExpensesWithRelations()
        {
            return await _context.Expenses
                .Include(x => x.ExpenseType)
                .Include(x => x.Flat)
                .ThenInclude(x => x.User).ToListAsync();
        }
    }
}