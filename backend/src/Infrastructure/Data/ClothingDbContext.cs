namespace Infrastructure.Data;

public class ClothingDbContext : DbContext
{
    public ClothingDbContext(DbContextOptions<ClothingDbContext> options) : base(options)
    {

    }
    public DbSet<ClothingItem> Clothings { get; set; }
}
