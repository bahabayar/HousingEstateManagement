using AutoMapper;
using HousingEstateManagement.Core.Dtos;
using HousingEstateManagement.Core.Entities;
using HousingEstateManagement.Core.Repositories;
using HousingEstateManagement.Core.Services;
using HousingEstateManagement.Core.UnitOfWorks;
using HousingEstateManagement.SharedLibrary.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HousingEstateManagement.Service.Services
{
    public class ExpenseTypeService:IExpenseTypeService
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        private IExpenseTypeRepository _expenseTypeRepository;

        public ExpenseTypeService(IMapper mapper, IUnitOfWork unitOfWork, IExpenseTypeRepository expenseTypeRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _expenseTypeRepository = expenseTypeRepository;
        }

        public async Task<IDataResult<ExpenseTypeDto>> GetByIdAsync(int id)
        {
            var expenseTypeDto = _mapper.Map<ExpenseTypeDto>(await _unitOfWork.ExpenseTypes.GetByIdAsync(id));
            if (expenseTypeDto != null)
            {
                return new SuccessDataResult<ExpenseTypeDto>(expenseTypeDto);
            }
            return new ErrorDataResult<ExpenseTypeDto>();
        }

        public async Task<IDataResult<List<ExpenseTypeDto>>> GetAllAsync()
        {
            var expenseTypeDtos = _mapper.Map<List<ExpenseTypeDto>>(await _unitOfWork.ExpenseTypes.GetAllAsync());
            if (expenseTypeDtos != null)
            {
                return new SuccessDataResult<List<ExpenseTypeDto>>(expenseTypeDtos);
            }
            return new ErrorDataResult<List<ExpenseTypeDto>>();
        }

        public async Task<IDataResult<ExpenseTypeDto>> AddAsync(ExpenseTypeDto expenseTypeDto)
        {
            var expense = _mapper.Map<ExpenseType>(expenseTypeDto);
            await _expenseTypeRepository.AddAsync(expense);
            await _unitOfWork.CommitAsync();
            return new SuccessDataResult<ExpenseTypeDto>(expenseTypeDto);
        }

        public async Task<IDataResult<List<ExpenseTypeDto>>> AddRangeAsync(List<ExpenseTypeDto> expenseTypeDtos)
        {
            var expense = _mapper.Map<List<ExpenseType>>(expenseTypeDtos);
            await _expenseTypeRepository.AddRangeAsync(expense);
            await _unitOfWork.CommitAsync();
            return new SuccessDataResult<List<ExpenseTypeDto>>(expenseTypeDtos);
        }

        public IResult Remove(int id)
        {
            var expenseType = _expenseTypeRepository.GetByIdAsync(id).Result;
            _expenseTypeRepository.Remove(expenseType);
            _unitOfWork.Commit();
            return new SuccessResult();
        }

        public IResult RemoveRange(List<ExpenseTypeDto> expenseTypeDto)
        {
            var expenseType = _mapper.Map<List<ExpenseType>>(expenseTypeDto);
            _expenseTypeRepository.RemoveRange(expenseType);
            _unitOfWork.Commit();
            return new SuccessResult();
        }
        
        public IDataResult<ExpenseTypeDto> Update(ExpenseTypeDto expenseTypeDto)
        {
            var expenseType = _mapper.Map<ExpenseType>(expenseTypeDto);
            _expenseTypeRepository.Update(expenseType);
            _unitOfWork.Commit();
            return new SuccessDataResult<ExpenseTypeDto>(expenseTypeDto);
        }
    }
}