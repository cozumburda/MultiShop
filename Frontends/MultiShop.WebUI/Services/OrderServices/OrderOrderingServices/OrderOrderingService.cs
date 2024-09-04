using MultiShop.DtoLayer.OrderDtos.OrderAddressDtos;
using MultiShop.DtoLayer.OrderDtos.OrderOrderingDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.OrderServices.OrderOrderingServices
{
    public class OrderOrderingService : IOrderOrderingService
    {
        private readonly HttpClient _httpClient;

        public OrderOrderingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateOrderingAsync(CreateOrderingDto createOrderingDto)
        {
            await _httpClient.PostAsJsonAsync<CreateOrderingDto>("orderings", createOrderingDto);
        }

        public async Task DeleteOrderingAsync(int id)
        {
            await _httpClient.DeleteAsync("orderings/RemoveOrdering/" + id);
        }

        public async Task<List<ResultOrderingByUserIdDto>> GetAllOrderingAsync()
        {
            var responseMessage = await _httpClient.GetAsync("orderings");
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ResultOrderingByUserIdDto>>(jsondata);
            //var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdCategoryDto>();
            return value;
        }

        public async Task<UpdateOrderingDto> GetByIdOrderingAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync("orderings/" + id);
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateOrderingDto>(jsondata);
            //var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdCategoryDto>();
            return value;
        }

        public async Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserIdAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("orderings/getorderingbyuserid/" + id);
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ResultOrderingByUserIdDto>>(jsondata);
            //var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdCategoryDto>();
            return value;
        }

        public async Task UpdateOrderingAsync(UpdateOrderingDto updateOrderingDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateOrderingDto>("orderings", updateOrderingDto);
        }
    }
}
