using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace PClub.Backend.Auth.Middleware
{
    public class JsonExceptionsMiddleware
    {
        private readonly RequestDelegate _next;

        public JsonExceptionsMiddleware(RequestDelegate next)
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
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync($"[Пользовательская ошибка] {ex.Message} {ex.InnerException?.Message}");
            }
        }
    }
}
