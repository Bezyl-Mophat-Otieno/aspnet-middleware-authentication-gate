namespace AuthenticationGateMiddleware.Extensions;

public static class LoggingExtension
{

    public static void ConfigureLogging(this ILoggingBuilder logging)
    {
        logging.ClearProviders();
        logging.AddConsole();
        logging.AddFile("Logs/app-{Date}.txt");
    }
    
}