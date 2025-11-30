using DevMasquerade.Application.Costumes.Categories;
using DevMasquerade.Contracts.Costumes.Categories;
using Microsoft.AspNetCore.Mvc;

namespace DevMasquerade.Presenters.Costumes;

[ApiController]
[Route("[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoriesService _categoriesService;

    public CategoriesController(ICategoriesService categoriesService)
    {
        _categoriesService = categoriesService;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetCategoryDto request, CancellationToken cancellationToken)
    {
        var categories = await _categoriesService.GetAllAsync(cancellationToken);
        if (categories is null) return NotFound();
        return Ok(categories);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var categories = await _categoriesService.GetByIdAsync(id, cancellationToken);
        if (categories is null) return NotFound();
        return Ok(categories);
    }


    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateCategoryDto requestDto,
        CancellationToken cancellationToken)
    {
        var categoryId = await _categoriesService.CreateAsync(requestDto, cancellationToken);
        return CreatedAtAction(nameof(Create), new { categoryId }, categoryId);
    }


    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        [FromRoute] Guid id,
        [FromBody] UpdateCategoryDto requestDto,
        CancellationToken cancellationToken)
    {
        await _categoriesService.UpdateAsync(id, requestDto, cancellationToken);
        return Ok("Update Category");
    }


    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var category = await _categoriesService.DeleteAsync(id, cancellationToken);
        return Ok(category);
    }
}