namespace Zoo.Domain.Abstractions;

public abstract class Thing : IInventory
{
    public int Number { get; set; }

    public override string ToString()
    {
        return $"№{Number} - {GetType().Name}";
    }
}