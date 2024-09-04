using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.AppUser.Controllers
{
    [Area("AppUser")]
    [Route("AppUser/Profile")]
    public class ProfileController : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
