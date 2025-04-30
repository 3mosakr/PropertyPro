using Microsoft.AspNetCore.Components.Authorization;
using PropertyPro.Frontend.Auth;
using PropertyPro.Frontend.Services.Interfaces;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace PropertyPro.Frontend.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly AuthenticationStateProvider _authProvider;

        public AuthService(AuthenticationStateProvider authProvider)
        {
            _authProvider = authProvider;
        }

        private async Task<string?> GetAuthTokenAsync()
        {
            var authProvider = (CustomAuthenticationStateProvider)_authProvider;
            var token = await authProvider.GetTokenAsync();
            return token;

        }

        public async Task<HttpRequestMessage> CreateRequestMessage(HttpMethod method, string url, object? content = null)
        {
            var token = await GetAuthTokenAsync();
            if (string.IsNullOrWhiteSpace(token))
                throw new UnauthorizedAccessException("No authentication token found!");

            var request = new HttpRequestMessage(method, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            if (content is HttpContent httpContent)
            {
                request.Content = httpContent;
            }
            else if (content != null)
            {
                request.Content = JsonContent.Create(content);
            }

            return request;
        }
    }
}
