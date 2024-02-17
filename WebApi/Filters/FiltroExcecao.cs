using Dados.CustomExceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Filters
{
    public class FiltroExcecao : IExceptionFilter
    {
        private readonly ILogger<FiltroExcecao> _logger;
        public FiltroExcecao(ILogger<FiltroExcecao> logger)
        {
            _logger = logger;
        }
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is ApiException deliveryApiException)
            {
                var errorResult = new
                {
                    Titulo = "API",
                    Detalhes = deliveryApiException.Message,
                    StatusCode = deliveryApiException.StatusCode,
                };
                context.Result = new JsonResult(errorResult)
                {
                    StatusCode = errorResult.StatusCode,
                };
            }
            else
            {
                var errorResult = new
                {
                    Titulo = "API",
                    Detalhes = "Erro interno dp servidor",
                    StatusCode = StatusCodes.Status500InternalServerError,
                };
                context.Result = new JsonResult(errorResult)
                {
                    StatusCode = errorResult.StatusCode,
                };
            }
        }

        
    }
}
