using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PetStore.Service.Models;
using System.Net;
using System.Text.Json;

namespace PetStore.Models
{
    public class PetStoreJsonExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<PetStoreJsonExceptionHandler> _logger;
        public PetStoreJsonExceptionHandler(ILogger<PetStoreJsonExceptionHandler> logger)
        {
            _logger = logger;
        }
        public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var jsonException = exception as JsonException;
            if (jsonException == null)
            {
                return ValueTask.FromResult(false);
            }

            PetStoreError error = new PetStoreError
            {
                Code = (int)HttpStatusCode.BadRequest,
                Message = jsonException.Message
            };

            _logger.LogError(exception, "An error occurred while processing the request.");

            httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.WriteAsJsonAsync(error, new JsonSerializerOptions(JsonSerializerDefaults.Web));

            return ValueTask.FromResult(true);
        }
    }

    public class PetStoreExceptionFileter : IActionFilter, IOrderedFilter
    {
        public int Order => 0;

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is JsonException jsonException)
            {
                var error = new PetStoreError
                {
                    Code = (int)HttpStatusCode.BadRequest,
                    Message = jsonException.Message
                };
                context.Result = new ObjectResult(error)
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
                context.ExceptionHandled = true;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid && context.ModelState.ErrorCount > 0 )
            {
                var error = new PetStoreError
                {
                    Code = (int)HttpStatusCode.BadRequest,
                    Message = "Error"
                };
                context.Result = new ObjectResult(error)
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
                context.Result = new BadRequestObjectResult(error);
            }

        }
    }
}
