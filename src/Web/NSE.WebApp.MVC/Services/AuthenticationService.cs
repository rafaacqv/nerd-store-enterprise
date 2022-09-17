using NSE.WebApp.MVC.Models;
using NSE.WebApp.MVC.Services.Interfaces;
using System.Text;
using System.Text.Json;

namespace NSE.WebApp.MVC.Services
{
    public class AuthenticationService : IAuthenticationServiceNSE
    {
        private readonly HttpClient _httpClient;

        public AuthenticationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserResponseLogin> Login(UserLogin userLogin)
        {
            var loginContent = new StringContent(
                JsonSerializer.Serialize(userLogin),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("https://localhost:44364/api/identity/authenticate", loginContent);
            var data = JsonSerializer.Deserialize<UserResponseLogin>(await response.Content.ReadAsStringAsync());

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return JsonSerializer.Deserialize<UserResponseLogin>(await response.Content.ReadAsStringAsync(), options);
        }

        public async Task<UserResponseLogin> Register(UserRegister userRegister)
        {
            var registerContent = new StringContent(
                JsonSerializer.Serialize(userRegister),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("https://localhost:44364/api/identity/new-account", registerContent);
            return JsonSerializer.Deserialize<UserResponseLogin>(await response.Content.ReadAsStringAsync());
        }
    }
}
