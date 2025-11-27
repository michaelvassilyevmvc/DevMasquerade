using DevMasquerade.Domain.Enums;

namespace DevMasquerade.Domain.Costumes;

public class CostumeVariant
{
    public Guid Id { get; set; }
    public Guid CostumeId { get; set; }
    public Costume Costume { get; set; } = default!;


    public string Name { get; set; } = default!;
    public string? Color { get; set; }
    public string? VariantCode { get; set; }
    public bool IsActive { get; set; }

    public SizeSystem SizeSystem { get; set; } = SizeSystem.Custom;

    public decimal? PricePerDay { get; set; }
    public decimal? DepositAmount { get; set; }

    public ICollection<CostumeSize> Sizes { get; set; } = new List<CostumeSize>();
    public ICollection<InventoryItem> InventoryItems { get; set; } = new List<InventoryItem>();
}