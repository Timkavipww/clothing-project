namespace Domain.Common;

public interface IAudiable
{
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
