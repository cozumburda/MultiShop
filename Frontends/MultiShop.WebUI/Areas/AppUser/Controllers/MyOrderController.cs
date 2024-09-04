using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.OrderServices.OrderOrderingServices;

namespace MultiShop.WebUI.Areas.AppUser.Controllers
{
    [Area("AppUser")]
    [Route("AppUser/MyOrder")]
    public class MyOrderController : Controller
    {
        private readonly IUserService _userService;
        private readonly IOrderOrderingService _orderOrderingService;

        public MyOrderController(IUserService userService, IOrderOrderingService orderOrderingService)
        {
            _userService = userService;
            _orderOrderingService = orderOrderingService;
        }
        [Route("MyOrderList")]
        public async Task<IActionResult> MyOrderList()
        {
            var appUser = await _userService.GetUserInfo();
            var orders = await _orderOrderingService.GetOrderingByUserIdAsync(appUser.Id);
            return View(orders);
        }
    }
}
