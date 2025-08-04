using HandsOnLab.ASPCoreClient.Models;

namespace HandsOnLab.ASPCoreClient.Services
{
    public interface IAccount
    {
        Task<UserViewModel> Login(LoginViewModel loginViewModel);
    }
}
