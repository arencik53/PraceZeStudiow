using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace DzielenieLiczb
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            EventLog.WriteEntry("Application", "MainWindow zainicjalizowany", EventLogEntryType.Information);
        }

        private void BtnPodziel_Click(object sender, RoutedEventArgs e)
        {
            var stopwatch = Stopwatch.StartNew();

            try
            {
                double liczba1 = double.Parse(txtLiczba1.Text);
                double liczba2 = double.Parse(txtLiczba2.Text);

                if (liczba2 == 0)
                {
                    string message = "Próba dzielenia przez zero";
                    txtWynik.Text = "Nie można dzielić przez zero!";
                    EventLog.WriteEntry("Application", message, EventLogEntryType.Warning);
                    LogErrorToFile(message);
                    return;
                }

                double wynik = liczba1 / liczba2;
                txtWynik.Text = wynik.ToString("0.##");

                EventLog.WriteEntry("Application",
                    $"Operacja dzielenia wykonana poprawnie: {liczba1} / {liczba2} = {wynik}",
                    EventLogEntryType.Information);
            }
            catch (FormatException ex)
            {
                string message = "Nieprawidłowy format liczby";
                txtWynik.Text = "Wprowadź poprawne liczby!";
                EventLog.WriteEntry("Application", message, EventLogEntryType.Error);
                LogErrorToFile($"{message}: {ex.Message}");
            }
            catch (Exception ex)
            {
                string message = $"Błąd ogólny: {ex.Message}";
                txtWynik.Text = $"Wystąpił błąd: {ex.Message}";
                EventLog.WriteEntry("Application", message, EventLogEntryType.Error);
                LogErrorToFile(message + "\n" + ex.StackTrace);
            }
            finally
            {
                stopwatch.Stop();
                Debug.WriteLine($"Operacja dzielenia zajęła: {stopwatch.ElapsedMilliseconds} ms");
            }
        }

        private void LogErrorToFile(string message)
        {
            string folderPath = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(folderPath, "error_log.txt");

            string logEntry = $"{DateTime.Now:G} - {message}\n";

            try
            {
                File.AppendAllText(filePath, logEntry);
            }
            catch
            {
            }
        }
    }
}
