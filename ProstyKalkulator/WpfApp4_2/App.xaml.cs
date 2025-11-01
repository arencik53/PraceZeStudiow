using System;
using System.Diagnostics;
using System.Windows;

namespace DzielenieLiczb
{
    public partial class App : Application
    {
        private readonly Stopwatch _initStopwatch = new Stopwatch();
        private const long WarningThresholdMs = 500;

        protected override void OnStartup(StartupEventArgs e)
        {
            _initStopwatch.Start();
            base.OnStartup(e);
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);

            _initStopwatch.Stop();
            var initTime = _initStopwatch.ElapsedMilliseconds;

            if (initTime > WarningThresholdMs)
            {
                EventLog.WriteEntry("Application",
                    $"Aplikacja WPF inicjalizowała się zbyt długo: {initTime} ms",
                    EventLogEntryType.Warning);
            }

            Console.WriteLine($"Czas inicjalizacji: {initTime} ms");
        }
    }
}