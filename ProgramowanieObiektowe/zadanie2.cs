public class Prostokąt
{
    private static readonly Dictionary<char, double> wysokościArkusza = new Dictionary<char, double>()
    {
        ['A'] = 1189,
        ['B'] = 1414,
        ['C'] = 1297
    };

    private double bokA;
    private double bokB;

    public Prostokąt(double bokA, double bokB)
    {
        if (bokA <= 0 || bokB <= 0)
        {
            throw new ArgumentException("Boki prostokąta muszą być dodatnie.");
        }

        this.bokA = bokA;
        this.bokB = bokB;
    }

    public double BokA
    {
        get { return bokA; }
        set { bokA = value; }
    }

    public double BokB
    {
        get { return bokB; }
        set { bokB = value; }
    }

    public static Prostokąt ArkuszPapieru(string format)
    {
        if (format.Length != 2 || !char.IsLetter(format[0]))
        {
            throw new ArgumentException("Format musi składać się z 2 znaków, z czego pierwszy to litera A, B lub C.");
        }

        char seria = format[0];
        int indeks = int.Parse(format[1]);

        if (!wysokościArkusza.ContainsKey(seria))
        {
            throw new ArgumentException($"Nieznana seria arkusza: {seria}.");
        }

        double bazowaWysokość = wysokościArkusza[seria];
        double wysokość = bazowaWysokość / Math.Pow(2, indeks);
        double szerokość = wysokość / Math.Sqrt(2);

        return new Prostokąt(szerokość, wysokość);
    }
}
