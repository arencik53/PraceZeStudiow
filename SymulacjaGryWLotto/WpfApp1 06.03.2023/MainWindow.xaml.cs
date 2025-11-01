using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Diagnostics;

namespace WpfApp1_06._03._2023
{
    public partial class MainWindow : Window
    {
        static int wygrana;
        static int koszt;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ZapiszLog(string typ, string wiadomosc)
        {
            string sciezkaLogu = "log.txt";
            string wpis = $"{DateTime.Now:G} [{typ}] {wiadomosc}{Environment.NewLine}";

            try
            {
                File.AppendAllText(sciezkaLogu, wpis);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Nie udało się zapisać logu: {ex.Message}");
            }
        }

        private void Zagraj_w_kostke(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.TryParse(tb_podana_liczba.Text, out int pobranaWartosc) && pobranaWartosc > 0 && pobranaWartosc < 7)
                {
                    Random random = new Random();
                    int wylosowanaLiczba = random.Next(1, 7);

                    string wynik = wylosowanaLiczba == pobranaWartosc ? "Wygrałeś!" : "Przegrałeś :(";

                    tb_wynik1.Text = $"Podana liczba: {pobranaWartosc}\n" +
                                     $"Wylosowana liczba: {wylosowanaLiczba}\n" +
                                     $"Wynik gry:{wynik}";

                    if (wynik == "Wygrałeś!")
                    {
                        tb_wynik1.Background = Brushes.Green;
                        ZapiszLog("INFO", $"Wygrana w grze w kości! Podano: {pobranaWartosc}, wylosowano: {wylosowanaLiczba}");
                    }
                    else
                    {
                        tb_wynik1.Background = Brushes.Turquoise;
                    }
                }
                else
                {
                    string errorMessage = $"Podałeś złą wartość! (Podaj wartość od 1 do 6)\nPodana wartość to: {tb_podana_liczba.Text}";
                    MessageBox.Show(errorMessage);
                    ZapiszLog("WARNING", errorMessage);
                }
            }
            catch (Exception ex)
            {
                string errorMessage = $"Błąd w grze w kości: {ex.Message}";
                MessageBox.Show(errorMessage);
                ZapiszLog("ERROR", errorMessage);
            }
        }

        private void Click_Zagraj_W_Lotto(object sender, RoutedEventArgs e)
        {
            try
            {
                SortedSet<int> liczbyPodane = new SortedSet<int>();
                SortedSet<int> liczbyWylosowane = new SortedSet<int>();
                SortedSet<int> liczbyTrafione = new SortedSet<int>();
                Random random = new Random();

                tb_lotto_wynik.Text = "";

                if (cb_losowanie.IsChecked == true)
                {
                    while (liczbyPodane.Count < 6)
                    {
                        liczbyPodane.Add(random.Next(1, 50));
                    }
                }
                else
                {
                    if (int.TryParse(tb_liczba1.Text, out int liczba1) && liczba1 > 0 && liczba1 < 50 &&
                        int.TryParse(tb_liczba2.Text, out int liczba2) && liczba2 > 0 && liczba2 < 50 &&
                        int.TryParse(tb_liczba3.Text, out int liczba3) && liczba3 > 0 && liczba3 < 50 &&
                        int.TryParse(tb_liczba4.Text, out int liczba4) && liczba4 > 0 && liczba4 < 50 &&
                        int.TryParse(tb_liczba5.Text, out int liczba5) && liczba5 > 0 && liczba5 < 50 &&
                        int.TryParse(tb_liczba6.Text, out int liczba6) && liczba6 > 0 && liczba6 < 50)
                    {
                        liczbyPodane.Add(liczba1);
                        liczbyPodane.Add(liczba2);
                        liczbyPodane.Add(liczba3);
                        liczbyPodane.Add(liczba4);
                        liczbyPodane.Add(liczba5);
                        liczbyPodane.Add(liczba6);
                    }
                    else
                    {
                        string errorMessage = "Podałeś złą wartość w textboxach! Podaj 6 unikalnych liczb z przedziału od 1 do 49!";
                        MessageBox.Show(errorMessage);
                        ZapiszLog("WARNING", errorMessage);
                        return;
                    }
                }

                if (liczbyPodane.Count == 6)
                {
                    while (liczbyWylosowane.Count < 6)
                    {
                        liczbyWylosowane.Add(random.Next(1, 50));
                    }

                    foreach (int liczba in liczbyPodane)
                    {
                        if (liczbyWylosowane.Contains(liczba))
                        {
                            liczbyTrafione.Add(liczba);
                        }
                    }

                    tb_lotto_wynik.Text += $"Twoje liczby w grze: ";
                    foreach (int liczba in liczbyPodane) tb_lotto_wynik.Text += $" {liczba}";
                    tb_lotto_wynik.Text += $"\nWylosowane liczby w grze: ";
                    foreach (int liczba in liczbyWylosowane) tb_lotto_wynik.Text += $" {liczba}";
                    tb_lotto_wynik.Text += $"\nTrafione liczby: ";
                    foreach (int liczba in liczbyTrafione) tb_lotto_wynik.Text += $" {liczba}";

                    switch (liczbyTrafione.Count)
                    {
                        case 2:
                            tb_lotto_wynik.Text += $"\nIlość trafień: {liczbyTrafione.Count} \nWygrałeś 12 zł.";
                            wygrana += 12; koszt += 3;
                            ZapiszLog("INFO", $"Wygrana w lotto: 12 zł (trafiono {liczbyTrafione.Count} liczby)");
                            break;
                        case 3:
                            tb_lotto_wynik.Text += $"\nIlość trafień: {liczbyTrafione.Count} \nWygrałeś 24 zł.";
                            wygrana += 24; koszt += 3;
                            ZapiszLog("INFO", $"Wygrana w lotto: 24 zł (trafiono {liczbyTrafione.Count} liczby)");
                            break;
                        case 4:
                            tb_lotto_wynik.Text += $"\nIlość trafień: {liczbyTrafione.Count} \nWygrałeś 120 zł.";
                            wygrana += 120; koszt += 3;
                            ZapiszLog("INFO", $"Wygrana w lotto: 120 zł (trafiono {liczbyTrafione.Count} liczby)");
                            break;
                        case 5:
                            tb_lotto_wynik.Text += $"\nIlość trafień: {liczbyTrafione.Count} \nWygrałeś 600 zł.";
                            wygrana += 600; koszt += 3;
                            ZapiszLog("INFO", $"Wygrana w lotto: 600 zł (trafiono {liczbyTrafione.Count} liczby)");
                            break;
                        default:
                            tb_lotto_wynik.Text += $"\nIlość trafień: {liczbyTrafione.Count} \nWygrałeś 0 zł.";
                            koszt += 3;
                            break;
                    }

                    tb_koszt.Text = $"{koszt} zł";
                    tb_wygrana.Text = $"{wygrana} zł";
                }
            }
            catch (Exception ex)
            {
                string errorMessage = $"Błąd w grze Lotto: {ex.Message}";
                MessageBox.Show(errorMessage);
                ZapiszLog("ERROR", errorMessage);
            }
        }

        private void PokazLogi_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sciezkaLogu = "log.txt";

                if (!File.Exists(sciezkaLogu))
                {
                    File.WriteAllText(sciezkaLogu, "Plik log.txt został utworzony.\n");
                }

                Process.Start(new ProcessStartInfo
                {
                    FileName = sciezkaLogu,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Nie można otworzyć logów: {ex.Message}");
            }
        }
    }
}
