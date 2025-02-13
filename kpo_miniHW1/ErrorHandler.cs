using System;

namespace kpo_miniHW1
{
    public static class ErrorHandler
    {
        public static void HandleInvalidOperationException(InvalidOperationException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Бяда настройки сервисов:");
            Console.WriteLine(ex.Message);
            Console.ResetColor();
            LogErrorToFile(ex);
        }

        public static void HandleFormatException(FormatException ex)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Бяда ввода данных: Некорректный формат.");
            Console.WriteLine(ex.Message);
            Console.ResetColor();
            LogErrorToFile(ex);
        }

        public static void HandleArgumentException(ArgumentException ex)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Бяда ввода данных: Недопустимое значение.");
            Console.WriteLine(ex.Message);
            Console.ResetColor();
            LogErrorToFile(ex);
        }

        public static void HandleNullReferenceException(NullReferenceException ex)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Большая бяда: Обращение к неинициализированному объекту.");
            Console.WriteLine(ex.Message);
            Console.ResetColor();
            LogErrorToFile(ex);
        }

        public static void HandleGeneralException(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Произошла неожиданная бяда:");
            Console.WriteLine(ex.Message);
            Console.ResetColor();
            LogErrorToFile(ex);
        }

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
                Console.WriteLine("Не удалось записать ошибку в файл.");
            }
        }
    }
}
