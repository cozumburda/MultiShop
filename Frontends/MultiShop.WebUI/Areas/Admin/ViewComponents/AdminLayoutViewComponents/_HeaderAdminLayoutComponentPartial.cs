using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.MessageServices;
using MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices;

namespace MultiShop.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _HeaderAdminLayoutComponentPartial : ViewComponent
    {
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;
        private readonly ICommentStatisticService _commentStatisticService;

        public _HeaderAdminLayoutComponentPartial(IMessageService messageService, IUserService userService, ICommentStatisticService commentStatisticService)
        {
            _messageService = messageService;
            _userService = userService;
            _commentStatisticService = commentStatisticService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var appUser = await _userService.GetUserInfo();
            var appUserMessageCount = await _messageService.GetTotalMessageCountByUserId(appUser.Id);

            int totalCommentCount = await _commentStatisticService.GetCommentsCount();
            
            ViewBag.MessageCount = appUserMessageCount;
            ViewBag.CommentCount = totalCommentCount;

            return View();
        }
    }
}
