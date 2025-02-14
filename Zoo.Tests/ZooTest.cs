using Zoo.Domain.Abstractions;
using Zoo.Domain.Entities;
using Zoo.Domain.Services;

namespace Zoo.Tests;

using Moq;
using Xunit;

public class ZooTest
{
    private readonly Domain.Services.Zoo _zoo;

    public ZooTest()
    {
        Mock<IVeterinaryClinic> veterinaryClinicMock = new();
        veterinaryClinicMock.Setup(vc => vc.IsHealth(It.IsAny<Animal>())).Returns(true);
        _zoo = new Domain.Services.Zoo(veterinaryClinicMock.Object);
    }

    [Fact]
    public void AddAnimal_HealthyAnimal_ReturnsTrueAndAddsToInventory()
    {
        Animal animal = new Tiger(5);

        var result = _zoo.AddAnimal(animal);

        Assert.True(result);
        Assert.Equal(1, _zoo.GetAnimalCount());
    }

    [Fact]
    public void AddThing_AddsThingToInventory()
    {
        Thing thing = new Computer();

        _zoo.AddThing(thing);

        Assert.Contains(thing, _zoo.GetInventoryItems());
    }

    [Fact]
    public void GetAnimalCount_ReturnsCorrectNumber()
    {
        _zoo.AddAnimal(new Rabbit(3, 6));
        _zoo.AddAnimal(new Wolf(4));

        Assert.Equal(2, _zoo.GetAnimalCount());
    }

    [Fact]
    public void GetTotalFoodPerDay_ReturnsCorrectSum()
    {
        _zoo.AddAnimal(new Rabbit(3, 6));
        _zoo.AddAnimal(new Wolf(15));
        _zoo.AddAnimal(new Monkey(1, 2));
        _zoo.AddAnimal(new Tiger(6));

        Assert.Equal(25, _zoo.GetTotalFoodPerDay());
    }

    [Fact]
    public void GetContactZooAnimals_ReturnsOnlyContactAnimals()
    {
        var contactHerbo = new Monkey(1, 7);
        var nonContactHerbo = new Rabbit(2, 3);
        var nonContactPredator = new Tiger(6);
        
        _zoo.AddAnimal(contactHerbo);
        _zoo.AddAnimal(nonContactHerbo);
        _zoo.AddAnimal(nonContactPredator);

        var result = _zoo.GetContactZooAnimals();

        Assert.Single(result);
        Assert.Contains(contactHerbo, result);
    }

    [Fact]
    public void GetInventoryItems_ReturnsAllItems()
    {
        Animal animal = new Tiger(5);
        Thing thing = new Computer();
        
        _zoo.AddAnimal(animal);
        _zoo.AddThing(thing);

        var result = _zoo.GetInventoryItems();

        Assert.Contains(animal, result);
        Assert.Contains(thing, result);
        Assert.Equal(2, result.Count);
    }
}
