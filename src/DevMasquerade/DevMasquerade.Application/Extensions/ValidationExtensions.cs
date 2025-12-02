using FluentValidation.Results;
using Shared;

namespace DevMasquerade.Application.Extensions;

public static class ValidationExtensions
{
    public static Error[] ToErrors(this ValidationResult validationResult) =>
        validationResult.Errors.Select(error => Error.Validation(
                error.ErrorCode,
                error.PropertyName,
                error.ErrorMessage))
            .ToArray();
}