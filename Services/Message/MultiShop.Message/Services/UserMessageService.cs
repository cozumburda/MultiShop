using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiShop.Message.DAL.Context;
using MultiShop.Message.DAL.Entities;
using MultiShop.Message.Dtos;

namespace MultiShop.Message.Services
{
    public class UserMessageService : IUserMessageService
    {
        private readonly MessageContext _messageContext;
        private readonly IMapper _mapper;

        public UserMessageService(MessageContext messageContext, IMapper mapper)
        {
            _messageContext = messageContext;
            _mapper = mapper;
        }

        public void CreateMessageAsync(CreateMessageDto createMessageDto)
        {
            var value = _mapper.Map<UserMessage>(createMessageDto);
            _messageContext.UserMessages.Add(value);
            _messageContext.SaveChanges();
        }

        public async Task DeleteMessageAsync(int id)
        {
            var values = await _messageContext.UserMessages.FindAsync(id);
            _messageContext.UserMessages.Remove(values);
            await _messageContext.SaveChangesAsync();
        }

        public async Task<List<ResultMessageDto>> GetAllsAsync()
        {
            var values = await _messageContext.UserMessages.ToListAsync();
            return _mapper.Map<List<ResultMessageDto>>(values);
        }

        public async Task<GetByIdMessageDto> GetByIdMessagesAsync(int id)
        {
            var values = await _messageContext.UserMessages.FindAsync(id);
            return _mapper.Map<GetByIdMessageDto>(values);
        }

        public async Task<List<ResultInboxMessageDto>> GetInboxMessagesAsync(string id)
        {
            var values = await _messageContext.UserMessages.Where(x => x.ReceiverId == id).ToListAsync();
            return _mapper.Map<List<ResultInboxMessageDto>>(values);
        }

        public async Task<int> GetNonReadedMessageCount()
        {
            var value = await _messageContext.UserMessages.Where(x => x.IsRead == false).CountAsync();
            return value;
        }

        public async Task<int> GetReadedMessageCount()
        {
            var value = await _messageContext.UserMessages.Where(x => x.IsRead == true).CountAsync();
            return value;
        }

        public async Task<List<ResultSendboxMessageDto>> GetSendboxMessagesAsync(string id)
        {
            var values = await _messageContext.UserMessages.Where(x => x.SenderId == id).ToListAsync();
            return _mapper.Map<List<ResultSendboxMessageDto>>(values);
        }

        public async Task<int> GetTotalMessageCount()
        {
            var value = await _messageContext.UserMessages.CountAsync();
            return value;
        }

        public async Task<int> GetTotalMessageCountByReceiverId(string id)
        {
            int value = await _messageContext.UserMessages.Where(x => x.ReceiverId == id).CountAsync();
            return value;
        }

        public async Task<List<ResultInboxUnreadedMessageDto>> GetUnreadedInboxMessages(string id)
        {
            var values = await _messageContext.UserMessages.Where(x => x.ReceiverId == id & x.IsRead == false).ToListAsync();
            return _mapper.Map<List<ResultInboxUnreadedMessageDto>>(values);
        }

        public void UpdateMessageAsync(UpdateMessageDto updateMessageDto)
        {
            var value = _mapper.Map<UserMessage>(updateMessageDto);
            _messageContext.UserMessages.Update(value);
            _messageContext.SaveChanges();
        }
    }
}
