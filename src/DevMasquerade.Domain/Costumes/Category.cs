namespace DevMasquerade.Domain.Costumes;

public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Slug { get; set; } = default!;
    public string? Description { get; set; }

    public Guid? ParentId { get; set; }
    public Category? Parent { get; set; }
    public ICollection<Category> Children { get; set; } = new List<Category>();
    public ICollection<CostumeCategory> CustumeCategories { get; set; } = new List<CostumeCategory>();
}