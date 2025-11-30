    namespace DevMasquerade.Domain.Costumes;

public class Category
{
    public Category(Guid id, string name, string slug, string? description, Guid? parentId)
    {
        Id = id;
        Name = name;
        Slug = slug;
        Description = description;
        ParentId = parentId;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public string? Description { get; set; }

    public Guid? ParentId { get; set; }
    public Category? Parent { get; set; }
    public ICollection<Category> Children { get; set; } = new List<Category>();
    public ICollection<CostumeCategory> CostumeCategories { get; set; } = new List<CostumeCategory>();
}