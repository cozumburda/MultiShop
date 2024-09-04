using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.AppUser.Controllers
{
    [Area("AppUser")]
    [Route("AppUser/LogOut")]
    public class LogOutController : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
