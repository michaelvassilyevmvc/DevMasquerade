namespace DevMasquerade.Domain.Costumes;

public class CostumeCategory
{
    public Guid CostumeId { get; set; }
    public Costume Costume { get; set; }

    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
}