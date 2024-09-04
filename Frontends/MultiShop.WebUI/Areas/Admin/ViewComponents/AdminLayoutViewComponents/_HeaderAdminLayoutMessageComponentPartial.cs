using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.SignalRServices.SignalRMessageServices;

namespace MultiShop.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _HeaderAdminLayoutMessageComponentPartial : ViewComponent
    {
        private readonly IUserService _userService;
        private readonly ISignalRMessageService _signalRMessageService;

        public _HeaderAdminLayoutMessageComponentPartial(IUserService userService, ISignalRMessageService signalRMessageService)
        {
            _userService = userService;
            _signalRMessageService = signalRMessageService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var appUser = await _userService.GetUserInfo();
            
            var inboxMessages = await _signalRMessageService.GetUnreadedInboxMessages(appUser.Id);
            if (inboxMessages != null)
            {
                foreach (var item in inboxMessages)
                {
                    var allUsers = await _userService.GetAllUserInfo();
                    var sendUser = allUsers.Where(x => x.Id == item.SenderId).FirstOrDefault();
                    var senderName = sendUser.Name + " " + sendUser.Surname;
                    item.SenderName = senderName;
                }
            }
            return View(inboxMessages);
        }
    }
}
