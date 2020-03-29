using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;



namespace CrtanjeFunkcije
{
    public abstract class Funkcija
    {
        SkupIntervala domen = new SkupIntervala();
        public abstract double Vrednost(double x);
        public abstract double this[double x] { get; }
        public void Nacrtaj(Graphics g, PointF Oxy, double k, double a, double b, float MaxY)
        {
            Pen olovka = new Pen(Color.Black, 2);
            for (double x = a+0.001; x <= b; x+=0.001)
            {
                float x1 = (float)(Oxy.X + (x - 0.001) * k);
                float y1 = (float)(Oxy.Y - this[x - 0.001] * k);
                float x2 = (float)(Oxy.X + x * k);
                float y2 = (float)(Oxy.Y - this[x] * k);

                if (y2 < 0)
                    y2 = -1;
                if (y2 > MaxY)
                    y2 = MaxY+ 1;
                if (y1 < 0)
                    y1 = -1;
                if (y1 > MaxY)
                    y1 = MaxY+ 1;

                g.DrawLine(olovka, x1, y1, x2, y2);
            }
        }

        public static Funkcija operator +(Funkcija F1, Funkcija F2)
        {
            return new SlozenaFunkcija(F1, F2, '+');
        }
        public static Funkcija operator -(Funkcija F1, Funkcija F2)
        {
            return new SlozenaFunkcija(F1, F2, '-');
        }
        public static Funkcija operator *(Funkcija F1, Funkcija F2)
        {
            return new SlozenaFunkcija(F1, F2, '*');
        }
        public static Funkcija operator /(Funkcija F1, Funkcija F2)
        {
            return new SlozenaFunkcija(F1, F2, '/');
        }
        public static Funkcija operator ^(Funkcija F1, Funkcija F2)
        {
            return new SlozenaFunkcija(F1, F2, '^');
        }
        public static Funkcija operator -(Funkcija F)
        {
            return new Konstanta(0) - F;
        }
    }

    public class Konstanta : Funkcija
    {
        double c;
        public Konstanta(double c)
        {
            this.c = c;
        }

        public override double this[double x]
        {
            get { return c; }
        }
        public override double Vrednost(double x)
        {
            return c;
        }

        public override string ToString()
        {
            return c.ToString("0.00");
        }
    }

    public class Promenljiva : Funkcija
    {
        public override double this[double x]
        {
            get { return x; }
        }
        public override double Vrednost(double x)
        {
            return x;
        }

        public override string ToString()
        {
            return "X";
        }
    }

    public class SlozenaFunkcija : Funkcija
    {

        Funkcija F1, F2;
        char op;

        public SlozenaFunkcija(Funkcija f, Funkcija g, char o)
        {
            F1 = f;
            F2 = g;
            op = o;
        }

        public override double this[double x]
        {
            get
            {
                switch (op)
                {
                    case '+': return F1[x] + F2[x];
                    case '*': return F1[x] * F2[x];
                    case '/': return F1[x] / F2[x];
                    case '-': return F1[x] - F2[x];
                    case '^': return Math.Pow(F1[x], F2[x]);
                }
                return 0;
            }
        }
        public override double Vrednost(double x)
        {
            switch (op)
            {
                case '+': return F1[x] + F2[x];
                case '*': return F1[x] * F2[x];
                case '/': return F1[x] / F2[x];
                case '-': return F1[x] - F2[x];
                case '^': return Math.Pow(F1[x], F2[x]);
            }
            return 0;
        }

        public override string ToString()
        {
            return "("+F1.ToString()+op+F2.ToString()+")";
        }
    }

    public class SpecFunkcija : Funkcija
    {
        Funkcija F;
        string opis; //moze biti log,ln,sin,cos,arcsin,arccos,sinh,cosh,tg,arctg
        public SpecFunkcija(Funkcija f, string opis)
        {
            F = f;
            this.opis = opis;
        }

        public override double this[double x]
        {
            get {
                switch (opis)
                {
                    case "log": return Math.Log10(F[x]);
                    case "ln": return Math.Log(F[x]);
                    case "sin": return Math.Sin(F[x]);
                    case "cos": return Math.Cos(F[x]);
                    case "arcsin": return Math.Asin(F[x]);
                    case "arccos": return Math.Acos(F[x]);
                    case "sinh": return Math.Sinh(F[x]);
                    case "cosh": return Math.Cosh(F[x]);
                    case "tg": return Math.Tan(F[x]);
                    case "arctg": return Math.Atan(F[x]);
                    default:
                        return 0;
                }

            }
        }

        public override double Vrednost(double x)
        {
            switch (opis)
            {
                case "log": return Math.Log10(F[x]);
                case "ln": return Math.Log(F[x]);
                case "sin": return Math.Sin(F[x]);
                case "cos": return Math.Cos(F[x]);
                case "arcsin": return Math.Asin(F[x]);
                case "arccos": return Math.Acos(F[x]);
                case "sinh": return Math.Sinh(F[x]);
                case "cosh": return Math.Cosh(F[x]);
                case "tg": return Math.Tan(F[x]);
                case "arctg": return Math.Atan(F[x]);
                default:
                    return 0;
            }
        }

        public override string ToString()
        {
            switch (opis)
            {
                case "log": return "log(" + F.ToString() + ")";
                case "ln": return "ln(" + F.ToString() + ")";
                case "sin": return "sin(" + F.ToString() + ")";
                case "cos": return "cos(" + F.ToString() + ")";
                case "arcsin": return "arcsin(" + F.ToString() + ")";
                case "arccos": return "arccos(" + F.ToString() + ")";
                case "sinh": return "sinh(" + F.ToString() + ")";
                case "cosh": return "cosh(" + F.ToString() + ")";
                case "tg": return "tg(" + F.ToString() + ")";
                case "arctg": return "arctg(" + F.ToString() + ")";
                default:
                    return "null";
            }
            
        }
    }

}
