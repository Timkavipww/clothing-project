using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IClothingRepository
{
    public Task<IEnumerable<ClothingItem>> GetAllAsync(CancellationToken cts);
    public Task<ClothingItem> GetByIdAsync(Guid id, CancellationToken cts);
    public Task AddAsync(ClothingItem clo, CancellationToken cts);
    public Task UpdateAsync(ClothingItem clo, CancellationToken cts);
    public Task<Guid> DeleteAsync(Guid id, CancellationToken cts);
}
