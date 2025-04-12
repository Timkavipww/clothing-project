namespace Application.Services;

public class ClothingService : IClothingService
{
    private IClothingRepository _cloRepo;
    public ClothingService(IClothingRepository cloRepo)
    {
        _cloRepo = cloRepo;
    }
    public async Task AddAsync(ClothingCreateDTO clo, CancellationToken cts)
    {
        var entity = new ClothingItem
        {
            Id = clo.Id,
            BrandId = clo.BrandId,
            Name = clo.Name,
            CreatedAt = DateTime.UtcNow
        };

        await _cloRepo.AddAsync(entity, cts);
    }

    public async Task<Guid> DeleteAsync(Guid id, CancellationToken cts)
    {
        await _cloRepo.DeleteAsync(id, cts);
        return id;
    }

    public async Task<IEnumerable<ClothingResponseDTO>> GetAllAsync(CancellationToken cts)
    {
        var entities =  await _cloRepo.GetAllAsync(cts);
        return entities.Select(entity => new ClothingResponseDTO
        {
            Id = entity.Id,
            Brand = entity.Brand,
            Name = entity.Name
        });
    }

    public async Task<ClothingResponseDTO> GetByIdAsync(Guid id, CancellationToken cts)
    {
        var entity = await _cloRepo.GetByIdAsync(id, cts);
        return new ClothingResponseDTO {Brand = entity.Brand, Id = entity.Id, Name = entity.Name};
    }

    public async Task UpdateAsync(ClothingUpdateDTO clo, CancellationToken cts)
    {
        var entity = await _cloRepo.GetByIdAsync(clo.Id, cts);
        var newEntity = new ClothingItem
        {
            Name = clo.Name,
            BrandId = clo.BrandId
        };
        await _cloRepo.UpdateAsync(newEntity, cts);
    }

}
