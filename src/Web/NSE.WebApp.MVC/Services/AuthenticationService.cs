using NSE.WebApp.MVC.Models;
using NSE.WebApp.MVC.Services.Interfaces;
using System.Text;
using System.Text.Json;

namespace NSE.WebApp.MVC.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;

        public AuthenticationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> Login(UserLogin userLogin)
        {
            var loginContent = new StringContent(
                JsonSerializer.Serialize(userLogin),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("https://localhost:44364/api/identity/authenticate", loginContent);
            return JsonSerializer.Deserialize<string>(await response.Content.ReadAsStringAsync());
        }

        public async Task<string> Register(UserRegister userRegister)
        {
            var registerContent = new StringContent(
                JsonSerializer.Serialize(userRegister),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("https://localhost:44364/api/identity/new-account", registerContent);
            return JsonSerializer.Deserialize<string>(await response.Content.ReadAsStringAsync());
        }
    }
}
