using DevMasquerade.Domain.Enums;

namespace DevMasquerade.Contracts.Costumes.Costumes;

public record GetCostumeDto(
    string Search,
    int Page,
    int PageSize
);