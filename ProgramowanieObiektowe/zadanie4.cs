using System.Collections.Generic;

public abstract class Produkt
{
    public string Nazwa { get; set; }
    public decimal CenaNetto { get; set; }
    public string KategoriaVAT { get; set; }

    private static readonly HashSet<string> KategorieVAT = new HashSet<string>()
    {
        "A", "B", "C", "D"
    };

    public Produkt(string nazwa, decimal cenaNetto, string kategoriaVAT)
    {
        Nazwa = nazwa;

        if (cenaNetto < 0)
        {
            throw new ArgumentException("Cena netto nie może być ujemna.");
        }

        CenaNetto = cenaNetto;

        if (!KategorieVAT.Contains(kategoriaVAT))
        {
            throw new ArgumentException(<span class="math-inline">"Nieznana kategoria VAT\: \{kategoriaVAT\}\."\);
\}
KategoriaVAT \= kategoriaVAT;
\}
public abstract decimal CenaBrutto \{ get; \}
public abstract string KrajPochodzenia \{ get; \}
\}
public interface IProduktSpozywczy \: IProdukt
\{
decimal Kalorie \{ get; \}
HashSet<string\> Alergeny \{ get; \}
\}
public abstract class ProduktSpozywczy \: Produkt, IProduktSpożywczy
\{
private static readonly HashSet<string\> KategorieVATProduktSpozywczy \= new HashSet<string\>\(\)
\{
"A", "B", "C"
\};
private static readonly HashSet<string\> Alergeny \= new HashSet<string\>\(\)
\{
"Mleko", "Jaja", "Orzechy", "Gluten"
\};
public decimal Kalorie \{ get; set; \}
public HashSet<string\> Alergeny \{ get; set; \}
public ProduktSpozywczy\(string nazwa, decimal cenaNetto, string kategoriaVAT, decimal kalorie\)
\: base\(nazwa, cenaNetto, kategoriaVAT\)
\{
if \(kalorie < 0\)
\{
throw new ArgumentException\("Kalorie nie mogą być ujemne\."\);
\}
Kalorie \= kalorie;
if \(\!KategorieVATProduktSpozywczy\.Contains\(kategoriaVAT\)\)
\{
throw new ArgumentException\(</span>"Nieznana kategoria VAT dla produktu spożywczego: {kategoriaVAT}.");
        }
    }

    public abstract string KrajPochodzenia { get; }
}

public class ProduktSpozywczyNaWage : ProduktSpozywczy
{
    public decimal Waga { get; set; }

    public ProduktSpozywczyNaWage(string nazwa, decimal cenaNetto, string kategoriaVAT, decimal kalorie, decimal waga)
        : base(nazwa, cenaNetto, kategoriaVAT, kalorie)
    {
        if (waga < 0)
        {
            throw new ArgumentException("Waga nie może być ujemna.");
        }

        Waga = waga;
    }

    public override decimal CenaBrutto => CenaNetto * (1 + PobierzStawkęVAT());

    public override string KrajPochodzenia => "Polska";

    private decimal PobierzStawkęVAT()
    {
        switch (KategoriaVAT)
        {
            case "A":
                return 0.23m;
            case "B":
                return 0.08m;
            case "C":
                return 0.05m;
            default:
                return 0m;
        }
    }
}

public class ProduktSpozywczyPaczka : ProduktSpozywczy
{
    public decimal Waga { get; set; }

    public ProduktSpozywczyPaczka(string nazwa, decimal cenaNetto, string kategoriaVAT, decimal kalorie, decimal waga)
        : base(nazwa, cenaNetto, kategoriaVAT, kalorie)
    {
        if (waga < 0)
        {
            throw new ArgumentException("Waga nie może być ujemna.");
        }

        Waga = waga;
    }

    public override decimal CenaBrutto => CenaNetto * (1 + PobierzStawkęVAT());

    public override string KrajPochodzenia => "Polska";

    private
