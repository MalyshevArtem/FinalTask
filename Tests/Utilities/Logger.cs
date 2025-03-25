public class Logger
{
    private string logFilePath;

    public Logger()
    {
        string fileName = "app.log";
        logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
    }

    public void Log(string message)
    {
        string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
        File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
    }
}
