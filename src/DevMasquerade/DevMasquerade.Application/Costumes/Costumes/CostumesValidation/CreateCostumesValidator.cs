using DevMasquerade.Contracts.Costumes.Categories;
using DevMasquerade.Contracts.Costumes.Costumes;
using FluentValidation;

namespace DevMasquerade.Application.Costumes.Costumes.CostumesValidation;

public class CreateCostumesValidator: AbstractValidator<CreateCostumeDto>
{
    public CreateCostumesValidator()
    {
           RuleFor(x => x.Name).NotEmpty().MaximumLength(150).WithMessage("Name is required");
           RuleFor(x => x.Description).MaximumLength(200).WithMessage("Max length is 200");
           RuleFor(x => x.AgeGroup).IsInEnum().WithMessage("AgeGroup must be valid value");
           RuleFor(x => x.BasePricePerDay).GreaterThan(0).WithMessage("BasePricePerDay must be greater than 0");
           RuleFor(x => x.TargetGender).IsInEnum().WithMessage("TargetGender must be valid value");
           RuleFor(x => x.Code).NotEmpty().WithMessage("Code is required");
           RuleFor(x => x.ShortDescription).MaximumLength(200).WithMessage("Max length is 200");
    }
}