namespace WebAPI.Controllers.V1;

[Route("clothings")]
public class ClothingContoller : BaseApiController
{
    private readonly IClothingService _clothingService;
    public ClothingContoller(IClothingService clothingService)
    {
        _clothingService = clothingService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClothingResponseDTO>>> GetAll(CancellationToken cts)
    {
        var result = await _clothingService.GetAllAsync(cts);
        return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<ClothingResponseDTO>> GetById(Guid id, CancellationToken cts)
    {
        var result = await _clothingService.GetByIdAsync(id, cts);
        return Ok(result);
    }
    [HttpPost]
    public async Task<ActionResult> Add(ClothingCreateDTO clothingCreateDTO, CancellationToken cts)
    {
        await _clothingService.AddAsync(clothingCreateDTO, cts);
        return Created();
    }
    [HttpDelete]
    public async Task<ActionResult> Delete(Guid id, CancellationToken cts)
    {
        await _clothingService.DeleteAsync(id, cts);
        return NoContent();
    }
    [HttpPut("{id}")]
    public async Task<ActionResult<ClothingResponseDTO>> Update(Guid id, ClothingUpdateDTO clothingUpdateDTO, CancellationToken cts)
    {
        var result = await _clothingService.UpdateAsync(id, clothingUpdateDTO, cts);

        return Ok(result);
    }
}
