using Zoo.Domain.Abstractions;

namespace Zoo.Domain.Entities;

public class Monkey : Herbo
{
    public Monkey(int food, int kindness) : base(food, kindness)
    {
    }
}