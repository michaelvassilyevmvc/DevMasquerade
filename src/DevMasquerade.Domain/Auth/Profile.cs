using DevMasquerade.Domain.Enums;

namespace DevMasquerade.Domain.Auth;

public class Profile
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string? MiddleName { get; set; }
    public string? DisplayName { get; set; }

    public DateOnly? DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public string? AvatarUrl { get; set; }

    public string? Phone { get; set; }
    public string? Telegram { get; set; }
    public string? Instagram { get; set; }
    public string? WhatsApp { get; set; }
    public string? EmailForContact { get; set; }

    public string? Country { get; set; }
    public string? City { get; set; }
    public string? AddressLine { get; set; }
    public string? PostalCode { get; set; }
    public string? TimeZone { get; set; }

    public int? HeightCm { get; set; }
    public int? WeightKg { get; set; }
    public string? ClothingSizeTop { get; set; }
    public string? ClothingSizeBottom { get; set; }
    public decimal? ShoeSize { get; set; }
    public int? ChestGirthCm { get; set; }
    public int? WaistGirthCm { get; set; }
    public int? HipGirthCm { get; set; }

    public string? PreferredStyles { get; set; }
    public string? Allergies { get; set; }
    public string? Notes { get; set; }
    public bool IsVip { get; set; }
}