using DevMasquerade.Domain.Auth;
using DevMasquerade.Domain.Enums;

namespace DevMasquerade.Domain.Costumes;

public class Costume
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
    public string? Description { get; set; }
    public string? ShortDescription { get; set; }

    public AgeGroup AgeGroup { get; set; }
    public Gender TargetGender { get; set; }

    public decimal? BasePricePerDay { get; set; }
    public bool IsActive { get; set; }

    public ICollection<CostumeVariant> Variants { get; set; }
    public ICollection<CostumeCategory> CostumeCategories { get; set; }
    public ICollection<CostumePart> Parts { get; set; }
    public ICollection<CostumePhoto> Photos { get; set; }
}

