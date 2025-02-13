using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_miniHW1
{
    /// <summary>
    /// Класс для отображения и обработки меню зоопарка.
    /// </summary>
    public class MenuRenderer
    {
        /// <summary>
        /// Коллекция доступных действий в меню.
        /// </summary>
        private readonly IEnumerable<IMenuAction> _menuActions;

        /// <summary>
        /// Конструктор класса MenuRenderer.
        /// Инициализирует экземпляр с коллекцией действий меню.
        /// </summary>
        /// <param name="menuActions">Коллекция действий, доступных в меню.</param>
        public MenuRenderer(IEnumerable<IMenuAction> menuActions)
        {
            _menuActions = menuActions;
        }

        /// <summary>
        /// Отображает меню и обрабатывает выбор пользователя.
        /// Меню работает в бесконечном цикле до завершения программы.
        /// </summary>
        public void Render()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Меню зоопарка ===");

                int index = 1;
                foreach (var action in _menuActions)
                {
                    Console.WriteLine($"{index++}. {action.Name}");
                }

                Console.WriteLine($"{Environment.NewLine}Нажмите Escape для завершения работы программы");

                var key = Console.ReadKey(true).Key;

                // Завершение программы при нажатии Escape
                if (key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }

                // Проверка, что нажата цифровая клавиша (1-9)
                if (key >= ConsoleKey.D1 && key <= ConsoleKey.D9)
                {
                    int choice = key - ConsoleKey.D1;
                    var actions = _menuActions.ToList(); // Преобразуем коллекцию в список для удобства доступа

                    if (choice >= 0 && choice < actions.Count)
                    {
                        actions[choice].Execute();
                    }
                }
            }
        }
    }
}