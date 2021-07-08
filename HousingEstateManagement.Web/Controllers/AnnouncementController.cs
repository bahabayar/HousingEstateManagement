using HousingEstateManagement.Core.Dtos;
using HousingEstateManagement.Core.Services;
using HousingEstateManagement.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HousingEstateManagement.Web.Controllers
{
    [AuthorizeByRole(Roles="Admin")]
    public class AnnouncementController : Controller
    {
        private IAnnouncementService _announcementService;

        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllAnnouncement()
        {
            var announcements = await _announcementService.GetAllAsync();
            return View(announcements.Data);
        }
        
        [HttpGet]
        public IActionResult CreateAnnouncement()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnnouncement(AnnouncementDto announcementDto)
        {
            if (!ModelState.IsValid) return View(announcementDto);
            await _announcementService.AddAsync(announcementDto);
            return RedirectToAction("GetAllAnnouncement");
        }
        
        [HttpGet]
        public  IActionResult AnnouncementDelete(int id)
        {
            _announcementService.Remove(id);
            return RedirectToAction("GetAllAnnouncement");
        }
        
        [HttpGet]
        public async Task<IActionResult> UpdateAnnouncement(int id)
        {
            var announcement = await _announcementService.GetByIdAsync(id);
            if (announcement.Data == null) return RedirectToAction("GetAllAnnouncement");
            return View(announcement.Data);
        }
        
        [HttpPost]
        public IActionResult UpdateAnnouncement(AnnouncementDto announcement)
        {
            if (!ModelState.IsValid) return View(announcement);
            _announcementService.Update(announcement);
            return RedirectToAction("GetAllAnnouncement");
        }
        
        
    }
}