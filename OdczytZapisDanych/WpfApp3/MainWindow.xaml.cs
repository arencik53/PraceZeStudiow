using System;
using System.IO;
using System.Windows;

namespace WpfLogApp
{
    public partial class MainWindow : Window
    {
        private readonly string filePath = "dane.txt";
        private readonly string logPath = "log.txt";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnZapisz_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string imie = txtImie.Text.Trim();

                if (string.IsNullOrWhiteSpace(imie))
                {
                    MessageBox.Show("Wprowadź imię przed zapisem.");
                    return;
                }

                File.WriteAllText(filePath, imie);

                File.AppendAllText(logPath, $"{DateTime.Now:G} - Zapisano imię: {imie}\n");

                MessageBox.Show("Dane zostały zapisane.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd: {ex.Message}");
            }
        }

        private void BtnOdczytaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string imie = File.ReadAllText(filePath);
                    txtImie.Text = imie;
                }
                else
                {
                    MessageBox.Show("Plik nie istnieje.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd: {ex.Message}");
            }
        }

        private void txtImie_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
