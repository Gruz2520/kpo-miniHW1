using System;
using lib_miniHW1;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);

        var serviceProvider = serviceCollection.BuildServiceProvider();

        var menuRenderer = serviceProvider.GetRequiredService<MenuRenderer>();

        menuRenderer.Render();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        var veterinaryClinic = new VeterinaryClinic();

        var zooInstance = new Zoo(veterinaryClinic);

        services.AddSingleton<IVeterinaryClinic>(veterinaryClinic);
        services.AddSingleton<Zoo>(zooInstance);

        services.AddSingleton<IAnimalManager>(zooInstance);
        services.AddSingleton<IFoodCalculator>(zooInstance);
        services.AddSingleton<IPettingZoo>(zooInstance);
        services.AddSingleton<IInventoryPrinter>(zooInstance);

        services.AddTransient<IMenuAction, AddAnimalAction>();
        services.AddTransient<IMenuAction, ShowTotalFoodConsumptionAction>();
        services.AddTransient<IMenuAction, ShowAnimalsForPettingZooAction>();
        services.AddTransient<IMenuAction, ShowInventoryAction>();
        services.AddTransient<IMenuAction, AddThingAction>();

        services.AddTransient<MenuRenderer>();
    }
}