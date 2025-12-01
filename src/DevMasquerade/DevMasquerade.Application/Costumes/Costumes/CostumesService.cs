using DevMasquerade.Contracts.Costumes.Costumes;
using DevMasquerade.Domain.Costumes;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace DevMasquerade.Application.Costumes.Costumes;

public class CostumesService : ICostumesService
{
    private readonly ICostumesRepository _costumesRepository;
    private readonly ILogger<CostumesService> _logger;
    private readonly IValidator<CreateCostumeDto> _createValidator;
    private readonly IValidator<UpdateCostumeDto> _updateValidator;

    public CostumesService(
        ICostumesRepository costumesRepository,
        ILogger<CostumesService> logger,
        IValidator<CreateCostumeDto> createValidator,
        IValidator<UpdateCostumeDto> updateValidator)
    {
        _costumesRepository = costumesRepository;
        _logger = logger;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
    }

    public async Task<Costume?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken)
    {
        return await _costumesRepository.GetByIdAsync(id, cancellationToken);
    }

    public async Task<List<Costume>?> GetAllAsync(
        CancellationToken cancellationToken)
    {
        return await _costumesRepository.GetAllAsync(cancellationToken);
    }

    public async Task<Costume> CreateAsync(
        CreateCostumeDto request,
        CancellationToken cancellationToken)
    {
        // валидация данных 
        var validator = _createValidator.Validate(request);
        if (!validator.IsValid)
        {
            throw new ValidationException(validator.Errors);
        }

        // создание сущности
        var costumeId = Guid.NewGuid();
        var costume = new Costume(
            costumeId,
            request.Name,
            request.Code,
            request.Description,
            request.ShortDescription,
            request.AgeGroup,
            request.TargetGender,
            request.BasePricePerDay);

        // добавление сущности
        await _costumesRepository.AddAsync(costume, cancellationToken);
        // логирование сущности
        _logger.LogInformation("Costume {costumeId} created", costumeId);

        return costume;
    }

    public async Task<Costume> UpdateAsync(
        Guid id,
        UpdateCostumeDto request,
        CancellationToken cancellationToken)
    {
        // Проверка сущности
        var costume = await _costumesRepository.GetByIdAsync(id, cancellationToken);
        if (costume is null)
        {
            throw new ValidationException("Costume not found");
        }
        
        var validator = _updateValidator.Validate(request); 
        if (!validator.IsValid)
        {
            throw new ValidationException(validator.Errors);
        }
        
        costume.Name = request.Name;
        costume.Code = request.Code;
        costume.Description = request.Description;
        costume.ShortDescription = request.ShortDescription;
        costume.AgeGroup = request.AgeGroup;
        costume.TargetGender = request.TargetGender;
        costume.BasePricePerDay = request.BasePricePerDay;
        
        await _costumesRepository.UpdateAsync(costume, cancellationToken);
        
        await _costumesRepository.SaveChangesAsync(cancellationToken);
        
        _logger.LogInformation("Costume {costumeId} updated", costume.Id);
        return costume;
    }

    public async Task<Costume> DeleteAsync(
        Guid id,
        CancellationToken cancellationToken)
    {
        // Проверка на существование
        var costume = await _costumesRepository.GetByIdAsync(id, cancellationToken);
        if (costume is null)
        {
            throw new ValidationException("Costume not found");
        }
        
        await _costumesRepository.DeleteAsync(id, cancellationToken);
        
        await _costumesRepository.SaveChangesAsync(cancellationToken);
        
        _logger.LogInformation("Costume {costumeId} deleted", costume.Id);
        return costume;
    }
}