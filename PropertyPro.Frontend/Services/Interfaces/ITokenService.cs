namespace PropertyPro.Frontend.Services.Interfaces
{
    public interface ITokenService
    {
        Task StoreTokenAsync(string token);
        Task<string> GetTokenAsync();
        Task RemoveTokenAsync();
    }
}
