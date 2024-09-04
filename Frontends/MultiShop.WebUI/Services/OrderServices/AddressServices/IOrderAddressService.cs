using MultiShop.DtoLayer.OrderDtos.OrderAddressDtos;

namespace MultiShop.WebUI.Services.OrderServices.AddressServices
{
    public interface IOrderAddressService
    {
        Task<List<ResultAddressesByUserDto>> GetAllAddressAsync();
        Task<List<UpdateOrderAddressDto>> GetAddressesByUserIdAsync(string id);
        Task CreateAddressAsync(CreateOrderAddressDto createOrderAddressDto);
        Task UpdateAddressAsync(UpdateOrderAddressDto updateOrderAddressDto);
        Task DeleteAddressAsync(int id);
        Task<UpdateOrderAddressDto> GetByIdAddressAsync(int id);
    }
}
