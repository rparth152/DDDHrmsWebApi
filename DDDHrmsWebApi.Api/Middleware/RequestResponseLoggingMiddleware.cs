namespace DDDHrmsWebApi.Api.Middleware
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestResponseLoggingMiddleware> _logger;

        public RequestResponseLoggingMiddleware(RequestDelegate next,
            ILogger<RequestResponseLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            // 🔹 Log Request
            _logger.LogInformation($"Request: {context.Request.Method} {context.Request.Path}");

            await _next(context);

            // 🔹 Log Response
            _logger.LogInformation($"Response Status: {context.Response.StatusCode}");
        }
    }
}
