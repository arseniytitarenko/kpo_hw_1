namespace Zoo.Domain.Abstractions;

public abstract class Herbo : Animal
{
    protected Herbo(int food, int kindness) : base(food)
    {
        Kindness = kindness;
    }

    private int _kindness;
    
    public int Kindness
    {
        get => _kindness;
        set
        {
            if (value <= 0 || value > 10)
                throw new ArgumentOutOfRangeException($"Kindness must be between 1 and 10");
            _kindness = value;
        }
    }

    public bool IsContactAnimal => Kindness > 5;

    public override string ToString()
    {
        return base.ToString() + $", доброта: {Kindness}";
    }
}