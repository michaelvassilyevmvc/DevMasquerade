using DevMasquerade.Contracts.Costumes.Categories;
using DevMasquerade.Domain.Costumes;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace DevMasquerade.Application.Costumes.Categories;

public class CategoriesService : ICategoriesService
{
    private readonly ICategoriesRepository _categoriesRepository;
    private readonly ILogger<CategoriesService> _logger;
    private readonly IValidator<CreateCategoryDto> _createValidator;
    private readonly IValidator<UpdateCategoryDto> _updateValidator;

    public CategoriesService(
        ICategoriesRepository categoriesRepository,
        ILogger<CategoriesService> logger,
        IValidator<CreateCategoryDto> createValidator,
        IValidator<UpdateCategoryDto> updateValidator)
    {
        _categoriesRepository = categoriesRepository;
        _logger = logger;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
    }
    
    public async Task<Category> CreateAsync(CreateCategoryDto request, CancellationToken cancellationToken)
    {
        // валидация данных
        var validator = await _createValidator.ValidateAsync(request, cancellationToken);

        if (!validator.IsValid)
        {
            throw new ValidationException(validator.Errors);
        }

        // создание сущности
        var categoryId = Guid.NewGuid();
        var category = new Category(categoryId, request.Name, request.Slug, request.Description, request.ParentId);

        // добавление сущности
        await _categoriesRepository.AddAsync(category, cancellationToken);
        // логирование сущности
        _logger.LogInformation("Category {categoryId} created", categoryId);

        return category;
    }

    public async Task<Category> UpdateAsync(
        Guid id,
        UpdateCategoryDto request,
        CancellationToken cancellationToken)
    {
        // Проверка существования сущности
        var category = await _categoriesRepository.GetByIdAsync(id, cancellationToken);
        if (category is null)
        {
            throw new ValidationException("Category not found");
        }

        // Валидация новых данных 
        var validator = await _updateValidator.ValidateAsync(request, cancellationToken);
        if (!validator.IsValid)
        {
            throw new ValidationException(validator.Errors);
        }

        // Обновление сущности
        category.Name = request.Name;
        category.Slug = request.Slug;
        category.Description = request.Description ?? category.Description;
        category.ParentId = request.ParentId ?? category.ParentId;
        await _categoriesRepository.UpdateAsync(category, cancellationToken);

        // Сохранение измененной сущности
        await _categoriesRepository.SaveChangesAsync(cancellationToken);
        // Логирование 
        _logger.LogInformation("Category {categoryId} updated", category.Id);

        return category;
    }

    public async Task<Category> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        // Проверка существования сущности
        var category = await _categoriesRepository.GetByIdAsync(id, cancellationToken);
        if (category is null)
        {
            throw new ValidationException("Category not found");
        }

        // Удаление сущности
        // Удаление сущности
        await _categoriesRepository.DeleteAsync(id, cancellationToken);
        // Логирование 
        _logger.LogInformation("Category {categoryId} deleted", category.Id);

        return category;
    }

    public async Task<Category?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        // Получить сущность
        return await _categoriesRepository.GetByIdAsync(id, cancellationToken);
    }

    public async Task<List<Category>?> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _categoriesRepository.GetAllAsync(cancellationToken);
    }
}