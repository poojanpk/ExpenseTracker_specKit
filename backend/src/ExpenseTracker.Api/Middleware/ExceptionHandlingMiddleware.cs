using System.Text.Json;
using ExpenseTracker.Api.Extensions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Api.Middleware;

public sealed class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (ValidationException exception)
        {
            logger.LogWarning(exception, "Validation failure for {Path}", context.Request.Path);
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = "application/problem+json";
            await JsonSerializer.SerializeAsync(context.Response.Body, exception.ToValidationProblemDetails());
        }
        catch (FormatException exception)
        {
            logger.LogWarning(exception, "Bad request for {Path}", context.Request.Path);
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = "application/problem+json";
            var details = new ProblemDetails
            {
                Title = "Invalid request.",
                Detail = exception.Message,
                Status = StatusCodes.Status400BadRequest,
                Type = "https://httpstatuses.com/400"
            };
            await JsonSerializer.SerializeAsync(context.Response.Body, details);
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Unhandled exception for {Path}", context.Request.Path);
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/problem+json";
            var details = new ProblemDetails
            {
                Title = "An unexpected error occurred.",
                Detail = "The request could not be completed.",
                Status = StatusCodes.Status500InternalServerError,
                Type = "https://httpstatuses.com/500"
            };
            await JsonSerializer.SerializeAsync(context.Response.Body, details);
        }
    }
}
