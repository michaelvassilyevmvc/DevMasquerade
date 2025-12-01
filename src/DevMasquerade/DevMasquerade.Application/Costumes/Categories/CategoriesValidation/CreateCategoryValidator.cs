using DevMasquerade.Contracts.Costumes.Categories;
using FluentValidation;

namespace DevMasquerade.Application.Costumes.Categories.CategoriesValidation;

public class CreateCategoryValidator: AbstractValidator<CreateCategoryDto>
{
    public CreateCategoryValidator()
    {
           RuleFor(x => x.Name).NotEmpty().MaximumLength(150).WithMessage("Name is required");
           RuleFor(x => x.Slug).NotEmpty().WithMessage("Slug is required");
           RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
           RuleFor(x => x.ParentId).NotEmpty().WithMessage("ParentId is required");
    }
}