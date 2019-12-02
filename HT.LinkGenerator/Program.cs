using System;
using System.Windows.Forms;
using HT.LinkGenerator.Forms;
using Serilog;
using Serilog.Events;

namespace HT.LinkGenerator
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Is(GetLogLevel())
                .WriteTo.File("logs\\ht-linkgenerator.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Starting application...");

            try
            {
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new InitForm());
                Log.Information("Application is shutting down..");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, $"Unhandled error in application: '{ex.Message}'");
                throw;
            }
        }

        private static LogEventLevel GetLogLevel()
        {
            var logSetting = Environment.GetEnvironmentVariable("LinkGeneratorLogLevel");
            var parsed = Enum.TryParse<LogEventLevel>(logSetting, out var logLevel);
            return parsed
                ? logLevel
                : LogEventLevel.Warning;
        }
    }
}