using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly HttpClient _httpClient;

        public SpecialOfferService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _httpClient.PostAsJsonAsync<CreateSpecialOfferDto>("SpecialOffers", createSpecialOfferDto);
        }

        public async Task DeleteSpecialOfferAsync(string id)
        {
            await _httpClient.DeleteAsync("SpecialOffers/DeleteSpecialOffer/" + id);
        }

        public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync()
        {
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:7070/api/Categories");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsondata = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsondata);
            //    return View(values);
            //}
            var responseMessage = await _httpClient.GetAsync("SpecialOffers");
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(jsondata);
            //var responseMessage = await _httpClient.GetAsync("categories");
            //var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultCategoryDto>>();
            return values;
        }

        public async Task<UpdateSpecialOfferDto> GetByIdSpecialOfferAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("SpecialOffers/" + id);
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateSpecialOfferDto>(jsondata);
            //var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdCategoryDto>();
            return value;
        }

        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateSpecialOfferDto>("SpecialOffers", updateSpecialOfferDto);
        }
    }
}
