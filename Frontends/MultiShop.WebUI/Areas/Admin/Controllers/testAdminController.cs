using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class testAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
    }
}
