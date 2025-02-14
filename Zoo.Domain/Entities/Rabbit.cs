using Zoo.Domain.Abstractions;

namespace Zoo.Domain.Entities;

public class Rabbit : Herbo
{
    public Rabbit(int food, int kindness) : base(food, kindness)
    {
    }
}