using DSEU.Application.Common.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;

namespace DSEU.UI.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    [AllowAnonymous]
    public class ErrorController : ControllerBase
    {
        private readonly ILogger<ErrorController> logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            this.logger = logger;
        }
        [Route("/error-local-development")]
        public IActionResult ErrorLocalDevelopment([FromServices] IWebHostEnvironment webHostEnvironment)
        {
            if (webHostEnvironment.EnvironmentName != Environments.Development)
            {
                throw new InvalidOperationException(
                    "This shouldn't be invoked in non-development environments.");
            }

            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            (int statusCode, string resultMessage) = GenerateHumanErrorMessage();
            logger.LogError(resultMessage);
            return Problem(
                detail: context.Error.StackTrace,
                title: context.Error.Message);
        }

        [Route("/error-production")]
        public IActionResult Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            logger.LogError(context.Error, context.Error.Message);
            (int statusCode, string resultMessage) = GenerateHumanErrorMessage();
            return Problem(detail: resultMessage, statusCode: statusCode);
        }

        private (int statusCode, string resultMessage) GenerateHumanErrorMessage()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            int statusCode = StatusCodes.Status500InternalServerError;
            string result;
            switch (context.Error)
            {
                case ValidationException validationException:
                    result = JsonConvert.SerializeObject(validationException.Errors);
                    statusCode = StatusCodes.Status400BadRequest;
                    break;
                case NotFoundException _:
                    result = JsonConvert.SerializeObject(new Dictionary<string, string[]>()
                    {
                        ["error"] = new[] { "Object not found" }
                    });
                    statusCode = StatusCodes.Status404NotFound;
                    break;
                case PostgresException postgresException:
                    result = HandlerSqlException(postgresException);
                    if (!string.IsNullOrEmpty(result))
                        statusCode = StatusCodes.Status400BadRequest;
                    break;
                default:
                    if (context.Error.InnerException != null)
                    {
                        if (context.Error.InnerException is PostgresException postgresException)
                        {
                            result = HandlerSqlException(postgresException);
                            break;
                        }
                    }
                    result = JsonConvert.SerializeObject(new Dictionary<string, string[]>()
                    {
                        ["error"] = new[] { "Произошла ошибка. Обратитесь к администратору системы." }
                    });
                    break;

            }

            return (statusCode, result);
        }

        private static string HandlerSqlException(PostgresException postgresException)
        {
            if (postgresException.SqlState == "23503")
            {
                if (postgresException.MessageText.ToLower().Contains("delete"))
                {
                    return JsonConvert.SerializeObject(new Dictionary<string, string[]>()
                    {
                        ["error"] = new[] { postgresException.Message }
                    });
                }
                if (postgresException.MessageText.ToLower().Contains("insert"))
                {
                    return JsonConvert.SerializeObject(new Dictionary<string, string[]>()
                    {
                        ["error"] = new[] { postgresException.Message }
                    });
                }
            }
            return string.Empty;
        }
    }
}
