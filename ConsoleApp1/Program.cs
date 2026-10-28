using System;
using System.Diagnostics;
using System.ComponentModel;

public class Program
{
    public static async Task Main()
    {
        ProcessStartInfo startInfo = new()
        {
            FileName = "dotnet",
            UseShellExecute = false,
            CreateNoWindow = true,

            // TODO 1. Включите перенаправление stdout.
            RedirectStandardOutput = true,
            // TODO 2. Включите перенаправление stderr.
            RedirectStandardError = true
        };

        startInfo.ArgumentList.Add("--info");

        using Process process = new()
        {
            StartInfo = startInfo
        };

        Stopwatch stopwatch = Stopwatch.StartNew();

        try
        {
            // TODO 3. Запустите процесс.
            process.Start();

            Console.WriteLine($"PID: {process.Id}");

            // TODO 4. Начните чтение stdout асинхронно.
            Task<string> stdoutTask = process.StandardOutput.ReadToEndAsync();
            // TODO 5. Начните чтение stderr асинхронно.
            Task<string> stderrTask = process.StandardError.ReadToEndAsync();
            // Важно: начать оба чтения до ожидания завершения.

            // TODO 6. Дождитесь завершения процесса.
            await process.WaitForExitAsync();
            // TODO 7. Получите оба результата чтения.
            string stdout = await stdoutTask;
            string stderr = await stderrTask;
            // TODO 8. Остановите секундомер.
            stopwatch.Stop();

            // TODO 9. Выведите длительность и ExitCode.
            Console.WriteLine($"Длительность: {stopwatch.Elapsed}");
            Console.WriteLine($"ExitCode: {process.ExitCode}");
            // TODO 10. Выведите stdout и stderr отдельно.
            Console.WriteLine("=== STDOUT ===");
            Console.WriteLine(stdout);

            Console.WriteLine("=== STDERR ===");
            Console.WriteLine(stderr);
        }
        catch (Win32Exception ex)
        {
            stopwatch.Stop();
            Console.WriteLine($"Ошибка запуска: {ex.Message}");
        }
    }
}