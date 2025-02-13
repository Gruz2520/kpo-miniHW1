using System;
using lib_miniHW1;
using Microsoft.Extensions.DependencyInjection;

namespace kpo_miniHW1
{
    class main_kpo_miniHW1
    {
        static void Main(string[] args)
        {
            try
            {
                // Настройка DI-контейнера
                var serviceCollection = new ServiceCollection();
                ConfigureServices(serviceCollection);

                // Создание провайдера сервисов
                var serviceProvider = serviceCollection.BuildServiceProvider();

                // Получение экземпляра MenuRenderer
                var menuRenderer = serviceProvider.GetRequiredService<MenuRenderer>();

                // Запуск рендера меню
                menuRenderer.Render();
            }
            catch (InvalidOperationException ex)
            {
                ErrorHandler.HandleInvalidOperationException(ex);
            }
            catch (FormatException ex)
            {
                ErrorHandler.HandleFormatException(ex);
            }
            catch (ArgumentException ex)
            {
                ErrorHandler.HandleArgumentException(ex);
            }
            catch (NullReferenceException ex)
            {
                ErrorHandler.HandleNullReferenceException(ex);
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleGeneralException(ex);
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            try
            {
                var veterinaryClinic = new VeterinaryClinic();
                if (veterinaryClinic == null)
                {
                    throw new InvalidOperationException("Не удалось создать экземпляр VeterinaryClinic.");
                }

                var zooInstance = new Zoo(veterinaryClinic);
                if (zooInstance == null)
                {
                    throw new InvalidOperationException("Не удалось создать экземпляр Zoo.");
                }

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
            catch (InvalidOperationException ex)
            {
                ErrorHandler.HandleInvalidOperationException(ex);
                throw;
            }
        }
    }
}