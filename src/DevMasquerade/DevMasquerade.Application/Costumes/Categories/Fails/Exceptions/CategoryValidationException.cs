using DevMasquerade.Application.Exceptions;
using Shared;

namespace DevMasquerade.Application.Costumes.Categories.Fails.Exceptions;

public class CategoryValidationException: BadRequestException
{
    public CategoryValidationException(Error[] errors)
        : base(errors)
    {
    }
}