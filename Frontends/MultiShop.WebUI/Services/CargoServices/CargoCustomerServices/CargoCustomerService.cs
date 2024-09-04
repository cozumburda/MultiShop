using MultiShop.DtoLayer.CargoDtos.CargoCustomerAddressDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CargoServices.CargoCustomerServices
{
    public class CargoCustomerService : ICargoCustomerService
    {
        private readonly HttpClient _httpClient;

        public CargoCustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCargoCustomerAddressAsync(CreateCargoCustumerAddressDto createCargoCustumerAddressDto)
        {
            await _httpClient.PostAsJsonAsync<CreateCargoCustumerAddressDto>("cargocustomers", createCargoCustumerAddressDto);
        }

        public async Task DeleteCargoCustomerAddressAsync(int id)
        {
            await _httpClient.DeleteAsync("cargocustomers/RemoveCargoCustomer/" + id);
        }

        public async Task<GetCargoCustumerAddressByIdDto> GetCargoCustomerAddressByUserIdAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("cargocustomers/GetCargoCustomerByUserId/" + id);
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<GetCargoCustumerAddressByIdDto>(jsondata);

            return values;
        }

        public async Task<UpdateCargoCustumerAddressDto> GetByIdCargoCustomerAddressAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync("cargocustomers/GetCargoCustomerById/" + id);
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateCargoCustumerAddressDto>(jsondata);
            //var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdCategoryDto>();
            return value;
        }

        public async Task UpdateCargoCustomerAddressAsync(UpdateCargoCustumerAddressDto updateCargoCustumerAddressDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateCargoCustumerAddressDto>("cargocustomers", updateCargoCustumerAddressDto);
        }
    }
}
