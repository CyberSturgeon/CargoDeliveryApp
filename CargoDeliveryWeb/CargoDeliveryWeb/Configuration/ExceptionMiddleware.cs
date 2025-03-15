using CargoDeliveryWeb.Business.Exceptions;
using System.Net;

namespace CargoDeliveryWeb.Configuration;

public class ExceptionMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch (EntityNotFoundException ex)
        {
            await HandleEntityNotFoundExceptionAsync(httpContext, ex);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private async Task HandleEntityNotFoundExceptionAsync(HttpContext httpContext, Exception ex)
    {
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
        await WriteErrorDetailsAsync(httpContext, ex.Message);
    }

    private async Task WriteErrorDetailsAsync(HttpContext httpContext, string message)
    {
        await httpContext.Response.WriteAsync(new ErrorDetails()
        {
            StatusCode = httpContext.Response.StatusCode,
            Message = message,
        }.ToString());
    }

    private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
    {
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        await WriteErrorDetailsAsync(httpContext, "Strange shit!");
    }
}