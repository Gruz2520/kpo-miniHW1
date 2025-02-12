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

        // Получаем экземпляр MenuRenderer
        var menuRenderer = serviceProvider.GetRequiredService<MenuRenderer>();

        // Запускаем меню
        menuRenderer.Render();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        // Создаем экземпляр IVeterinaryClinic
        var veterinaryClinic = new VeterinaryClinic();

        // Создаем экземпляр Zoo
        var zooInstance = new Zoo(veterinaryClinic);

        // Регистрируем экземпляры как Singleton
        services.AddSingleton<IVeterinaryClinic>(veterinaryClinic);
        services.AddSingleton<Zoo>(zooInstance);

        // Регистрируем интерфейсы для Zoo
        services.AddSingleton<IAnimalManager>(zooInstance);
        services.AddSingleton<IFoodCalculator>(zooInstance);
        services.AddSingleton<IPettingZoo>(zooInstance);
        services.AddSingleton<IInventoryPrinter>(zooInstance);

        // Регистрируем действия меню
        services.AddTransient<IMenuAction, AddAnimalAction>();
        services.AddTransient<IMenuAction, ShowTotalFoodConsumptionAction>();
        services.AddTransient<IMenuAction, ShowAnimalsForPettingZooAction>();
        services.AddTransient<IMenuAction, ShowInventoryAction>();
        services.AddTransient<IMenuAction, AddThingAction>();

        // Регистрируем MenuRenderer
        services.AddTransient<MenuRenderer>();
    }
}