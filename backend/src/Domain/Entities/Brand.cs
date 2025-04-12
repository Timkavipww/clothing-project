using Domain.Common;

namespace Domain.Entities;

public class Brand : BaseEntity
{
    public required string Name { get; set; }
}
