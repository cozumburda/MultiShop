using MultiShop.DtoLayer.MessageDtos;
using MultiShop.DtoLayer.SignalRDtos;

namespace MultiShop.WebUI.Services.SignalRServices.SignalRMessageServices
{
    public interface ISignalRMessageService
    {
        Task<List<ResultUnreadedInboxMessageDto>> GetUnreadedInboxMessages(string id);
    }
}
