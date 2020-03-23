using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrtanjeFunkcije
{
    class Interval
    {
        
        private double leva_gr;
        private double desna_gr;

        public Interval ()
        {
            leva_gr = -1000000;
            desna_gr = 1000000;
        }
        public Interval(double lg,double dg)
        {
            leva_gr = lg;
            desna_gr = dg;
        }
        public Interval (Interval m)
        {
            leva_gr = m.leva_gr;
            desna_gr = m.desna_gr;
        } 
        
        public static bool operator ^(Interval a, Interval b) //vraca da li ima preklapanja izmedju ova 2 intervala
        {
            if (b.leva_gr > a.desna_gr) return false;
            else if (a.leva_gr > b.desna_gr) return false;
            return true;
        }
        public static Interval operator +(Interval a, Interval b)// ovo vraca uniju
        {
            double levagr = Math.Min(a.leva_gr, b.leva_gr);
            double desnagr = Math.Max(a.desna_gr, b.desna_gr);
            return new Interval(levagr, desnagr);
        }
        public static Interval operator *(Interval a, Interval b) // ovo vraca presek
        {
            if ((a ^ b) == false) return null;
            double levagr = Math.Max(a.leva_gr, b.leva_gr);
            double desnagr = Math.Min(a.desna_gr, b.desna_gr);
            return new Interval(levagr, desnagr);
        }
        public override string ToString()
        {
            return "(" + Convert.ToString(leva_gr) + "," + Convert.ToString(desna_gr) + ")";
        }

        public bool Pripada(double x)
        {
            if(x>)
        }
    } 
    
     
        
}

