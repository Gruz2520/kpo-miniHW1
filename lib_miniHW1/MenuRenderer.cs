using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_miniHW1
{
    public class MenuRenderer
    {
        private readonly IEnumerable<IMenuAction> _menuActions;

        public MenuRenderer(IEnumerable<IMenuAction> menuActions)
        {
            _menuActions = menuActions;
        }

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
                if (key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }

                if (key >= ConsoleKey.D1 && key <= ConsoleKey.D9)
                {
                    int choice = key - ConsoleKey.D1;
                    var actions = _menuActions.ToList();
                    if (choice >= 0 && choice < actions.Count)
                    {
                        actions[choice].Execute();
                    }
                }
            }
        }
    }
}
