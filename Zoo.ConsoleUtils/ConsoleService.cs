using Zoo.Domain.Abstractions;
using Zoo.Domain.Entities;

namespace Zoo.ConsoleUtils;

public class ConsoleService : IConsoleService
{
    private readonly Domain.Services.Zoo _zoo;

    public ConsoleService(Domain.Services.Zoo zoo)
    {
        _zoo = zoo;
    }

    public void Run()
    {
        while (true)
        {
            PrintMenu();
            Console.Write("Ваш выбор: ");
            var input = Console.ReadLine();
            Console.Clear();
            switch (input)
            {
                case "1":
                    AddAnimal();
                    break;
                case "2":
                    AddThing();
                    break;
                case "3":
                    Console.WriteLine($"Общее потребление еды в день: {_zoo.GetTotalFoodPerDay()}");
                    break;
                case "4":
                    Console.WriteLine($"Общее количество животных: {_zoo.GetAnimalCount()}");
                    break;
                case "5":
                    PrintContactAnimals();
                    break;
                case "6":
                    PrintInventory();
                    break;
                case "7":
                    Console.WriteLine("Выход из программы...");
                    return;
                default:
                    Console.WriteLine("Неверный ввод, попробуйте снова.\n");
                    break;
            }
        }
    }

    private void PrintMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Выберите пункт меню:");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("1. Добавить животное в зоопарк");
            Console.WriteLine("2. Добавить вещь в зоопарк");
            Console.WriteLine("3. Общее потребление еды в день");
            Console.WriteLine("4. Общее количество животных");
            Console.WriteLine("5. Животные для контактного зоопарка");
            Console.WriteLine("6. Инвентарь зоопарка");
            Console.WriteLine("7. Выйти из программы");
            Console.ResetColor();
        }

    private void AddAnimal()
    {
        Console.Clear();
        Console.WriteLine("Выберите тип животного для добавления (1 - 4): ");
        Console.Write("1. Обезьяна\n2. Кролик\n3. Тигр\n4. Волк\n");
        if (!TryParseInt(out int choice, 1, 4))
        {
            Console.WriteLine("Вы не ввели число от 1 до 4.\n");
            return;
        }
        Console.Clear();
        Console.Write("Введите суточное потребление еды: ");
        if (!TryParseUint(out int food))
        {
            Console.WriteLine("Ошибка ввода! Потребление еды должно быть положительным числом.");
            return;
        }
        Animal animal;
        if (choice == 1 || choice == 2)
        {
            Console.Write("Введите уровень доброты (1-10): ");
            if (!TryParseInt(out int kindness, 1, 10))
            {
                Console.WriteLine("Ошибка ввода! Доброта должна быть числом от 1 до 10.");
                return;
            }
            animal = choice == 1 ? new Monkey(food, kindness) : new Rabbit(food, kindness);
        }
        else
        {
            animal = choice == 3 ? new Tiger(food) : new Wolf(food);
        }

        Console.WriteLine(_zoo.AddAnimal(animal)
            ? $"Животное добавлено успешно!"
            : $"Животное  не прошло ветеринарный осмотр.");
    }

    private void AddThing()
    {
        Console.Clear();
        Console.WriteLine("Выберите тип вещи для добавления (1 - 2): ");
        Console.Write("1. Компьютер\n2. Стол\n");
        if (!TryParseInt(out int choice, 1, 2))
        {
            Console.WriteLine("Вы не ввели число от 1 до 2.\n");
            return;
        }
        Thing thing = choice == 1 ? new Computer() : new Table();
        _zoo.AddThing(thing);
        Console.WriteLine("Вещь добавлена в зоопарк.");
    }

    private void PrintInventory()
    {
        var items = _zoo.GetInventoryItems();
        if (items.Count == 0)
        {
            Console.WriteLine("Инвентарь пуст.");
            return;
        }
            
        Console.WriteLine("Содержимое зоопарка:");
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    private void PrintContactAnimals()
    {
        var items = _zoo.GetContactZooAnimals();
        if (items.Count == 0)
        {
            Console.WriteLine("Животных для контактного зоопарка нет.");
            return;
        }
            
        Console.WriteLine("Животные для контактного зоопарка:");
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }
    
    private bool TryParseInt(out int result, int min, int max)
    {
        string? input = Console.ReadLine();
        if (int.TryParse(input, out result) && result >= min && result <= max)
        {
            return true;
        }
        result = 0;
        return false;
    }
    
    private bool TryParseUint(out int result)
    {
        string? readLine = Console.ReadLine();
        if (int.TryParse(readLine, out result) && result > 0)
        {
            return true;
        }
        result = 0;
        return false;
    }
}