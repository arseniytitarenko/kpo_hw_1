using Zoo.Domain.Abstractions;

namespace Zoo.Domain.Services;

public class VeterinaryClinic : IVeterinaryClinic
{
    public bool IsHealth(Animal animal)
    {
        var random = new Random();
        return random.NextDouble() < 0.8;
    }
}