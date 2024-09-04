using MultiShop.DtoLayer.CargoDtos.CargoCustomerAddressDtos;

namespace MultiShop.WebUI.Services.CargoServices.CargoCustomerServices
{
    public interface ICargoCustomerService
    {
        Task<GetCargoCustumerAddressByIdDto> GetCargoCustomerAddressByUserIdAsync(string id);
        Task CreateCargoCustomerAddressAsync(CreateCargoCustumerAddressDto createCargoCustumerAddressDto);
        Task UpdateCargoCustomerAddressAsync(UpdateCargoCustumerAddressDto updateCargoCustumerAddressDto);
        Task DeleteCargoCustomerAddressAsync(int id);
        Task<UpdateCargoCustumerAddressDto> GetByIdCargoCustomerAddressAsync(int id);
    }
}
