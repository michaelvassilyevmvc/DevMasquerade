namespace DevMasquerade.Domain.Enums;

public enum RentalStatus
{
    Draft = 1,     // черновик, ещё не подтверждён
    Reserved = 2,  // забронировано
    Paid = 3,      // оплачено
    PickedUp = 4,  // клиент забрал
    Returned = 5,  // возвращено
    Overdue = 6,   // просрочено
    Cancelled = 7  // отменено
}