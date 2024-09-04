using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult RefreshMessage()
        {
            return ViewComponent("_HeaderAdminLayoutMessageComponentPartial");
        }
        public IActionResult Refreshcomment()
        {
            return ViewComponent("_HeaderAdminLayoutCommentComponentPartial");
        }
    }
}
