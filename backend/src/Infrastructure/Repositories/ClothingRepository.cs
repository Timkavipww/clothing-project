namespace Infrastructure.Repositories;

public class ClothingRepository(ClothingDbContext _context) : IClothingRepository
{
    
    public async Task AddAsync(ClothingItem clo, CancellationToken cts)
    {
        await _context.Clothings.AddAsync(clo, cts);
        await _context.SaveChangesAsync(cts);
    }

    public async Task<Guid> DeleteAsync(Guid id, CancellationToken cts)
    {   
        var entity = await _context.Clothings.FirstOrDefaultAsync(clo => clo.Id == id, cts);
        if(entity is null)
            throw new EntityNotFoundException($"Clothing with Id: {id} not found");

        _context.Clothings.Remove(entity);
        await _context.SaveChangesAsync(cts);
        return id;
    }

    public async Task<IEnumerable<ClothingItem>> GetAllAsync(CancellationToken cts)
    {
        return await _context.Clothings.AsNoTracking().ToListAsync(cts);
    }

    public async Task<ClothingItem> GetByIdAsync(Guid id, CancellationToken cts)
    {
        var entity = await _context.Clothings.FirstOrDefaultAsync(clo => clo.Id == id, cts);
        if(entity is null)
            throw new EntityNotFoundException($"Clothing with Id: {id} not found");

        return entity;
    }
    public async Task UpdateAsync(ClothingItem clo, CancellationToken cts)
    {
        _context.Clothings.Update(clo);
        await _context.SaveChangesAsync(cts);
    }

}
