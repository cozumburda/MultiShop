using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.OrderDtos.OrderAddressDtos;
using MultiShop.WebUI.Services.OrderServices.AddressServices;

namespace MultiShop.WebUI.Areas.Admin.ViewComponents.AdminAppUserAddressesViewComponents
{
    public class _OrderDefaultAddressComponentPartial : ViewComponent
    {
        private readonly IOrderAddressService _orderAddressService;

        public _OrderDefaultAddressComponentPartial(IOrderAddressService orderAddressService)
        {
            _orderAddressService = orderAddressService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var appUserId = ViewData["auId"].ToString();
            var addresses = await _orderAddressService.GetAddressesByUserIdAsync(appUserId);
            var defaultAddress = addresses.Where(x => x.Isdefault == true).FirstOrDefault();

            if (defaultAddress!=null)
            {
                return View(defaultAddress);
            }
            else
            {
                UpdateOrderAddressDto? model=new UpdateOrderAddressDto();
                return View(model);
            }
        }
    }
}
