using System.Net.Mime;
using System.Text.Json;
using Chat.BLL.Exceptions;

namespace Chat.Api.Middlewares;

public class ExceptionHandlerMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            var statusCode = 500;
            var exceptionResponse = new ExceptionResponse(ex.Message);

            switch (ex)
            {
                case LoginException:
                    statusCode = StatusCodes.Status400BadRequest;
                    break;

                case RegisterException:
                    statusCode = StatusCodes.Status400BadRequest;
                    break;

                case NonExistsEntityException:
                    statusCode = StatusCodes.Status404NotFound;
                    break;

                default:
                    statusCode = StatusCodes.Status500InternalServerError;
                    break;
            }


            context.Response.StatusCode = statusCode;
            context.Response.ContentType = MediaTypeNames.Application.Json;
            var json = JsonSerializer.Serialize(exceptionResponse);
            await context.Response.WriteAsync(json, context.RequestAborted);
        }
    }

    public class ExceptionResponse
    {
        public ExceptionResponse(string message)
        {
            Message = message;
            PermissionFailures = new List<string>(); 
        }

        public string Message { get; set; }
        public List<string> PermissionFailures { get; set; }
    }

}