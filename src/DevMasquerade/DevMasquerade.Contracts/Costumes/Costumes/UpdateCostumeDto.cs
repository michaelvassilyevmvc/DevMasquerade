using DevMasquerade.Domain.Enums;

namespace DevMasquerade.Contracts.Costumes.Costumes;

public record UpdateCostumeDto(
    string Name,
    string? Code,
    string? Description,
    string? ShortDescription,
    AgeGroup AgeGroup,
    Gender TargetGender,
    decimal? BasePricePerDay);