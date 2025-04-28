using System.Net;
using POS.Application.Exceptions;
using System.Text.Json;

namespace POS.API.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode statusCode;
            string message;

            if (exception is ApiException apiEx)
            {
                statusCode = apiEx.StatusCode;
                message = apiEx.Message;
            }
            else
            {
                statusCode = HttpStatusCode.InternalServerError;
                message = "An unexpected error occurred.";
            }

            var result = JsonSerializer.Serialize(new
            {
                error = message,
                statusCode = (int)statusCode
            });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(result);
        }
    }
}
