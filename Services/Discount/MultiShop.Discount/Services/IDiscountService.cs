using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponsAsync();
        Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto);
        Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto);
        Task DeleteDiscountCouponAsync(int id);
        Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id);
        Task<GetByIdDiscountCouponDto> GetByCouponCodeAndIsValidDiscountCouponAsync(string code);
        Task<int> GetDiscountCouponsCount();
        Task<int> GetActiveDiscountCouponsCount();
        Task<int> GetPassiveDiscountCouponsCount();
    }
}
