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
    public async Task<ActionResult<ClothingResponseDTO>> GetAll(CancellationToken cts)
    {
        var result = await _clothingService.GetAllAsync(cts);
        return Ok(result);
    }
}
