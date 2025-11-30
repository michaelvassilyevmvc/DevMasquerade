namespace DevMasquerade.Contracts.Costumes.Categories;

public record UpdateCategoryDto(string Name,
    string Slug,
    string? Description,
    Guid? ParentId);