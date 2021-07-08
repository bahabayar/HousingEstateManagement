using HousingEstateManagement.Core.Dtos;
using HousingEstateManagement.Core.Services;
using HousingEstateManagement.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HousingEstateManagement.Web.Controllers
{
    [AuthorizeByRole(Roles="Admin")]
    public class FlatController : Controller
    {
        private IFlatService _flatService;
        private IBuildingService _buildingService;
        private IUserService _userService;

        public FlatController(IFlatService flatService, IBuildingService buildingService, IUserService userService)
        {
            _flatService = flatService;
            _buildingService = buildingService;
            _userService = userService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetFlatWithRelations()
        {
            var flats = await _flatService.GetAllFlatsByRelations();
            return View(flats.Data);
        }

        [HttpGet]
        public IActionResult DeleteFlat(int id)
        {
            _flatService.Remove(id);
            return RedirectToAction("GetFlatWithRelations");
        }

        [HttpGet]
        public async Task<IActionResult> CreateFlat()
        {
            var buildingDto = await _buildingService.GetAllAsync();
            var userDto = await _userService.GetAllAsync();
            var flatCreateDto = new FlatCreateDto()
            {
                Buildings = buildingDto.Data,
                Users =  userDto.Data
            };
            return View(flatCreateDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFlat(FlatCreateDto flatCreateDto)
        {
            if (!ModelState.IsValid)  return View(flatCreateDto);
            await _flatService.AddAsync(flatCreateDto);
            return RedirectToAction("GetFlatWithRelations");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFlat(int id)
        {
            var flat = await _flatService.GetByIdAsync(id);
            var buildingDto = await _buildingService.GetAllAsync();
            var userDto = await _userService.GetAllAsync();
            var flatUpdateDto = new FlatUpdateDto()
            {
                Id = flat.Data.Id,
                FlatNumber = flat.Data.FlatNumber,
                IsEmpty = flat.Data.IsEmpty,
                TypeOfFlat = flat.Data.TypeOfFlat,
                Building = buildingDto.Data,
                Users = userDto.Data
            };
            return View(flatUpdateDto);
        }

        [HttpPost]
        public IActionResult UpdateFlat(FlatUpdateDto flatUpdateDto)
        {
            if (!ModelState.IsValid)  return View(flatUpdateDto);
            _flatService.Update(flatUpdateDto);
            return RedirectToAction("GetFlatWithRelations");
        }
        
    }
}