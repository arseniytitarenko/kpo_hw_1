using Zoo.Domain.Abstractions;

namespace Zoo.Domain.Entities;

public class Wolf : Predator
{
    public Wolf(int food) : base(food)
    {
    }
}