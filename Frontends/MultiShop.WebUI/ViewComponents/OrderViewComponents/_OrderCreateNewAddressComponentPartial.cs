using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.OrderDtos.OrderAddressDtos;
using MultiShop.WebUI.Services.OrderServices.AddressServices;

namespace MultiShop.WebUI.ViewComponents.OrderViewComponents
{
    public class _OrderCreateNewAddressComponentPartial : ViewComponent
    {
        private readonly IOrderAddressService _orderAddressService;

        public _OrderCreateNewAddressComponentPartial(IOrderAddressService orderAddressService)
        {
            _orderAddressService = orderAddressService;
        }
        public IViewComponentResult Invoke()
        {
            CreateOrderAddressDto? addressCreateModel = new CreateOrderAddressDto();
            var appUserId = ViewData["uId"].ToString();
            ViewBag.AppUserId = appUserId;
            return View(addressCreateModel);

        }
    }
}
