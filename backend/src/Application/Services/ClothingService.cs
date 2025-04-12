using Application.Extensions;
using Domain.Exceptions;

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

    public async Task<ClothingResponseDTO> UpdateAsync(Guid id, ClothingUpdateDTO clo, CancellationToken cts)
    {
        var entity = await _cloRepo.GetByIdAsync(id, cts);

        if(entity is null)
            throw new EntityNotFoundException($"Clothing with id {id} not found");
        
        entity.Update(clo);

        await _cloRepo.UpdateAsync(entity, cts);
        return new ClothingResponseDTO{ Name = entity.Name, Brand = entity.Brand, Id = entity.Id};
    }

}
