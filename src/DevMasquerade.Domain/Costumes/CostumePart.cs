using DevMasquerade.Domain.Enums;

namespace DevMasquerade.Domain.Costumes;

public class CostumePart
{
    public Guid Id { get; set; }
    public Guid CpstumeId { get; set; }
    public Costume Costume { get; set; }

    public string Name { get; set; } = default!;
    public ItemType ItemType { get; set; }

    public bool IsRequired { get; set; }
    public string? Notes { get; set; }
}