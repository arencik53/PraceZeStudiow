using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace SimpleMonitor
{
    public partial class MainWindow : Window
    {
        private bool _isRunning;
        private readonly PerformanceCounter _cpuCounter;
        private readonly PerformanceCounter _memCounter;
        private readonly PerformanceCounter _diskCounter;
        private const string LogFile = "monitor.log";

        public MainWindow()
        {
            InitializeComponent();

            _cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            _memCounter = new PerformanceCounter("Memory", "Available MBytes");
            _diskCounter = new PerformanceCounter("LogicalDisk", "% Disk Time", "_Total");

            _cpuCounter.NextValue();
        }

        private void BtnToggle_Click(object sender, RoutedEventArgs e)
        {
            _isRunning = !_isRunning;
            btnToggle.Content = _isRunning ? "Stop" : "Start";

            if (_isRunning)
            {
                new Thread(MonitorLoop).Start();
                Log("Rozpoczęto monitorowanie");
            }
            else
            {
                Log("Zatrzymano monitorowanie");
            }
        }

        private void MonitorLoop()
        {
            while (_isRunning)
            {
                try
                {
                    float cpu = _cpuCounter.NextValue();
                    float mem = _memCounter.NextValue();
                    float disk = _diskCounter.NextValue();

                    Dispatcher.Invoke(() => {
                        tbCpu.Text = $"CPU: {cpu:F1}%";
                        tbMem.Text = $"RAM: {mem:F0} MB wolne";
                        tbDisk.Text = $"Dysk: {disk:F1}%";
                    });

                    string logEntry = $"{DateTime.Now:HH:mm:ss} | CPU: {cpu:F1}% | RAM: {mem:F0} MB | Dysk: {disk:F1}%";
                    Log(logEntry);

                    Thread.Sleep(2000);
                }
                catch (Exception ex)
                {
                    Log($"Błąd: {ex.Message}");
                    Thread.Sleep(5000);
                }
            }
        }

        private void Log(string message)
        {
            Dispatcher.Invoke(() => {
                tbLog.AppendText(message + Environment.NewLine);
                tbLog.ScrollToEnd();
            });

            File.AppendAllText(LogFile, message + Environment.NewLine);
        }
    }
}