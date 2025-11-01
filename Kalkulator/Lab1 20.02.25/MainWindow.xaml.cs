using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Lab1_20._02._25
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnZad11_Click(object sender, RoutedEventArgs e)
        {
            tbZad11Result.Text = $"Wprowadzone teksty:\n1. {tbZad11Text1.Text}\n2. {tbZad11Text2.Text}";
        }

        private void BtnZad12_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(tbZad12Num1.Text, out int num1) && int.TryParse(tbZad12Num2.Text, out int num2))
            {
                tbZad12Result.Text = $"Wynik mnożenia: {num1} * {num2} = {num1 * num2}";
            }
            else
            {
                tbZad12Result.Text = "Proszę wprowadzić poprawne liczby całkowite!";
            }
        }

        private void BtnZad13_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(tbZad13Num.Text, out double num))
            {
                double square = Math.Pow(num, 2);
                string sqrtText = num >= 0 ? Math.Sqrt(num).ToString() : "NIE ISTNIEJE";
                tbZad13Result.Text = $"Liczba: {num}\nKwadrat: {square}\nPierwiastek: {sqrtText}";
            }
            else
            {
                tbZad13Result.Text = "Proszę wprowadzić poprawną liczbę!";
            }
        }

        private void BtnZad14_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(tbZad14Value.Text, out int value))
            {
                if (rbZad14HoursToMinutes.IsChecked == true)
                {
                    tbZad14Result.Text = $"{value} godzin = {value * 60} minut";
                }
                else
                {
                    int hours = value / 60;
                    int minutes = value % 60;
                    tbZad14Result.Text = $"{value} minut = {hours} godzin i {minutes} minut";
                }
            }
            else
            {
                tbZad14Result.Text = "Proszę wprowadzić poprawną wartość!";
            }
        }

        private void BtnZad15_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(tbZad15Balance.Text, out double balance))
            {
                double fee = balance * 0.1;
                tbZad15Result.Text = $"Opłata za prowadzenie konta (10%): {fee:F2} zł";
            }
            else
            {
                tbZad15Result.Text = "Proszę wprowadzić poprawną wartość salda!";
            }
        }

        private void BtnZad21_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(tbZad21Num.Text, out int num))
            {
                if (num > 50)
                    tbZad21Result.Text = $"{num} jest większe niż 50";
                else if (num < 50)
                    tbZad21Result.Text = $"{num} jest mniejsze niż 50";
                else
                    tbZad21Result.Text = $"{num} jest równe 50";
            }
            else
            {
                tbZad21Result.Text = "Proszę wprowadzić poprawną liczbę!";
            }
        }

        private void BtnZad22_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(tbZad22Num.Text, out int num))
            {
                tbZad22Result.Text = num % 2 == 0 ? $"{num} jest liczbą parzystą" : $"{num} jest liczbą nieparzystą";
            }
            else
            {
                tbZad22Result.Text = "Proszę wprowadzić poprawną liczbę!";
            }
        }

        private void BtnZad23_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(tbZad23Weight.Text, out double weight) &&
                double.TryParse(tbZad23Height.Text, out double height) && height > 0)
            {
                double bmi = weight / ((height/100) * (height/100));
                string category;
                Brush color;

                if (bmi < 18.5)
                {
                    category = "niedowaga";
                    color = Brushes.LightBlue;
                }
                else if (bmi < 25)
                {
                    category = "waga prawidłowa";
                    color = Brushes.Green;
                }
                else if (bmi < 30)
                {
                    category = "nadwaga";
                    color = Brushes.Orange;
                }
                else
                {
                    category = "otyłość";
                    color = Brushes.Red;
                }

                tbZad23Result.Text = $"BMI: {bmi:F2} - {category}";
                tbZad23Result.Background = color;
            }
            else
            {
                tbZad23Result.Text = "Proszę wprowadzić poprawne wartości!";
                tbZad23Result.Background = Brushes.Transparent;
            }
        }

        private void BtnZad24_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(tbZad24Day.Text, out int day) && day >= 1 && day <= 7)
            {
                string[] days = { "Poniedziałek", "Wtorek", "Środa", "Czwartek", "Piątek", "Sobota", "Niedziela" };
                tbZad24Result.Text = days[day - 1];
            }
            else
            {
                tbZad24Result.Text = "Proszę wprowadzić liczbę od 1 do 7!";
            }
        }

        private void BtnZad25_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(tbZad25Score.Text, out int score) && score >= 0 && score <= 100)
            {
                string grade;
                if (score >= 90) grade = "5";
                else if (score >= 80) grade = "4+";
                else if (score >= 70) grade = "4";
                else if (score >= 60) grade = "3+";
                else if (score >= 50) grade = "3";
                else grade = "2";

                tbZad25Result.Text = $"Wynik: {score} - ocena: {grade}";
            }
            else
            {
                tbZad25Result.Text = "Proszę wprowadzić wynik w zakresie 0-100!";
            }
        }

        private void BtnZad26_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(tbZad26Age.Text, out int age))
            {
                tbZad26Result.Text = age >= 18 ? "Osoba dorosła" : "Osoba niepełnoletnia";
            }
            else
            {
                tbZad26Result.Text = "Proszę wprowadzić poprawny wiek!";
            }
        }

        private void BtnZad27_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(tbZad27DogAge.Text, out double dogAge))
            {
                double humanAge;
                if (dogAge <= 2)
                    humanAge = dogAge * 10.5;
                else
                    humanAge = 21 + (dogAge - 2) * 4;

                tbZad27Result.Text = $"{dogAge} lat psa = {humanAge} lat człowieka";
            }
            else
            {
                tbZad27Result.Text = "Proszę wprowadzić poprawny wiek!";
            }
        }

        private void BtnZad28_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(tbZad28Temp.Text, out double temp))
            {
                if (rbZad28CtoF.IsChecked == true)
                {
                    double f = temp * 9 / 5 + 32;
                    tbZad28Result.Text = $"{temp}°C = {f:F1}°F";
                }
                else
                {
                    double c = (temp - 32) * 5 / 9;
                    tbZad28Result.Text = $"{temp}°F = {c:F1}°C";
                }
            }
            else
            {
                tbZad28Result.Text = "Proszę wprowadzić poprawną temperaturę!";
            }
        }

        private void BtnZad29_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(tbZad29Month.Text, out int month) && month >= 1 && month <= 12)
            {
                string season;
                if (month == 12 || month <= 2) season = "Zima";
                else if (month <= 5) season = "Wiosna";
                else if (month <= 8) season = "Lato";
                else season = "Jesień";

                tbZad29Result.Text = $"Miesiąc {month} to pora roku: {season}";
            }
            else
            {
                tbZad29Result.Text = "Proszę wprowadzić miesiąc (1-12)!";
            }
        }

        private void BtnZad210_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(tbZad210Month.Text, out int month) && month >= 1 && month <= 12 &&
                int.TryParse(tbZad210Year.Text, out int year))
            {
                int days = DateTime.DaysInMonth(year, month);
                tbZad210Result.Text = $"Miesiąc {month}/{year} ma {days} dni";
            }
            else
            {
                tbZad210Result.Text = "Proszę wprowadzić poprawne dane!";
            }
        }

        private void BtnZad211_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(tbZad211A.Text, out double a) &&
                double.TryParse(tbZad211B.Text, out double b) &&
                double.TryParse(tbZad211C.Text, out double c))
            {
                if (a == 0)
                {
                    tbZad211Result.Text = "To nie jest równanie kwadratowe (a = 0)!";
                    return;
                }

                double delta = b * b - 4 * a * c;
                string result;

                if (delta > 0)
                {
                    double x1 = (-b - Math.Sqrt(delta)) / (2 * a);
                    double x2 = (-b + Math.Sqrt(delta)) / (2 * a);
                    result = $"Dwa pierwiastki rzeczywiste:\nx₁ = {x1:F2}\nx₂ = {x2:F2}";
                }
                else if (delta == 0)
                {
                    double x = -b / (2 * a);
                    result = $"Jeden pierwiastek podwójny:\nx = {x:F2}";
                }
                else
                {
                    result = "Brak pierwiastków rzeczywistych";
                }

                tbZad211Result.Text = $"Równanie: {a}x² + {b}x + {c} = 0\n" +
                                     $"Delta = {delta:F2}\n" +
                                     $"Rozwiązanie: {result}";
            }
            else
            {
                tbZad211Result.Text = "Proszę wprowadzić poprawne współczynniki!";
            }
        }

        private void BtnZad212_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(tbZad212Income.Text, out double income))
            {
                double tax;
                if (income <= 120000)
                    tax = income * 0.12;
                else
                    tax = 120000 * 0.12 + (income - 120000) * 0.32;

                tbZad212Result.Text = $"Podatek od dochodu {income:F2} zł wynosi: {tax:F2} zł";
            }
            else
            {
                tbZad212Result.Text = "Proszę wprowadzić poprawny dochód!";
            }
        }

        private void BtnZad213_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(tbZad213Start.Text, out int start) &&
                int.TryParse(tbZad213End.Text, out int end))
            {
                string numbers = "";
                int step = start <= end ? 1 : -1;

                for (int i = start; i != end + step; i += step)
                {
                    numbers += i + " ";
                }

                tbZad213Result.Text = $"Liczby od {start} do {end}:\n{numbers}";
            }
            else
            {
                tbZad213Result.Text = "Proszę wprowadzić poprawne liczby!";
            }
        }
    }
}