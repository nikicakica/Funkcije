using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CrtanjeFunkcije
{
    public abstract class Funkcija
    {
        public abstract double Vrednost(double x);
        public abstract double this[double x] { get; }
        public void Nacrtaj(Graphics g, PointF Oxy, double k, double a, double b)
        {
            Pen olovka = new Pen(Color.Black, 2);
            for (double x = a+0.001; x <= b; x+=0.001)
            {
                g.DrawLine(olovka, (float)(Oxy.X + (x - 0.001) * k), (float)(Oxy.Y - this[x - 0.001] * k), (float)(Oxy.X + x * k), (float)(Oxy.Y - this[x] * k));
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

    public class Sinusna : Funkcija
    {
        Funkcija F;
        public Sinusna(Funkcija f)
        {
            F = f;
        }

        public override double this[double x]
        {
            get { return Math.Sin(F[x]); }
        }

        public override double Vrednost(double x)
        {
            return Math.Sin(F[x]);
        }

        public override string ToString()
        {
            return "sin("+F.ToString()+")";
        }
    }

}
