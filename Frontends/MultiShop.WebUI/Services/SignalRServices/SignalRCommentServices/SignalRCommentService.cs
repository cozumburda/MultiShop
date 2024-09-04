using MultiShop.DtoLayer.SignalRDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.SignalRServices.SignalRCommentServices
{
    public class SignalRCommentService : ISignalRCommentService
    {
        private readonly HttpClient _httpClient;

        public SignalRCommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<ResultUnApprovedComments>> GetUnApprovedComments()
        {
            var responseMessage = await _httpClient.GetAsync("Comments/GetUnApprovedComments");
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ResultUnApprovedComments>>(jsondata);
            //var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdCategoryDto>();
            return value;
        }
    }
}
