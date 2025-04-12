using System.Data;

namespace Application.Extensions;

public static class ClothingExtensions
{
    public static void Update(this ClothingItem oldClo, ClothingUpdateDTO newClo)
    {
        if (!string.IsNullOrWhiteSpace(newClo.Name))
            oldClo.Name = newClo.Name;
    }
}
