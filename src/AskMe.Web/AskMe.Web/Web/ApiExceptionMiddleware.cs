using AskMe.DomainServices.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.WebEncoders.Testing;
using System.Text;

namespace AskMe.Web.Web;
internal sealed class ApiExceptionMiddleware
{
    public const string ErrorsKey = "errors";
    public const string CodeKey = "code";
    private const string ProblemJsonMimeType = @"application/problem+json";

    private readonly RequestDelegate next;
    private readonly IJsonHelper jsonHelper;
    private readonly HtmlTestEncoder encoder = new();

    private static readonly IDictionary<Type, int> ExceptionStatusCodes = new Dictionary<Type, int>
    {
        [typeof(NotFoundException)] = StatusCodes.Status404NotFound,
        [typeof(ServerErrorException)] = StatusCodes.Status500InternalServerError,
        [typeof(NotImplementedException)] = StatusCodes.Status501NotImplemented,
        [typeof(ForbiddenException)] = StatusCodes.Status403Forbidden,
        [typeof(ValidationException)] = StatusCodes.Status400BadRequest,
        [typeof(InvalidOperationException)] = StatusCodes.Status400BadRequest
    };

    public ApiExceptionMiddleware(
        RequestDelegate next,
        IJsonHelper jsonHelper)
    {
        this.next = next;
        this.jsonHelper = jsonHelper;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch (Exception exception)
        {
            var problemDetails = GetObjectByException(exception);
            problemDetails.Instance = httpContext.Request.Path;
            httpContext.Response.Clear();
            httpContext.Response.StatusCode = problemDetails.Status ?? StatusCodes.Status500InternalServerError;
            httpContext.Response.ContentType = ProblemJsonMimeType;

            await using var stringWriter = new StringWriter(new StringBuilder(200));
            jsonHelper.Serialize(problemDetails).WriteTo(stringWriter, encoder);
            await httpContext.Response.WriteAsync(stringWriter.ToString());
        }
    }

    private ProblemDetails GetObjectByException(Exception exception)
    {
        var problem = new ProblemDetails();
        var statusCode = StatusCodes.Status400BadRequest;
        AddExceptionInfoToProblemDetails(problem, exception);
        statusCode = GetStatusCodeByExceptionType(exception.GetType());
        problem.Status = statusCode;
        return problem;
    }

    private static void AddExceptionInfoToProblemDetails(ProblemDetails problemDetails, Exception exception)
    {
        problemDetails.Title = exception.Message;
        problemDetails.Type = exception.GetType().Name;
    }

    private static int GetStatusCodeByExceptionType(Type exceptionType)
    {
        foreach ((Type exceptionTypeKey, int statusCode) in ExceptionStatusCodes)
        {
            if (exceptionTypeKey.IsAssignableFrom(exceptionType))
            {
                return statusCode;
            }
        }
        return StatusCodes.Status500InternalServerError;
    }
}
