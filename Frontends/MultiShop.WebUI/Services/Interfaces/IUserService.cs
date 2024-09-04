using MultiShop.WebUI.Models;

namespace MultiShop.WebUI.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDetailViewModel> GetUserInfo();
        Task<List<AllUserViewModel>> GetAllUserInfo();
    }
}
