using DevMasquerade.Application.Costumes.Costumes;
using DevMasquerade.Contracts.Costumes.Costumes;
using Microsoft.AspNetCore.Mvc;

namespace DevMasquerade.Presenters.Costumes;

[ApiController]
[Route("[controller]")]
public class CostumesController : ControllerBase
{
    private readonly ICostumesService _costumesService;

    public CostumesController(ICostumesService costumesService)
    {
        _costumesService = costumesService;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetCostumeDto request, CancellationToken cancellationToken)
    {
        var costumes = await _costumesService.GetAllAsync(cancellationToken);
        if (costumes is null) return NotFound();
        return Ok(costumes);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var costumes = await _costumesService.GetByIdAsync(id, cancellationToken);
        if (costumes is null) return NotFound();
        return Ok(costumes);
    }


    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateCostumeDto requestDto,
        CancellationToken cancellationToken)
    {
        var categoryId = await _costumesService.CreateAsync(requestDto, cancellationToken);
        return CreatedAtAction(nameof(Create), new { categoryId }, categoryId);
    }


    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        [FromRoute] Guid id,
        [FromBody] UpdateCostumeDto requestDto,
        CancellationToken cancellationToken)
    {
        await _costumesService.UpdateAsync(id, requestDto, cancellationToken);
        return Ok("Update Category");
    }


    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var category = await _costumesService.DeleteAsync(id, cancellationToken);
        return Ok(category);
    }
}