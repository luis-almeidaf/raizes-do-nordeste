using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RaizesDoNordeste.Application.Common.Responses;
using RaizesDoNordeste.Exceptions;
using RaizesDoNordeste.Exceptions.ExceptionsBase;

namespace RaizesDoNordeste.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is RaizesDoNordesteException)
            HandleProjectException(context);
        else
            ThrowUnknownError(context);
    }

    private static void HandleProjectException(ExceptionContext context)
    {
        var raizesDoNordesteException = (RaizesDoNordesteException)context.Exception;
        var errorResponse = new ErroBaseResponse(raizesDoNordesteException.GetErrors());

        context.HttpContext.Response.StatusCode = raizesDoNordesteException.StatusCode;
        context.Result = new ObjectResult(errorResponse);
    }

    private static void ThrowUnknownError(ExceptionContext context)
    {
        var errorResponse = new ErroBaseResponse(MensagensDeErro.ERRO_DESCONHECIDO);
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorResponse);
    }
}