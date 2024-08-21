using MultiShop.DtoLayer.DiscountDtos;

namespace MultiShop.WebUI.Services.DiscountServices
{
    public interface IDiscountService
    {
        Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponsAsync();
        Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto);
        Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto);
        Task DeleteDiscountCouponAsync(int id);
        Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id);
        Task<GetByIdDiscountCouponDto> GetByCodeDiscountCouponAsync(string code);
    }
}
