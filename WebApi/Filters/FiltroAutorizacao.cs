using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Filters
{
    public class FiltroAutorizacao : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Request.Headers.TryGetValue("token", out var value) && value == "true")
            {
                return;
            }


            context.Result = new UnauthorizedObjectResult(new { Message = "Usuário não tem permissão" });
        }


    }
}
