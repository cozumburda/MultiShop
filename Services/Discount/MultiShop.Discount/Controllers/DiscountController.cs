using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }
        [HttpGet]
        public async Task<IActionResult> DiscountCouponsList()
        {
            var values = await _discountService.GetAllDiscountCouponsAsync();
            return Ok(values);
        }

        [HttpGet("GetDiscountCouponById/{id}")]
        public async Task<IActionResult> GetDiscountCouponById(int id)
        {
            var value = await _discountService.GetByIdDiscountCouponAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDiscountCoupon(CreateDiscountCouponDto createCouponDto)
        {
            await _discountService.CreateDiscountCouponAsync(createCouponDto);
            return Ok("Kupon Başarıyla Oluşturuldu");
        }
        [HttpDelete("DeleteDiscountCoupon/{id}")]
        public async Task<IActionResult> DeleteDiscountCoupon(int id)
        {
            await _discountService.DeleteDiscountCouponAsync(id);
            return Ok("Kupon Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCoupon(UpdateDiscountCouponDto updateCouponDto)
        {
            await _discountService.UpdateDiscountCouponAsync(updateCouponDto);
            return Ok("Kupon Başarı ile Güncellendi");
        }
        [HttpGet("GetDiscountCouponByCode/{code}")]        
        public async Task<IActionResult> GetDiscountCouponByCode(string code)
        {
            var value = await _discountService.GetByCouponCodeAndIsValidDiscountCouponAsync(code);
            return Ok(value);
        }
        [HttpGet("GetDiscountCouponsCount")]
        public async Task<IActionResult> GetDiscountCouponsCount()
        {
            var value = await _discountService.GetDiscountCouponsCount();
            return Ok(value);
        }
        [HttpGet("GetActiveDiscountCouponsCount")]
        public async Task<IActionResult> GetActiveDiscountCouponsCount()
        {
            var value = await _discountService.GetActiveDiscountCouponsCount();
            return Ok(value);
        }
        [HttpGet("GetPassiveDiscountCouponsCount")]
        public async Task<IActionResult> GetPassiveDiscountCouponsCount()
        {
            var value = await _discountService.GetPassiveDiscountCouponsCount();
            return Ok(value);
        }
    }
}
