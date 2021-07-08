using HousingEstateManagement.Core.Dtos;
using HousingEstateManagement.Core.Services;
using HousingEstateManagement.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HousingEstateManagement.Web.Controllers
{
    [AuthorizeByRole(Roles="Admin")]
    public class ExpenseTypeController : Controller
    {
        private IExpenseTypeService _expenseTypeService;

        public ExpenseTypeController(IExpenseTypeService expenseTypeService)
        {
            _expenseTypeService = expenseTypeService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllExpenseType()
        {
            var expenseTypes = await _expenseTypeService.GetAllAsync();
            return View(expenseTypes.Data);
        }
        
        [HttpGet]
        public IActionResult CreateExpenseType()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateExpenseType(ExpenseTypeDto expenseTypeDto)
        {
            if (!ModelState.IsValid) return View(expenseTypeDto);
            await _expenseTypeService.AddAsync(expenseTypeDto);
            return RedirectToAction("GetAllExpenseType");
        }
        
        [HttpGet]
        public IActionResult DeleteExpenseType(int id)
        {
            _expenseTypeService.Remove(id);
            return RedirectToAction("GetAllExpenseType");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateExpenseType(int id)
        {
            var expenseType = await _expenseTypeService.GetByIdAsync(id);
            if (expenseType.Data == null)  return RedirectToAction("GetAllExpenseType");
            return View(expenseType.Data);
        }

        [HttpPost]
        public IActionResult UpdateExpenseType(ExpenseTypeDto expenseTypeDto)
        {
            if (!ModelState.IsValid) return View(expenseTypeDto);
            _expenseTypeService.Update(expenseTypeDto);
            return RedirectToAction("GetAllExpenseType");
        }
        
    }
}