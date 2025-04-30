using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Security.Claims;

namespace PropertyPro.Frontend.Auth
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IJSRuntime _jsRuntime;
        private ClaimsPrincipal _currentUser = new(new ClaimsIdentity());

        public CustomAuthenticationStateProvider(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "authToken");

            if (string.IsNullOrWhiteSpace(token)) // تجنب التحليل عندما يكون التوكن فارغًا
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            var claims = ParseClaimsFromJwt(token);

            var user = claims.Any()
                ? new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"))
                : new ClaimsPrincipal(new ClaimsIdentity());

            return new AuthenticationState(user);
        }

        public async Task MarkUserAsAuthenticated(string token)
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "authToken", token);

            var user = new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt"));
            _currentUser = user;

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public async Task MarkUserAsLoggedOut()
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "authToken");

            _currentUser = new ClaimsPrincipal(new ClaimsIdentity());
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_currentUser)));
        }

        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            if (string.IsNullOrWhiteSpace(jwt))
                return new List<Claim>(); // تجنب محاولة تحليل نص فارغ

            try
            {
                var payload = jwt.Split('.')[1];

                // تأكد من أن الطول صحيح عند فك التشفير
                payload = payload.PadRight(payload.Length + (4 - payload.Length % 4) % 4, '=');

                var jsonBytes = Convert.FromBase64String(payload);
                var claims = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

                return claims?.Select(kv => new Claim(kv.Key, kv.Value.ToString())) ?? new List<Claim>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing JWT: {ex.Message}");
                return new List<Claim>(); // في حالة الخطأ، نعيد قائمة فارغة
            }
        }

        public async Task<string?> GetTokenAsync()
        {
            try
            {
                var token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "authToken");
                return token;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting token: {ex.Message}");
                return null;
            }
        }


    }
}
