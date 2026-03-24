
using System.Net;
using System.Text.Json;
using DDDHrmsWebApi.Application.DTO;

namespace DDDHrmsWebApi.Api.Middleware
{




   

    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next,
            ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                //  Log error
                _logger.LogError(ex, "Global Exception Occurred");

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                //  ApiResponse format
                var response = ApiResponse<string>.ErrorResponse(ex.Message);

                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        }
    }
}
