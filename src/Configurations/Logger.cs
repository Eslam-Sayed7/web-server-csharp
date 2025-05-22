namespace web_server_csharp;

public class Logger
{
    public static void Log(string message)
    {
        // Log to console
        Console.WriteLine($"[{DateTime.Now}] {message}");
        // Optionally, log to a file / database
    }
}