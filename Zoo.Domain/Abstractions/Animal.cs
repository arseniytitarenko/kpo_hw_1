namespace Zoo.Domain.Abstractions;

public abstract class Animal : IInventory, IAlive
{
    protected Animal(int food)
    {
        Food = food;
    }
    public int Number { get; set; }
    public int Food { get; }

    public override string ToString()
    {
        return $"№{Number} - {GetType().Name} потребляет {Food} кг/сутки";
    }
}