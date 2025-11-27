using DevMasquerade.Domain.Auth;
using DevMasquerade.Domain.Enums;

namespace DevMasquerade.Domain.Rentals;

public class RentalOrder
{
    public Guid Id { get; set; }
    public Guid CustomerProfileId { get; set; }
    public Profile CustomerProfile { get; set; } = default!;

    public RentalStatus Status { get; set; } = RentalStatus.Draft;

    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public DateTimeOffset RentalFrom { get; set; }
    public DateTimeOffset RentalTo { get; set; }

    public decimal TotalPrice { get; set; }
    public decimal? TotalDeposit { get; set; }

    public string? CustomerComment { get; set; }
    public string? InternalNotes { get; set; }

    public ICollection<RentalLine> Lines { get; set; } = new List<RentalLine>();
}