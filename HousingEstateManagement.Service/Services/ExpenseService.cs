using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HousingEstateManagement.Core.Dtos;
using HousingEstateManagement.Core.Entities;
using HousingEstateManagement.Core.Repositories;
using HousingEstateManagement.Core.Services;
using HousingEstateManagement.Core.UnitOfWorks;
using HousingEstateManagement.SharedLibrary.Results;

namespace HousingEstateManagement.Service.Services
{ 
    public class ExpenseService:IExpenseService
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        private IExpenseRepository _expenseRepository;
        private IFlatRepository _flatRepository;

        public ExpenseService(IMapper mapper, IUnitOfWork unitOfWork, IExpenseRepository expenseRepository, IFlatRepository flatRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _expenseRepository = expenseRepository;
            _flatRepository = flatRepository;
        }

        public async Task<IDataResult<ExpenseDto>> GetByIdAsync(int id)
        {
            var expenseDto = _mapper.Map<ExpenseDto>(await _unitOfWork.Expense.GetByIdAsync(id));
            if (expenseDto != null)
            {
                return new SuccessDataResult<ExpenseDto>(expenseDto);
            }
            return new ErrorDataResult<ExpenseDto>();
        }

        public async Task<IDataResult<List<ExpenseDto>>> GetAllAsync()
        {
            var expenseDtos = _mapper.Map<List<ExpenseDto>>(await _unitOfWork.Expense.GetAllAsync());
            if (expenseDtos != null)
            {
                return new SuccessDataResult<List<ExpenseDto>>(expenseDtos);
            }
            return new ErrorDataResult<List<ExpenseDto>>();
        }

        public async Task<IDataResult<CreateExpenseDto>> AddAsync(CreateExpenseDto createExpenseDto)
        {
            var expense = _mapper.Map<Expense>(createExpenseDto);
            await _expenseRepository.AddAsync(expense);
            await _unitOfWork.CommitAsync();
            return new SuccessDataResult<CreateExpenseDto>(createExpenseDto);
        }

        public async Task<IDataResult<List<CreateExpenseDto>>> AddRangeAsync(List<CreateExpenseDto> createExpenseDtos)
        {
            var expense = _mapper.Map<List<Expense>>(createExpenseDtos);
            await _expenseRepository.AddRangeAsync(expense);
            await _unitOfWork.CommitAsync();
            return new SuccessDataResult<List<CreateExpenseDto>>(createExpenseDtos);
        }

        public Result Remove(int id)
        {
            var expense = _expenseRepository.GetByIdAsync(id).Result;
            _expenseRepository.Remove(expense);
            _unitOfWork.Commit();
            return new SuccessResult();
        }

        public Result RemoveRange(List<ExpenseDto> expenseDto)
        {
            var expenses = _mapper.Map<List<Expense>>(expenseDto);
            _expenseRepository.RemoveRange(expenses);
            _unitOfWork.Commit();
            return new SuccessResult();
        }

        public IDataResult<UpdateExpenseDto> Update(UpdateExpenseDto updateExpenseDto)
        {
            var expense = _mapper.Map<Expense>(updateExpenseDto);
            _expenseRepository.Update(expense);
            _unitOfWork.Commit();
            return new SuccessDataResult<UpdateExpenseDto>(updateExpenseDto);
        }
        public IDataResult<PaymentExpenseDto> UpdateForPayment(PaymentExpenseDto paymentExpenseDto)
        {
            var expense = _mapper.Map<Expense>(paymentExpenseDto);
            _expenseRepository.Update(expense);
            _unitOfWork.Commit();
            return new SuccessDataResult<PaymentExpenseDto>(paymentExpenseDto);
        }
        public async Task<IDataResult<PaymentExpenseDto>> GetByIdForPayment(int id)
        {
            var expenseDto = _mapper.Map<PaymentExpenseDto>(await _unitOfWork.Expense.GetByIdAsync(id));
            if (expenseDto != null)
            {
                return new SuccessDataResult<PaymentExpenseDto>(expenseDto); 
            }
            return new ErrorDataResult<PaymentExpenseDto>();
        }

        public async Task<IDataResult<List<ExpenseDto>>> GetExpensesWithRelations()
        {
            var expenses = await _expenseRepository.GetExpensesWithRelations();
            var expenseDtos = expenses.Select(e => new ExpenseDto()
            {
                Id = e.Id,
                IsPaid = e.IsPaid,
                Price = e.Price,
                InvoiceDate = e.InvoiceDate,
                FlatNumber = e.Flat.FlatNumber,
                UserName = e.Flat.User.UserName,
                ExpenseTypeName = e.ExpenseType.ExpenseTypeName
            }).ToList();
            return new SuccessDataResult<List<ExpenseDto>>(expenseDtos);
        }

        public async Task<IResult> AddDebtMultiple(CreateExpenseDto createExpenseDto)
        {
            var flats = _mapper.Map<List<FlatDto>>(await _flatRepository.GetAllAsync());
            var expenseDtoList = flats.Select(f => new CreateExpenseDto()
            {
                FlatId = f.Id,
                InvoiceDate = DateTime.Now,
                Price = createExpenseDto.Price,
                ExpenseTypeId = createExpenseDto.ExpenseTypeId,
                IsPaid = false
            }).ToList();
            await AddRangeAsync(expenseDtoList);
            return new SuccessResult();
        }
    }
}