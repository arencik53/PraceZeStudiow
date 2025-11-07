using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace DzielenieLiczb
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnPodziel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double liczba1 = double.Parse(txtLiczba1.Text);
                double liczba2 = double.Parse(txtLiczba2.Text);

                if (liczba2 == 0)
                {
                    txtWynik.Text = "Nie można dzielić przez zero!";
                    return;
                }

                double wynik = liczba1 / liczba2;

                txtWynik.Text = wynik.ToString("0.##");
            }
            catch (FormatException ex)
            {
                txtWynik.Text = "Wprowadź poprawne liczby!";
                LogErrorToFile(ex);
            }
            catch (Exception ex)
            {
                txtWynik.Text = $"Wystąpił błąd: {ex.Message}";
                LogErrorToFile(ex);
            }
        }

        private void LogErrorToFile(Exception ex)
        {
            string filePath = "error_log.txt";
            string logEntry = $"{DateTime.Now:G} - {ex.Message}\n{ex.StackTrace}\n\n";

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
