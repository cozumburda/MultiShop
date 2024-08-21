using System.Security.Claims;
using MultiShop.WebUI.Services.Interfaces;

namespace MultiShop.WebUI.Services.Concrete
{
    public class LoginService : ILoginService
    {
        IHttpContextAccessor _httpContextAccessor;

        public LoginService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserId => _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
    }
}
