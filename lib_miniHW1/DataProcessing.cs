using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lib_miniHW1
{
    public static class DataProcessing
    {


        /// <summary>
        /// Получение целочисленного значения в диапозоне от пользователя.
        /// </summary>
        /// <param Name="entery">Сообщение, которое выводится пользователю.</param>
        /// <param Name="value">Куда записывается значение.</param>
        /// <param Name="min">Нижняя граница диапозона.</param>
        /// <param Name="max">Верхняя граница диапозона.</param>
        public static void ReadInt(string entery, out int value, double min = double.MinValue, double max = double.MaxValue)
        {
            bool check_value;
            do
            {
                Console.Write(entery);
                check_value = int.TryParse(Console.ReadLine(), out value);

                if (!check_value)
                {
                    Console.WriteLine("Введено не число, повторите попытку.");
                }

                if (value < min || value > max)
                {
                    Console.WriteLine($"Введенное число находится вне границ ({min},{max}). Повторите попытку.");
                }

            } while (!check_value || value < min || value > max);
        }

        /// <summary>
        /// Получение вещественного значения в диапозоне от пользователя.
        /// </summary>
        /// <param Name="entery">Сообщение, которое выводится пользователю.</param>
        /// <param Name="value">Куда записывается значение.</param>
        /// <param Name="min">Нижняя граница диапозона.</param>
        /// <param Name="max">Верхняя граница диапозона.</param>
        public static void ReadDouble(string entery, out double value, double min = double.MinValue, double max = double.MaxValue)
        {
            bool check_value;
            do
            {
                Console.Write(entery);
                check_value = double.TryParse(Console.ReadLine(), out value);

                if (!check_value)
                {
                    Console.WriteLine("Введено не число, повторите попытку.");
                }

                if (value < min || value > max)
                {
                    Console.WriteLine($"Введенное число находится вне границ ({min},{max}). Повторите попытку.");
                }

            } while (!check_value || value < min || value > max);
        }


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