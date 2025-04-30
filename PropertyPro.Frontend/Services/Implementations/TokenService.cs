using Microsoft.JSInterop;
using PropertyPro.Frontend.Services.Interfaces;

namespace PropertyPro.Frontend.Services.Implementations
{

    public class TokenService : ITokenService
    {
        private readonly IJSRuntime JSRuntime;

        public TokenService(IJSRuntime jSRuntime)
        {
            JSRuntime = jSRuntime;
        }

        public async Task StoreTokenAsync(string token)
        {
            await JSRuntime.InvokeVoidAsync("localStorageFunctions.setAuthToken", token);
        }

        public async Task<string> GetTokenAsync()
        {
            return await JSRuntime.InvokeAsync<string>("localStorageFunctions.getAuthToken");
        }

        public async Task RemoveTokenAsync()
        {
            await JSRuntime.InvokeVoidAsync("localStorageFunctions.removeAuthToken");
        }

    }
}
