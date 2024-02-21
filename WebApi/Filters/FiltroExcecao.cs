using DadosSistema.CustomExceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApi.ResponseModels;

namespace WebApi.Filters
{
    public class FiltroExcecao : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is DeliveryApiException deliveryApiException)
            {
                var errorResult = new ErroResponse
                {
                    Titulo = "Erro Delivery API",
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
                var errorResult = new ErroResponse
                {
                    Titulo = "Erro Delivery API",
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
