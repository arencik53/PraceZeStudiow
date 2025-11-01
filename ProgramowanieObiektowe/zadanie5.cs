public class Macierz<T>
{
    private readonly T[,] dane;

    public Macierz(int wiersze, int kolumny)
    {
        if (wiersze <= 0 || kolumny <= 0)
        {
            throw new ArgumentException("Wymiary macierzy muszą być dodatnie.");
        }

        dane = new T[wiersze, kolumny];
    }

    public T this[int wiersz, int kolumna]
    {
        get
        {
            if (wiersz < 0 || wiersz >= Wiersze || kolumna < 0 || kolumna >= Kolumny)
            {
                throw new IndexOutOfRangeException("Indeksy wykraczają poza zakres macierzy.");
            }

            return dane[wiersz, kolumna];
        }
        set
        {
            if (wiersz < 0 || wiersz >= Wiersze || kolumna < 0 || kolumna >= Kolumny)
            {
                throw new IndexOutOfRangeException("Indeksy wykraczają poza zakres macierzy.");
            }

            dane[wiersz, kolumna] = value;
        }
    }

    public int Wiersze => dane.GetLength(0);
    public int Kolumny => dane.GetLength(1);

    public override bool Equals(object obj) => obj is Macierz<T> matrix && matrix.Wiersze == Wiersze && matrix.Kolumny == Kolumny && Array.Equals(dane, matrix.dane);

    public override int GetHashCode() => HashCode.Combine(Wiersze, Kolumny, Array.GetHashCode(dane));

    public static bool operator ==(Macierz<T> v1, Macierz<T> v2) => ReferenceEquals(v1, v2) || (v1?.Equals(v2) ?? false);

    public static bool operator !=(Macierz<T> v1, Macierz<T> v2) => !(v1 == v2);
}
