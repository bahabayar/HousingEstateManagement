using HousingEstateManagement.Core.Dtos;
using HousingEstateManagement.Core.Services;
using HousingEstateManagement.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HousingEstateManagement.Web.Controllers
{
    [AuthorizeByRole(Roles="Admin")]
    public class BuildingController : Controller
    {
        private IBuildingService _buildingService;

        public BuildingController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllBuildings()
        {
            var buildings = await _buildingService.GetAllAsync();
            return View(buildings.Data);
        }

        [HttpGet]
        public IActionResult CreateBuilding()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBuilding(BuildingDto buildingDto)
        {
            if (!ModelState.IsValid)  return View(buildingDto);
            await _buildingService.AddAsync(buildingDto);
            return RedirectToAction("GetAllBuildings");
        }
        
        [HttpGet]
        public IActionResult DeleteBuilding(int id)
        {
            _buildingService.Remove(id);
            return RedirectToAction("GetAllBuildings");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBuilding(int id)
        {
            var building = await _buildingService.GetByIdAsync(id);
            if (building.Data == null)  return RedirectToAction("GetAllBuildings");
            return View(building.Data);
        }
        
        [HttpPost]
        public IActionResult UpdateBuilding(BuildingDto buildingDto)
        {
            if (!ModelState.IsValid) return View(buildingDto);
            _buildingService.Update(buildingDto);
            return RedirectToAction("GetAllBuildings");
        }
        
    }
}