namespace Zoo.Domain.Abstractions;

public abstract class Predator : Animal
{
    protected Predator(int food) : base(food)
    {
    }
}
