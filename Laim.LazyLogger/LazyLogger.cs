using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace Laim.LazyLogger
{
    public class LazyLogger
    {
        internal readonly string _logPath = Path.Combine(Environment.CurrentDirectory, "logs");
        internal LoggingLevelSwitch _levelSwitch;

        public LazyLogger(string fileName = "app.log", LogEventLevel logLevel = LogEventLevel.Information)
        {
            _levelSwitch = new() { MinimumLevel = logLevel };

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.ControlledBy(_levelSwitch)
                .WriteTo.File(Path.Combine(_logPath, fileName), rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] [{SourceContext}] {Message}{NewLine}{Exception}") // Log to file with daily rolling
                .CreateLogger();
        }

        public static void Information<T>(string message) where T : class => Log.ForContext<T>().Information(message);
        public static void Error<T>(string message) where T : class => Log.ForContext<T>().Error(message);
        public static void Fatal<T>(string message) where T : class => Log.ForContext<T>().Fatal(message);
        public static void Debug<T>(string message) where T : class => Log.ForContext<T>().Debug(message);
        public static void Warning<T>(string message) where T : class => Log.ForContext<T>().Warning(message);
    }
}
