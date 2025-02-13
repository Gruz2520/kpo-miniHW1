using System;

namespace kpo_miniHW1
{
    /// <summary>
    /// Статический класс для обработки исключений.
    /// Предоставляет методы для обработки различных типов ошибок.
    /// </summary>
    public static class ErrorHandler
    {
        /// <summary>
        /// Обрабатывает исключения типа InvalidOperationException.
        /// Используется для ошибок, связанных с настройкой сервисов.
        /// </summary>
        /// <param name="ex">Исключение InvalidOperationException.</param>
        public static void HandleInvalidOperationException(InvalidOperationException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Бяда настройки сервисов:");
            Console.WriteLine(ex.Message);
            Console.ResetColor();
            LogErrorToFile(ex);
        }

        /// <summary>
        /// Обрабатывает исключения типа FormatException.
        /// Используется для ошибок, связанных с некорректным форматом ввода данных.
        /// </summary>
        /// <param name="ex">Исключение типа FormatException.</param>
        public static void HandleFormatException(FormatException ex)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Бяда ввода данных: Некорректный формат.");
            Console.WriteLine(ex.Message);
            Console.ResetColor();
            LogErrorToFile(ex);
        }

        /// <summary>
        /// Обрабатывает исключения типа ArgumentException.
        /// Используется для ошибок, связанных с недопустимыми значениями ввода данных.
        /// </summary>
        /// <param name="ex">Исключение ArgumentException.</param>
        public static void HandleArgumentException(ArgumentException ex)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Бяда ввода данных: Недопустимое значение.");
            Console.WriteLine(ex.Message);
            Console.ResetColor();
            LogErrorToFile(ex);
        }

        /// <summary>
        /// Обрабатывает исключения типа NullReferenceException.
        /// Используется для критических ошибок, связанных с обращением к неинициализированным объектам.
        /// </summary>
        /// <param name="ex">Исключение NullReferenceException.</param>
        public static void HandleNullReferenceException(NullReferenceException ex)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Большая бяда: Обращение к неинициализированному объекту.");
            Console.WriteLine(ex.Message);
            Console.ResetColor();
            LogErrorToFile(ex);
        }

        /// <summary>
        /// Обрабатывает общие исключения.
        /// Используется для всех остальных типов исключений.
        /// </summary>
        /// <param name="ex">Общее исключение.</param>
        public static void HandleGeneralException(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Произошла неожиданная бяда:");
            Console.WriteLine(ex.Message);
            Console.ResetColor();
            LogErrorToFile(ex);
        }

        /// <summary>
        /// Логирует ошибку в файл error_log.txt.
        /// Если запись в файл невозможна, выводит сообщение в консоль.
        /// </summary>
        /// <param name="ex">Исключение для логирования.</param>
        private static void LogErrorToFile(Exception ex)
        {
            try
            {
                string logFilePath = "error_log.txt";
                using (var writer = new System.IO.StreamWriter(logFilePath, append: true))
                {
                    writer.WriteLine($"[{DateTime.Now}] Ошибка: {ex.Message}");
                    writer.WriteLine($"StackTrace: {ex.StackTrace}");
                    writer.WriteLine(new string('-', 50));
                }
            }
            catch
            {
                // Если запись в файл невозможна, выводим сообщение в консоль
                Console.WriteLine("Не удалось записать ошибку в файл.");
            }
        }
    }
}