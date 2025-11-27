using DevMasquerade.Domain.Costumes;

namespace DevMasquerade.Domain.Rentals;

public class RentalLine
{
    public Guid Id { get; set; }
    public Guid RentalOrderId { get; set; }
    public RentalOrder RentalOrder { get; set; } = default!;

    public Guid InventoryItemId { get; set; }
    public InventoryItem InventoryItem { get; set; } = default!;

    public decimal PricePerDay { get; set; }
    public decimal? DepositAmount { get; set; }
    public int Quantity { get; set; } = 1;

}
