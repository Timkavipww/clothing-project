namespace Application.DTO;

public class ClothingCreateDTO
{
    [JsonIgnore]
    public Guid Id {get; set; } = Guid.CreateVersion7();
    public string Name { get; set; } = string.Empty;
    public Guid? BrandId { get; set; }
}
