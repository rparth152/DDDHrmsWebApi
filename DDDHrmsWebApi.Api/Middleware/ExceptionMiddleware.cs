using DDDHrmsWebApi.Application.Common;
using System.Text.Json;

namespace DDDHrmsWebApi.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;

        public ExceptionMiddleware(RequestDelegate next,
            ILogger<ExceptionMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);

                var errorMessage =
                    ex.InnerException?.Message ?? ex.Message;

                var response = ApiResponse<object>.ErrorResponse(errorMessage);

                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(
                    JsonSerializer.Serialize(response));
            }
        }
    }
}