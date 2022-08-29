using NSE.WebApp.MVC.Models;

namespace NSE.WebApp.MVC.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> Login(UserLogin userLogin);
        Task<string> Register(UserRegister userRegister);
    }
}
