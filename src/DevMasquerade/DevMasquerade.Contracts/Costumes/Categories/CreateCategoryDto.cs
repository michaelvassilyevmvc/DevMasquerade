namespace DevMasquerade.Contracts.Costumes.Categories;

public record CreateCategoryDto(
    string Name,
    string Slug,
    string? Description,
    Guid? ParentId);