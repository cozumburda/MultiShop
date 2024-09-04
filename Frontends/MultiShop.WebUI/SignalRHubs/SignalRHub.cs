using Microsoft.AspNetCore.SignalR;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.SignalRServices.SignalRCommentServices;
using MultiShop.WebUI.Services.SignalRServices.SignalRMessageServices;

namespace MultiShop.WebUI.SignalRHubs
{
    public class SignalRHub : Hub
    {
        private readonly ISignalRCommentService _signalRCommentService;
        private readonly ISignalRMessageService _signalRMessageService;
        private readonly IUserService _userService;

        public SignalRHub(IUserService userService, ISignalRCommentService signalRCommentService, ISignalRMessageService signalRMessageService)
        {

            _userService = userService;
            _signalRCommentService = signalRCommentService;
            _signalRMessageService = signalRMessageService;
        }
        public async Task SendStatisticCount()
        {
            var comments = await _signalRCommentService.GetUnApprovedComments();
            await Clients.All.SendAsync("ReceiveCommentCount", comments.Count());

            var appUser = await _userService.GetUserInfo();
            var inboxMessages = await _signalRMessageService.GetUnreadedInboxMessages(appUser.Id);            
            await Clients.All.SendAsync("ReceiveMessageCount", inboxMessages.Count());
        }
    }
}
