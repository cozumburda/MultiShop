using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.AppUser.Controllers
{
    public class AppUserLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
