using DevMasquerade.Domain.Enums;
using DevMasquerade.Domain.Rentals;

namespace DevMasquerade.Domain.Costumes;

public class InventoryItem
{
    public Guid Id { get; set; }
    public Guid CostumeVariantId { get; set; }
    public CostumeVariant CostumeVariant { get; set; }

    public Guid? CostumeSizeId { get; set; }
    public CostumeSize? CostumeSize { get; set; }

    public string InventoryCode { get; set; } = default!;
    public string? StorageLocation { get; set; }
    public ItemCondition Condition { get; set; } = ItemCondition.Good;

    public bool IsActive { get; set; }
    public ICollection<RentalLine> RentalLines { get; set; } = new List<RentalLine>();
}