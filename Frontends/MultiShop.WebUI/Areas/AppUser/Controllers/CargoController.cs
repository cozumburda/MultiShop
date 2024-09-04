using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.AppUser.Controllers
{
    [Area("AppUser")]
    [Route("AppUser/Cargo")]
    public class CargoController : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
