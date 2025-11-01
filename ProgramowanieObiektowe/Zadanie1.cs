using System;

public class Osoba
{
    private string imię;
    private string nazwisko;

    public Osoba(string imięNazwisko)
    {
        ImięNazwisko = imięNazwisko;
    }           

    public string ImięNazwisko
    {
        get => $"{imię} {nazwisko}";
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Musisz wpisać imię i nazwisko! ");

            var parts = value.Split(' ');
            if (parts.Length == 1)
            {
                imię = parts[0];
                nazwisko = string.Empty;
            }
            else
            {
                imię = parts[0];
                nazwisko = parts[parts.Length - 1];
            }
        }
    }

    public DateTime? DataUrodzenia { get; set; }
    public DateTime? DataŚmierci { get; set; }

    public TimeSpan? Wiek
    {
        get
        {
            if (DataUrodzenia == null)
                return null;

            var endDate = DataŚmierci ?? DateTime.Now;
            return endDate - DataUrodzenia.Value;
        }
    }
}