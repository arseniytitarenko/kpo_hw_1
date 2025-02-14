using Zoo.Domain.Abstractions;

namespace Zoo.Domain.Services;


public class Zoo
{
    public Zoo(IVeterinaryClinic veterinaryClinic)
    {
        _veterinaryClinic = veterinaryClinic;
    }

    private int _numberCounter = 0;
    private readonly List<IInventory> _inventory = [];
    private readonly IVeterinaryClinic _veterinaryClinic;
    
    public bool AddAnimal(Animal animal)
    {
        if (!_veterinaryClinic.IsHealth(animal)) {
            return false;
        }
        animal.Number = ++_numberCounter;
        _inventory.Add(animal);
        return true;
    }
    
    public void AddThing(Thing thing)
    {
        thing.Number = ++_numberCounter;
        _inventory.Add(thing);
    }

    public int GetAnimalCount()
    {
        return _inventory.OfType<Animal>().Count();
    } 
    
    public int GetTotalFoodPerDay()
    {
        return _inventory.OfType<IAlive>().Sum(a => a.Food);
    }
    
    public List<Herbo> GetContactZooAnimals()
    {
        return _inventory.OfType<Herbo>().Where(x => x.IsContactAnimal).ToList();
    }
    
    public List<IInventory> GetInventoryItems()
    {
        return _inventory;
    }
}