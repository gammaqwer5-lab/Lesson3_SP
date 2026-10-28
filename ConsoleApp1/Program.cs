using System;
using System.Diagnostics;
using System.ComponentModel;

public class Program
{
    public static async Task Main()
    {
        // Используем dotnet --info как безопасную утилиту.
        // Если dotnet недоступен через PATH, замените
        // FileName на путь к другой разрешённой утилите.

        ProcessStartInfo startInfo = new()
        {
            FileName = "dotnet",
            UseShellExecute = false,
            CreateNoWindow = true,
            WorkingDirectory = Environment.CurrentDirectory
        };

        // TODO 1. Добавьте аргумент "--info"
        // через startInfo.ArgumentList.

        // TODO 2. Укажите рабочую директорию
        // Environment.CurrentDirectory.

        startInfo.ArgumentList.Add("--info");
        using Process process = new()
        {
            StartInfo = startInfo
        };

        Stopwatch stopwatch = new();

        try
        {
            // TODO 3. Запустите секундомер.
            stopwatch.Start();
            // TODO 4. Запустите процесс через Start().
            process.Start();
            // TODO 5. Выведите PID процесса.
            Console.WriteLine($"PID: {process.Id}");
            // TODO 6. Дождитесь завершения через
            // await process.WaitForExitAsync().
            await process.WaitForExitAsync();
            // TODO 7. Остановите секундомер.
            stopwatch.Stop();
            // TODO 8. Выведите длительность и ExitCode.
            Console.WriteLine($"Длительность: {stopwatch.Elapsed}");
            Console.WriteLine($"ExitCode: {process.ExitCode}");
        }
        catch (Win32Exception ex)
        {
            // TODO 9. Сообщите об ошибке запуска.
            // Не используйте пустой catch.
            Console.WriteLine($"Ошибка запуска: {ex.Message}");
        }
    }
}