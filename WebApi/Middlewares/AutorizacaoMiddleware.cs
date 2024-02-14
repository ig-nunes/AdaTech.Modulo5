namespace WebApi.Middlewares
{
    public class AutorizacaoMiddleware
    {
        public readonly RequestDelegate _next;

        public AutorizacaoMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            //try
            //{
            //    if (!context.Request.Headers.ContainsKey("UsuarioLogado"))
            //    {
            //        context.Response.StatusCode = 401;
            //        return;
            //    }
            //    if (!context.Request.Headers.TryGetValue("UsuarioLogado", out var value))
            //    {
            //        if (value == "Admin")
            //        {
            //            await _next(context);
            //        }
            //        else
            //        {
            //            context.Response.StatusCode = 401;
            //            return;
            //        }
            //    }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}

            if (!context.Request.Headers.ContainsKey("UsuarioLogado"))
            {
                context.Response.StatusCode = 401;
                return;
            }
            if (context.Request.Headers.TryGetValue("UsuarioLogado", out var value))
            {
                if (value == "Admin")
                {
                    await _next(context);
                }
                else
                {
                    context.Response.StatusCode = 401;
                    return;
                }
            }
        }

    }
}
