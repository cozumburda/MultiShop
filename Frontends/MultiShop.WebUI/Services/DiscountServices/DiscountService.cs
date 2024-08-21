using MultiShop.DtoLayer.CommentDtos;
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
        public Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteDiscountCouponAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponsAsync()
        {
            throw new NotImplementedException();
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
            var responseMessage = await _httpClient.GetAsync("Discount/" + id);
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
