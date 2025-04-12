using Domain.Common;

namespace Domain.Entities;

public class ClothingItem : BaseEntity, IAudiable
{
    public required string Name { get; set; }
    public Brand? Brand { get; set; }
    public Guid? BrandId { get; set; }
    public DateTime CreatedAt { get; set; }    
    public DateTime? UpdatedAt { get; set; }
}