using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Filters
{
    public class FiltroLogAction : IActionFilter
    {
        private readonly ILogger _logger;

        public FiltroLogAction(ILogger<FiltroLogAction> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("Final da ação");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("Início da ação");
        }

    }
}
