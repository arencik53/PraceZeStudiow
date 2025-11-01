public class Wektor
{
    private readonly double[] współrzędne;

    public Wektor(byte wymiar)
    {
        if (wymiar <= 0)
        {
            throw new ArgumentException("Wymiary wektora muszą być dodatnie.");
        }

        współrzędne = new double[wymiar];
    }

    public Wektor(params double[] współrzędne)
    {
        if (współrzędne == null || współrzędne.Length == 0)
        {
            throw new ArgumentException("Tablica współrzędnych nie może być pusta.");
        }

        this.współrzędne = new double[współrzędne.Length];
        Array.Copy(współrzędne, this.współrzędne, współrzędne.Length);
    }

    public double Długość
    {
        get { return Math.Sqrt(IloczynSkalarny(this, this)); }
    }

    public byte Wymiar
    {
        get { return (byte)współrzędne.Length; }
    }

    public double this[byte indeks]
    {
        get
        {
            if (indeks < 0 || indeks >= Wymiar)
            {
                throw new IndexOutOfRangeException("Indeks wykracza poza zakres tablicy współrzędnych.");
            }

            return współrzędne[indeks];
        }
        set
        {
            if (indeks < 0 || indeks >= Wymiar)
            {
                throw new IndexOutOfRangeException("Indeks wykracza poza zakres tablicy współrzędnych.");
            }

            współrzędne[indeks] = value;
        }
    }

    public static double? IloczynSkalarny(Wektor v1, Wektor v2)
    {
        if (v1.Wymiar != v2.Wymiar)
        {
            return double.NaN;
        }

        double iloczyn = 0;
        for (int i = 0; i < v1.Wymiar; i++)
        {
            iloczyn += v1[i] * v2[i];
        }

        return iloczyn;
    }

    public static Wektor Suma(params Wektor[] wektory)
    {
        if (wektory.Length == 0)
        {
            throw new ArgumentException("Tablica wektorów nie może być pusta.");
        }

        byte wymiar = wektory[0].Wymiar;
        for (int i = 1; i < wektory.Length; i++)
        {
            if (wektory[i].Wymiar != wymiar)
            {
                throw new ArgumentException("Wszystkie wektory muszą mieć ten sam wymiar.");
            }
        }

        double[] sumaWspółrzędnych = new double[wymiar];
        for (int i = 0; i < wymiar; i++)
        {
            foreach (Wektor wektor in wektory)
            {
                sumaWspółrzędnych[i] += wektor[i];
            }
        }

        return new Wektor(sumaWspółrzędnych);
    }

    public static Wektor operator +(Wektor v1, Wektor v2)
    {
        return Suma(v1, v2);
    }

    public static Wektor operator -(Wektor v1, Wektor v2)
    {
        double[] różnicaWspółrzędnych = new double[v1.Wymiar];
        for (int i = 0; i < v1.Wymiar; i++)
        {
            różnicaWspółrzędnych[i] = v1[i] - v2[i];
        }

        return new Wektor(różnicaWspółrzędnych);
    }

    public static Wektor operator *(Wektor v, double skalar)
    }
        double[] pomnożoneWspółrzędne = new double[v.Wymiar];
        for (int i = 0; i < v.Wymiar; i++)
        {
            pomnożoneWspółrzędne[i] = v[i] * skalar;
        }

        return
