// See https://aka.ms/new-console-template for more information

class Fraction
{
    public int Numerator { get; set; }
    private int _denominator;
    public int Denominator
    {
        get { return _denominator; }
        set { 
            if(value!= 0) _denominator = value; 
            if (value < 0) { Numerator *= -1; Denominator *= -1; } 
        }
    }

    public Fraction(int numerator, int denominator)
    {
        Denominator = 1;
        Numerator = numerator;
        Denominator = denominator;
    }


    public void Simplfy()
    {
        for (int i = 2; i <= Denominator; i++)
            while(Denominator % i == 0 
                && Numerator % i == 0)
            {
                Numerator /= i;
                Denominator /= i;
            }
    }

    public void Multiply(Fraction other){
        Denominator *= other.Denominator;
        Numerator *= other.Numerator;

        Simplfy();
    }

    public void Divide(Fraction other)
    {
        Denominator *= other.Numerator;
        Numerator *= other.Denominator;

        Simplfy();
    }

    public void Add(Fraction other){
        Numerator *=  other.Denominator;
        Numerator += Denominator * other.Numerator;

        Denominator *= other.Denominator;
        Simplfy();
    }

    public void Minus(Fraction other)
    {
        Numerator *= other.Denominator;
        Numerator -= Denominator * other.Numerator;

        Denominator *= other.Denominator;
        Simplfy();
    }


    public override string ToString() { return $"{Numerator}/{Denominator}"; }

}


struct Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override string ToString() { return $"X = {X}\nY = {Y}"; }
}


class Program
{
    static void Main(string[] args)
    {
        #region Fraction

        Fraction f1 = new Fraction(2, 4);
        Fraction f2 = new Fraction(4, 6);

        Console.Write($"{f1} * {f2} = ");
        f1.Multiply(f2);
        Console.WriteLine(f1);

        Console.Write($"{f1} + {f2} = ");
        f1.Add(f2);
        Console.WriteLine(f1);

        Console.Write($"{f1} - {f2} = ");
        f1.Minus(f2);
        Console.WriteLine(f1);

        Console.Write($"{f1} / {f2} = ");
        f1.Divide(f2);
        Console.WriteLine(f1);

        Fraction f3 = new Fraction(1, 0);
        Console.WriteLine($"\n\n{f3}");
        f3.Denominator = -6;
        Console.WriteLine(f3);

        #endregion

        #region Point
        Point point = new Point(5,3);
        Console.WriteLine($"\n\n{point}");
        #endregion
    }
}