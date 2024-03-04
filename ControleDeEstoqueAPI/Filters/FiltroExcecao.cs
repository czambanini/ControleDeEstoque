using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Domain.Exceptions;

namespace Application.Filters
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
            if (context.Exception is ProdutoVencidoException vencidoException)
            {
                var errorResult = new ErroResponse
                {
                    Titulo = "Produto Vencido",
                    Detalhes = vencidoException.Message,
                    StatusCode = vencidoException.StatusCode
                };

                context.Result = new JsonResult(errorResult)
                {
                    StatusCode = errorResult.StatusCode
                };
            }
            else if (context.Exception is QuantidadeInsuficienteException insuficienteException)
            {
                var errorResult = new ErroResponse
                {
                    Titulo = "Produto Insuficiente",
                    Detalhes = insuficienteException.Message,
                    StatusCode = insuficienteException.StatusCode
                };

                context.Result = new JsonResult(errorResult)
                {
                    StatusCode = errorResult.StatusCode
                };
                _logger.LogError("Quantidade Insuficiente. Operação não concluída.");
            }
            else if (context.Exception is ArgumentException argumentException)
            {
                var errorResult = new ErroResponse
                {
                    Titulo = "Erro",
                    Detalhes = argumentException.Message,
                    StatusCode = StatusCodes.Status500InternalServerError
                };

                context.Result = new JsonResult(errorResult)
                {
                    StatusCode = errorResult.StatusCode
                };
                _logger.LogError($"Uma exceção foi identificada: {argumentException.Message}");
            }
            else
            {
                var errorResult = new ErroResponse
                {
                    Titulo = "Erro",
                    Detalhes = "Erro interno do servidor",
                    StatusCode = StatusCodes.Status500InternalServerError
                };

                context.Result = new JsonResult(errorResult)
                {
                    StatusCode = errorResult.StatusCode
                };

                _logger.LogError("Uma exceção foi identificada no filtro de exceção");
            }

        }
    }
}
