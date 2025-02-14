using Microsoft.Extensions.DependencyInjection;
using Zoo.ConsoleUtils;
using Zoo.Domain.Services;

namespace ZooERP;

class Program
{
    public static void Main(string[] args)
    {
        var services = new ServiceCollection();

        services.AddSingleton<IVeterinaryClinic, VeterinaryClinic>();
        services.AddSingleton<Zoo.Domain.Services.Zoo>();

        services.AddSingleton<IConsoleService, ConsoleService>();

        var serviceProvider = services.BuildServiceProvider();

        var consoleService = serviceProvider.GetRequiredService<IConsoleService>();
        consoleService.Run();
    }
}