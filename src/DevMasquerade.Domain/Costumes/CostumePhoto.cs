namespace DevMasquerade.Domain.Costumes;

public class CostumePhoto
{
    public Guid Id { get; set; }
    public Guid CostumeId { get; set; }
    public Costume Costume { get; set; }

    public string Url { get; set; }
    public string? AltText { get; set; }

    public int SortOrder { get; set; }
    public bool IsMain { get; set; }
}