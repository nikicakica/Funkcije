using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


namespace FunkcijeAplikacija
{
    public abstract class Funkcija
    {
        public abstract double Vrednost(double x);
       
        public void Nacrtaj(Graphics g, PointF Oxy, double k, double a, double b)
        {
            Pen olovka = new Pen(Color.Black, 2);
            for (double x = a; x < b; x+=0.001)
            {
                g.DrawLine(olovka, (float)(Oxy.X + x * k), (float)(Oxy.Y - Vrednost(x) * k),
                    (float)(Oxy.X + (x+0.001) * k), (float)(Oxy.Y - Vrednost(x+0.001) * k));
            }
        }

        public static Funkcija operator +(Funkcija f, Funkcija g)
        {
            return new SlozenaFunkcija(f, g, '+');
        }
        public static Funkcija operator -(Funkcija f, Funkcija g)
        {
            return new SlozenaFunkcija(f, g, '-');
        }
        public static Funkcija operator *(Funkcija f, Funkcija g)
        {
            return new SlozenaFunkcija(f, g, '*');
        }
        public static Funkcija operator /(Funkcija f, Funkcija g)
        {
            return new SlozenaFunkcija(f, g, '/');
        }
        //public static Funkcija operator ~(Funkcija f, Funkcija g)
        //{
        //    return new SlozenaFunkcija(f, g, '°');
        //}
        public static Funkcija operator ^(Funkcija f, Funkcija g)
        {
            return new SlozenaFunkcija(f, g, '^');
        }
        
    }
    public class KonstantnaFunkcija:Funkcija
    {
        double c;
        public KonstantnaFunkcija()
        {
            c=0;
        }
        public KonstantnaFunkcija(double x)
        {
            c=x;
        }

        public override double Vrednost(double x)
        {
            return c;
        }
        public override string  ToString()
        {
            return Convert.ToString(c);
        }


    }
    public class PromenjivaFunkcija:Funkcija
    {
        public PromenjivaFunkcija()
        {
        }
        public override double  Vrednost(double x)
        {
             return x;
        }
        public override string  ToString()
        {
            return "x";
        }
    }


   
    public class SlozenaFunkcija:Funkcija
    {
        Funkcija f1,f2;
        char znak;
        public SlozenaFunkcija(Funkcija a,Funkcija b,char x)
        {
            f1=a;
            f2=b;
            znak=x;
        }
        public override double  Vrednost(double x)
        {
            if(znak=='+')
                return f1.Vrednost(x)+f2.Vrednost(x);
            if(znak=='-')
                return f1.Vrednost(x)-f2.Vrednost(x);
            if(znak=='*')
                return f1.Vrednost(x)*f2.Vrednost(x);
            if(znak=='/')
                return f1.Vrednost(x)/f2.Vrednost(x);
            return 0;
        }
        public override string  ToString()
        {
            return '('+f1.ToString()+')'+znak+'('+f2.ToString()+')';
        }
    }
    public class SinusnaFunkcija:Funkcija
    {
        Funkcija f;
        public SinusnaFunkcija(Funkcija f)
        {
            this.f = f;
        }
        
        public override double Vrednost(double x)
        {
            return Math.Sin(f.Vrednost(x));
        }

        public override string ToString()
        {
            return "sin("+f.ToString()+")";
        }
    }
    public class KosinusnaFunkcija:Funkcija
    {
        Funkcija f;
        public KosinusnaFunkcija(Funkcija f)
        {
            this.f = f;
        }
        
        public override double Vrednost(double x)
        {
            return Math.Cos(f.Vrednost(x));
        }
        public override string ToString()
        {
            return "cos(" + f.ToString() + ")";
        }
        
    }
    /* public class TangensFunkcija:Funkcija
     {
         Funkcija f;

         public TangensFunkcija(Funkcija f)
         {
             this.f = f;
         }
        public override double Vrednost(Funkcija f, double x)
        {
            return Math.Tan(f.Vrednost(x));
        }
        public override string ToString()
        {
            return "tan(" + f.ToString() + ")";
        }
    }*/

    // public class SinusnaFunkcija:Funkcija
    //{
    //    TangensFunkcija f;
    //   public override double vrednost(double x)
    //   {
    //       return 1/f.Vrednost(x);
    //   }
    //      public override double vrednost(double x,Funkcija t)
    //   {
    //       return 1/f.Vrednost(t.Vrednost(x));
    //   }
    // }

}