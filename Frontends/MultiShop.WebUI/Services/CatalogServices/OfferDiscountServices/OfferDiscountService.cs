using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices
{
    public class OfferDiscountService : IOfferDiscountService
    {
        private readonly HttpClient _httpClient;

        public OfferDiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto)
        {
            await _httpClient.PostAsJsonAsync<CreateOfferDiscountDto>("OfferDiscounts", createOfferDiscountDto);
        }

        public async Task DeleteOfferDiscountAsync(string id)
        {
            await _httpClient.DeleteAsync("OfferDiscounts/DeleteOfferDiscount/" + id);
        }

        public async Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync()
        {
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:7070/api/Categories");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsondata = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsondata);
            //    return View(values);
            //}
            var responseMessage = await _httpClient.GetAsync("OfferDiscounts");
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultOfferDiscountDto>>(jsondata);
            //var responseMessage = await _httpClient.GetAsync("categories");
            //var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultCategoryDto>>();
            return values;
        }

        public async Task<UpdateOfferDiscountDto> GetByIdOfferDiscountAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("OfferDiscounts/" + id);
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateOfferDiscountDto>(jsondata);
            //var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdCategoryDto>();
            return value;
        }

        public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateOfferDiscountDto>("OfferDiscounts", updateOfferDiscountDto);
        }
    }
}
