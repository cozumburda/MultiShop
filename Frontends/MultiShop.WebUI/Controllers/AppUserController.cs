using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.Interfaces;

namespace MultiShop.WebUI.Controllers
{
    public class AppUserController : Controller
    {
        private readonly IUserService _userService;

        public AppUserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userService.GetUserInfo();
            return View(values);
        }
    }
}
