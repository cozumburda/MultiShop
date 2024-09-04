using MultiShop.Message.Dtos;

namespace MultiShop.Message.Services
{
    public interface IUserMessageService
    {
        Task<List<ResultMessageDto>> GetAllsAsync();
        Task<List<ResultInboxMessageDto>> GetInboxMessagesAsync(string id);
        Task<List<ResultSendboxMessageDto>> GetSendboxMessagesAsync(string id);
        void CreateMessageAsync(CreateMessageDto createMessageDto);
        void UpdateMessageAsync(UpdateMessageDto updateMessageDto);
        Task DeleteMessageAsync(int id);
        Task<GetByIdMessageDto> GetByIdMessagesAsync(int id);
        Task<int> GetTotalMessageCount();
        Task<int> GetReadedMessageCount();
        Task<int> GetNonReadedMessageCount();
        Task<int> GetTotalMessageCountByReceiverId(string id);
        Task<List<ResultInboxUnreadedMessageDto>> GetUnreadedInboxMessages(string id);
    }
}
