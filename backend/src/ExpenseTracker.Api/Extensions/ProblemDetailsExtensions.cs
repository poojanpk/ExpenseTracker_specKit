using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Api.Extensions;

public static class ProblemDetailsExtensions
{
    public static ValidationProblemDetails ToValidationProblemDetails(this ValidationException exception)
    {
        var errors = exception.Errors
            .GroupBy(error => string.IsNullOrWhiteSpace(error.PropertyName) ? "request" : error.PropertyName)
            .ToDictionary(group => group.Key, group => group.Select(error => error.ErrorMessage).Distinct().ToArray());

        if (errors.Count == 0)
        {
            errors["request"] = [exception.Message];
        }

        return new ValidationProblemDetails(errors)
        {
            Title = "One or more validation errors occurred.",
            Status = StatusCodes.Status400BadRequest,
            Type = "https://httpstatuses.com/400"
        };
    }
}
