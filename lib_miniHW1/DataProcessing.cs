using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lib_miniHW1
{
    /// <summary>
    /// Статический класс для обработки ввода данных от пользователя.
    /// Предоставляет методы для чтения чисел, строк и других типов данных с проверкой корректности.
    /// </summary>
    public static class DataProcessing
    {
        /// <summary>
        /// Запрашивает у пользователя целочисленное значение в указанном диапазоне.
        /// Если введено некорректное значение или значение выходит за пределы диапазона,
        /// пользователь получает соответствующее сообщение и может повторить попытку.
        /// </summary>
        /// <param name="prompt">Сообщение, выводимое пользователю перед запросом ввода.</param>
        /// <param name="value">Переменная, в которую записывается результат.</param>
        /// <param name="min">Минимально допустимое значение.</param>
        /// <param name="max">Максимально допустимое значение.</param>
        public static void ReadInt(string prompt, out int value, double min = double.MinValue, double max = double.MaxValue)
        {
            bool isValidInput;
            do
            {
                Console.Write(prompt);
                isValidInput = int.TryParse(Console.ReadLine(), out value);

                if (!isValidInput)
                {
                    Console.WriteLine("Введено не число. Повторите попытку.");
                }
                else if (value < min || value > max)
                {
                    Console.WriteLine($"Введенное число находится вне допустимого диапазона ({min}, {max}). Повторите попытку.");
                }
            } while (!isValidInput || value < min || value > max);
        }

        /// <summary>
        /// Запрашивает у пользователя вещественное значение в указанном диапазоне.
        /// Если введено некорректное значение или значение выходит за пределы диапазона,
        /// пользователь получает соответствующее сообщение и может повторить попытку.
        /// </summary>
        /// <param name="prompt">Сообщение, выводимое пользователю перед запросом ввода.</param>
        /// <param name="value">Переменная, в которую записывается результат.</param>
        /// <param name="min">Минимально допустимое значение.</param>
        /// <param name="max">Максимально допустимое значение.</param>
        public static void ReadDouble(string prompt, out double value, double min = double.MinValue, double max = double.MaxValue)
        {
            bool isValidInput;
            do
            {
                Console.Write(prompt);
                isValidInput = double.TryParse(Console.ReadLine(), out value);

                if (!isValidInput)
                {
                    Console.WriteLine("Введено не число. Повторите попытку.");
                }
                else if (value < min || value > max)
                {
                    Console.WriteLine($"Введенное число находится вне допустимого диапазона ({min}, {max}). Повторите попытку.");
                }
            } while (!isValidInput || value < min || value > max);
        }

        /// <summary>
        /// Запрашивает у пользователя строку с возможностью проверки на пустоту.
        /// Если строка не может быть пустой, пользователь получит соответствующее сообщение
        /// и сможет повторить попытку.
        /// </summary>
        /// <param name="prompt">Сообщение, выводимое пользователю перед запросом ввода.</param>
        /// <param name="result">Переменная, в которую записывается результат.</param>
        /// <param name="allowEmpty">Флаг, указывающий, разрешена ли пустая строка.</param>
        public static void ReadString(string prompt, out string result, bool allowEmpty = false)
        {
            while (true)
            {
                Console.Write(prompt);
                result = Console.ReadLine()?.Trim();

                if (allowEmpty || !string.IsNullOrEmpty(result))
                {
                    return;
                }

                Console.WriteLine("Строка не может быть пустой. Попробуйте снова.");
            }
        }
    }
}