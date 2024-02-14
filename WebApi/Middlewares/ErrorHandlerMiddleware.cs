using Microsoft.AspNetCore.Mvc;

namespace WebApi.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next) 
        {  
            _next = next; 
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync( new {ErrorMessage = $"Ocorreu algum erro, meu amigo. Mais informações: {ex.Message}"} );
            }
        }
    }
}
