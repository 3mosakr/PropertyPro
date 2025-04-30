namespace PropertyPro.Frontend.Services.Interfaces
{
    public interface IAuthService
    {
        Task<HttpRequestMessage> CreateRequestMessage(HttpMethod method, string url, object? content = null);
    }
}
