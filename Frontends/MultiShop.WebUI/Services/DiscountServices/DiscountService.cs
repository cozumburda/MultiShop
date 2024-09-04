using MultiShop.DtoLayer.DiscountDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;

        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto)
        {
            await _httpClient.PostAsJsonAsync<CreateDiscountCouponDto>("Discount", createCouponDto);
        }

        public async Task DeleteDiscountCouponAsync(int id)
        {
            await _httpClient.DeleteAsync("Discount/DeleteDiscountCoupon/" + id);
        }

        public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponsAsync()
        {
            var responseMessage = await _httpClient.GetAsync("Discount");
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ResultDiscountCouponDto>>(jsondata);
            //var value = await responseMessage.Content.ReadFromJsonAsync<List<ResultDiscountCouponDto>>();
            return value;
        }

        public async Task<GetByIdDiscountCouponDto> GetByCodeDiscountCouponAsync(string code)
        {
            var responseMessage = await _httpClient.GetAsync("Discount/GetDiscountCouponByCode/" + code);
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<GetByIdDiscountCouponDto>(jsondata);
            //var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdDiscountCouponDto>();
            return value;
        }

        public async Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync("Discount/GetDiscountCouponById/" + id);
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<GetByIdDiscountCouponDto>(jsondata);
            //var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdCategoryDto>();
            return value;
        }

        public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateDiscountCouponDto>("Discount", updateCouponDto);
        }
    }
}
