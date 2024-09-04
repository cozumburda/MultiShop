using MultiShop.DtoLayer.OrderDtos.OrderOrderingDtos;

namespace MultiShop.WebUI.Services.OrderServices.OrderOrderingServices
{
    public interface IOrderOrderingService
    {
        Task<List<ResultOrderingByUserIdDto>> GetAllOrderingAsync();
        Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserIdAsync(string id);
        Task CreateOrderingAsync(CreateOrderingDto createOrderingDto);
        Task UpdateOrderingAsync(UpdateOrderingDto updateOrderingDto);
        Task DeleteOrderingAsync(int id);
        Task<UpdateOrderingDto> GetByIdOrderingAsync(int id);
    }
}
