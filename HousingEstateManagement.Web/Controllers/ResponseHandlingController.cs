using Microsoft.AspNetCore.Mvc;

namespace BuildingManager.Web.Controllers
{
    public class ResponseHandlingController : Controller
    {
        [HttpGet]
        public  IActionResult NotFoundPage()
        {
            return View();
        }

        
        [HttpGet]
        public IActionResult InternalServerErrorPage()
        {
            return View();
        }
    }
}