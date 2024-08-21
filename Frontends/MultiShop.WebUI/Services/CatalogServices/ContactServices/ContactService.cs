using MultiShop.DtoLayer.CatalogDtos.ContactDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.ContactServices
{
    public class ContactService:IContactService
    {
        private readonly HttpClient _httpClient;

        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
            await _httpClient.PostAsJsonAsync<CreateContactDto>("Contacts", createContactDto);
        }

        public async Task DeleteContactAsync(string id)
        {
            await _httpClient.DeleteAsync("Contacts/DeleteContact/" + id);
        }

        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:7070/api/Categories");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsondata = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsondata);
            //    return View(values);
            //}
            var responseMessage = await _httpClient.GetAsync("Contacts");
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsondata);
            //var responseMessage = await _httpClient.GetAsync("categories");
            //var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultCategoryDto>>();
            return values;
        }

        public async Task<UpdateContactDto> GetByIdContactAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("Contacts/" + id);
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateContactDto>(jsondata);
            //var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdCategoryDto>();
            return value;
        }

        public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateContactDto>("Contacts", updateContactDto);
        }
    }
}
