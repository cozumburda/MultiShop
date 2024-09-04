using MultiShop.DtoLayer.MessageDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.MessageServices
{
    public class MessageService : IMessageService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;

        public MessageService(HttpClient httpClient, IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClient;
            _httpClientFactory = httpClientFactory;
        }
        public async Task CreateMessageAsync(CreateMessageDto createMessageDto)
        {
            //var client = _httpClientFactory.CreateClient();
            //var jsondata = JsonConvert.SerializeObject(createMessageDto);
            //StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            //await client.PostAsync("http://localhost:7078/api/UserMessages", stringContent);

            await _httpClient.PostAsJsonAsync<CreateMessageDto>("UserMessages", createMessageDto);
        }

        public async Task DeleteMessageAsync(int id)
        {
            await _httpClient.DeleteAsync("UserMessages/DeleteMessage/" + id);
        }

        public async Task<List<ResultMessageDto>> GetAllMessageAsync()
        {
            var responseMessage = await _httpClient.GetAsync("UserMessages");
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ResultMessageDto>>(jsondata);
            //var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdCategoryDto>();
            return value;
        }

        public async Task<UpdateMessageDto> GetByIdMessageAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync("UserMessages/GetMessageById/" + id);
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateMessageDto>(jsondata);
            //var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdCategoryDto>();
            return value;
        }

        public async Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("UserMessages/GetInboxMessages/" + id);
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ResultInboxMessageDto>>(jsondata);
            //var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdCategoryDto>();
            return value;
        }

        public async Task<List<ResultSendboxMessageDto>> GetSendboxMessageAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("UserMessages/GetSendboxMessages/" + id);
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ResultSendboxMessageDto>>(jsondata);
            //var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdCategoryDto>();
            return value;
        }

        public async Task<int> GetTotalMessageCountByUserId(string id)
        {
            var responseMessage = await _httpClient.GetAsync("UserMessages/GetTotalMessageCountByReceiverId/" + id);
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<int>(jsondata);
            return values;
        }

        public async Task UpdateMessageAsync(UpdateMessageDto updateMessageDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateMessageDto>("UserMessages", updateMessageDto);
        }
    }
}
