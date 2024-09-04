using MultiShop.DtoLayer.MessageDtos;
using MultiShop.DtoLayer.SignalRDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.SignalRServices.SignalRMessageServices
{
    public class SignalRMessageService : ISignalRMessageService
    {
        private readonly HttpClient _httpClient;

        public SignalRMessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<ResultUnreadedInboxMessageDto>> GetUnreadedInboxMessages(string id)
        {
            var responseMessage = await _httpClient.GetAsync("UserMessages/GeUnReadedInboxMessages/" + id);
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ResultUnreadedInboxMessageDto>>(jsondata);
            //var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdCategoryDto>();
            return value;
        }
    }
}
