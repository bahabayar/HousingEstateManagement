using HousingEstateManagement.Core.Dtos;
using HousingEstateManagement.Core.Services;
using HousingEstateManagement.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HousingEstateManagement.Web.Controllers
{
    [AuthorizeByRole(Roles="Admin")]
    public class ExpenseController : Controller
    {
        private readonly IExpenseService _expenseService;
        private readonly IExpenseTypeService _expenseTypeService;
        private readonly IFlatService _flatService;

        public ExpenseController(IExpenseService expenseService, IExpenseTypeService expenseTypeService, IFlatService flatService)
        {
            _expenseService = expenseService;
            _expenseTypeService = expenseTypeService;
            _flatService = flatService;
        }

        [HttpGet]
        public async Task<IActionResult> GetExpenseWithRelations()
        {
            var expenses = await _expenseService.GetExpensesWithRelations();
            return View(expenses.Data);
        }

        [HttpGet]
        public async Task<IActionResult> GetUnpaidExpense()
        {
            var expenses = await _expenseService.GetExpensesWithRelations();
            var unpaidExpense = expenses.Data.Where(e=>e.IsPaid==false).ToList();
            return View(unpaidExpense);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetPaidExpense()
        {
            var expenses = await _expenseService.GetExpensesWithRelations();
            var paidExpenses = expenses.Data.Where(e=>e.IsPaid==true).ToList();
            return View(paidExpenses);
        }
        
        [HttpGet]
        public IActionResult DeleteExpense(int id)
        {
            _expenseService.Remove(id);
            return RedirectToAction("GetExpenseWithRelations");
        }

        [HttpGet]
        public async Task<IActionResult> CreateExpense()
        {
            var expenseTypes = await _expenseTypeService.GetAllAsync();
            var flats = await _flatService.GetAllAsync();
            var createExpense = new CreateExpenseDto
            {
                ExpenseTypes = expenseTypes.Data,
                Flats = flats.Data
            };
            return View(createExpense);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExpense(CreateExpenseDto createExpenseDto)
        {
            if (!ModelState.IsValid) return View(createExpenseDto);
            createExpenseDto.InvoiceDate = DateTime.Now;
            createExpenseDto.IsPaid = false;
            await _expenseService.AddAsync(createExpenseDto);
            return RedirectToAction("GetExpenseWithRelations");
        }

        [HttpGet]
        public async Task<IActionResult> AddExpenseToAll()
        {
            var expenseTypes =await _expenseTypeService.GetAllAsync();
            var flats = await _flatService.GetAllAsync();
            var createExpense = new CreateExpenseDto
            {
                ExpenseTypes = expenseTypes.Data,
                Flats = flats.Data
            };
            return View(createExpense);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddExpenseToAll(CreateExpenseDto expenses)
        {
            if (!ModelState.IsValid) return View(expenses);
            await _expenseService.AddDebtMultiple(expenses);
            return RedirectToAction("GetExpenseWithRelations");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateExpense(int id)
        {
            var expense = await _expenseService.GetByIdAsync(id);
            var expenseTypes = await _expenseTypeService.GetAllAsync();
            var flats = await _flatService.GetAllAsync();
            var expenseToUpdate = new UpdateExpenseDto()
            {
                Id = expense.Data.Id,
                IsPaid = expense.Data.IsPaid,
                Price = expense.Data.Price,
                InvoiceDate = DateTime.Now,
                ExpenseTypes = expenseTypes.Data,
                Flats = flats.Data
            };
            return View(expenseToUpdate);
        }
        
        [HttpPost]
        public IActionResult UpdateExpense(UpdateExpenseDto updateExpenseDto)
        {
            if (!ModelState.IsValid)  return View(updateExpenseDto);
            _expenseService.Update(updateExpenseDto);
            return RedirectToAction("GetExpenseWithRelations");
        }
     
    }
}