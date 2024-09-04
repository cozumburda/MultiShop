using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.OrderDtos.OrderAddressDtos;
using MultiShop.WebUI.Services.OrderServices.AddressServices;

namespace MultiShop.WebUI.Areas.Admin.ViewComponents.AdminAppUserAddressesViewComponents
{
    public class _OrderInvoiceAddressComponentPartial:ViewComponent
    {
        private readonly IOrderAddressService _orderAddressService;

        public _OrderInvoiceAddressComponentPartial(IOrderAddressService orderAddressService)
        {
            _orderAddressService = orderAddressService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var appUserId = ViewData["auId"].ToString();
            var addresses = await _orderAddressService.GetAddressesByUserIdAsync(appUserId);
            var invoiceAddress = addresses.Where(x => x.IsInvoice == true).FirstOrDefault();

            if (invoiceAddress != null)
            {
                return View(invoiceAddress);
            }
            else
            {
                var defaultAddress = addresses.Where(x => x.Isdefault == true).FirstOrDefault();

                if (defaultAddress != null)
                {
                    return View(defaultAddress);
                }
                else
                {
                    UpdateOrderAddressDto? model = new UpdateOrderAddressDto();
                    return View(model);
                }
            }
        }
    }
}
