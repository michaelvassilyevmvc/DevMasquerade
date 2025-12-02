using DevMasquerade.Application.Exceptions;
using Shared;

namespace DevMasquerade.Application.Costumes.Categories.Fails.Exceptions;

public class CategoryNotFoundException : NotFoundException
{
    public CategoryNotFoundException(Error[] errors)
        : base(errors)
    {
    }
}