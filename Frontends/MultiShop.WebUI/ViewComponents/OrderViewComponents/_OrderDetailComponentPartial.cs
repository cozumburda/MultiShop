using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.OrderDtos.OrderAddressDtos;
using MultiShop.WebUI.Services.OrderServices.AddressServices;

namespace MultiShop.WebUI.ViewComponents.OrderViewComponents
{
    public class _OrderDetailComponentPartial : ViewComponent
    {
        private readonly IOrderAddressService _orderAddressService;

        public _OrderDetailComponentPartial(IOrderAddressService orderAddressService)
        {
            _orderAddressService = orderAddressService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            UpdateOrderAddressDto? addressUpdateModel = new UpdateOrderAddressDto();
            var appUserId = ViewData["uId"].ToString();
            int addressId = ViewData["addressId"] != null ? addressId = int.Parse(ViewData["addressId"].ToString()) : addressId = 0;

            var addresses = await _orderAddressService.GetAddressesByUserIdAsync(appUserId);

            if (addresses.Count > 0)
            {
                if (addressId != 0)
                {
                    addressUpdateModel = await _orderAddressService.GetByIdAddressAsync(addressId);
                    return View(addressUpdateModel);
                }
                addressUpdateModel = addresses.Where(y => y.Isdefault == true).FirstOrDefault();
                if (addressUpdateModel != null)
                {
                    return View(addressUpdateModel);
                }
                else
                {
                    UpdateOrderAddressDto? addressUpdateModeln = new UpdateOrderAddressDto();
                    return View(addressUpdateModeln);
                }
            }
            else
            {
                return View(addressUpdateModel);
            }
        }
    }
}
