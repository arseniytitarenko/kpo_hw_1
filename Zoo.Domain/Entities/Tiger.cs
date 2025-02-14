using Zoo.Domain.Abstractions;

namespace Zoo.Domain.Entities;

public class Tiger : Predator
{
    public Tiger(int food) : base(food)
    {
    }
}