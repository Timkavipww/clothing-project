using Application.DTO;

namespace Application.Interfaces;

public interface IClothingService
{
    public Task<IEnumerable<ClothingResponseDTO>> GetAllAsync(CancellationToken cts);
    public Task<ClothingResponseDTO> GetByIdAsync(Guid id, CancellationToken cts);
    public Task AddAsync(ClothingCreateDTO clo, CancellationToken cts);
    public Task UpdateAsync(ClothingUpdateDTO clo, CancellationToken cts);
    public Task<Guid> DeleteAsync(Guid id, CancellationToken cts);
}
