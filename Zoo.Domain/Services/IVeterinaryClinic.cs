using Zoo.Domain.Abstractions;

namespace Zoo.Domain.Services;

public interface IVeterinaryClinic
{
    bool IsHealth(Animal animal);
}