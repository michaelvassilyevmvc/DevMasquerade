namespace DevMasquerade.Domain.Costumes;

public class CostumeSize
{
    public Guid Id { get; set; }
    public Guid CostumeVariantId { get; set; }
    public CostumeVariant CostumeVariant { get; set; } = default!;

    public string Label { get; set; } = default!;
    public int? HeightFromCm { get; set; }
    public int? HeightToCm { get; set; }

    public int? ChestGirthCm { get; set; }
    public int? WaistGirthCm { get; set; }
    public int? HipGirthCm { get; set; }
}