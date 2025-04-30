namespace PropertyPro.Api.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var ipAddress = context.Connection.RemoteIpAddress?.ToString();

            _logger.LogInformation("Incoming request from IP: {IP} - {Method} {Path}",
                ipAddress,
                context.Request.Method,
                context.Request.Path
            );

            await _next(context);
        }
    }
}
