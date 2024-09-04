namespace MultiShop.WebUI.Services.StatisticServices.DiscountStatisticServices
{
    public interface IDiscountStatisticService
    {
        Task<int> GetDiscountCouponsCount();
        Task<int> GetActiveDiscountCouponsCount();
        Task<int> GetPassiveDiscountCouponsCount();
    }
}
