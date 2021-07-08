using HousingEstateManagement.Core.Dtos;
using HousingEstateManagement.SharedLibrary.Results;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace HousingEstateManagement.Core.Services
{
    public interface IExpenseTypeService
    {
        Task<IDataResult<ExpenseTypeDto>> GetByIdAsync(int id);

        Task<IDataResult<List<ExpenseTypeDto>>> GetAllAsync();

        Task<IDataResult<ExpenseTypeDto>> AddAsync(ExpenseTypeDto expenseTypeDto);

        Task<IDataResult<List<ExpenseTypeDto>>> AddRangeAsync(List<ExpenseTypeDto> expenseTypeDtos);

        IResult Remove(int id);

        IResult RemoveRange(List<ExpenseTypeDto> expenseTypeDto);

        IDataResult<ExpenseTypeDto> Update(ExpenseTypeDto expenseTypeDto);
    }
}