using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.OrderDtos.OrderOrderingDtos;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.OrderServices.OrderOrderingServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/OrderAdmin")]
    public class OrderAdminController : Controller
    {
        private readonly IOrderOrderingService _orderOrderingService;
        private readonly IUserService _userService;

        public OrderAdminController(IOrderOrderingService orderOrderingService, IUserService userService)
        {
            _orderOrderingService = orderOrderingService;
            _userService = userService;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Siparişler";
            ViewBag.v3 = "Sipariş Listesi";
            ViewBag.t = "Sipariş İşlemleri";
            List<ResultAllOrderingListDto> ModelOrders = new List<ResultAllOrderingListDto>();
            var appUsers = await _userService.GetAllUserInfo();
            var orders = await _orderOrderingService.GetAllOrderingAsync();
            foreach (var item in orders)
            {
                var appUser = appUsers.Where(x => x.Id == item.UserId).FirstOrDefault();
                ResultAllOrderingListDto modelOrder = new ResultAllOrderingListDto()
                {
                    OrderDate = item.OrderDate,
                    OrderingId = item.OrderingId,
                    TotalPrice = item.TotalPrice,
                    NameSurname = appUser.Name + " " + appUser.Surname
                };
                ModelOrders.Add(modelOrder);
            }
            return View(ModelOrders);
        }
    }
}
