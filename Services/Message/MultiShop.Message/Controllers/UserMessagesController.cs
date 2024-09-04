using Microsoft.AspNetCore.Mvc;
using MultiShop.Message.Dtos;
using MultiShop.Message.Services;

namespace MultiShop.Message.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMessagesController : ControllerBase
    {
        private readonly IUserMessageService _userMessageService;

        public UserMessagesController(IUserMessageService userMessageService)
        {
            _userMessageService = userMessageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMessage()
        {
            var values = await _userMessageService.GetAllsAsync();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateMessageAsync(CreateMessageDto createMessageDto)
        {
            _userMessageService.CreateMessageAsync(createMessageDto);
            return Ok("Mesaj Başarıyla Eklendi");
        }
        
        [HttpDelete("DeleteMessage/{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            await _userMessageService.DeleteMessageAsync(id);
            return Ok("Mesaj Silindi");
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            _userMessageService.UpdateMessageAsync(updateMessageDto);
            return Ok("Mesaj Başarıyla Güncellendi");
        }

        [HttpGet("GetInboxMessages/{id}")]
        public async Task<IActionResult> GetInboxMessages(string id)
        {
            var values = await _userMessageService.GetInboxMessagesAsync(id);
            return Ok(values);
        }

        [HttpGet("GetSendboxMessages/{id}")]
        public async Task<IActionResult> GetSendboxMessages(string id)
        {
            var values = await _userMessageService.GetSendboxMessagesAsync(id);
            return Ok(values);
        }
        [HttpGet("GetMessageById/{id}")]
        public async Task<IActionResult> GetMessageById(int id)
        {
            var values = await _userMessageService.GetByIdMessagesAsync(id);
            return Ok(values);
        }
        [HttpGet("GetTotalMessageCount")]
        public async Task<IActionResult> GetTotalMessageCount()
        {
            var value = await _userMessageService.GetTotalMessageCount();
            return Ok(value);
        }
        [HttpGet("GetReadedMessageCount")]
        public async Task<IActionResult> GetReadedMessageCount()
        {
            var value = await _userMessageService.GetReadedMessageCount();
            return Ok(value);
        }
        [HttpGet("GetNonReadedMessageCount")]
        public async Task<IActionResult> GetNonReadedMessageCount()
        {
            var value = await _userMessageService.GetNonReadedMessageCount();
            return Ok(value);
        }
        [HttpGet("GetTotalMessageCountByReceiverId/{id}")]
        public async Task<IActionResult> GetTotalMessageCountByReceiverId(string id)
        {
            var value = await _userMessageService.GetTotalMessageCountByReceiverId(id);
            return Ok(value);
        }
        [HttpGet("GeUnReadedInboxMessages/{id}")]
        public async Task<IActionResult> GeUnReadedInboxMessages(string id)
        {
            var value = await _userMessageService.GetUnreadedInboxMessages(id);
            return Ok(value);
        }
    }
}
