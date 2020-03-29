using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrtanjeFunkcije
{
    public class Interval
    {
        private int otvorenLevo;
        private int otvorenDesno;

        private double leva_gr;
        private double desna_gr;

        public Interval()
        {
            otvorenLevo = 1;
            otvorenDesno = 1;
            leva_gr = -1000;
            desna_gr = 1000;
        }
        public Interval(double lg, double dg, int ol, int od)
        {
            otvorenLevo = ol;
            otvorenDesno = od;
            leva_gr = lg;
            desna_gr = dg;
        }
        public Interval(Interval m)
        {
            otvorenDesno = m.otvorenDesno;
            otvorenLevo = m.otvorenLevo;
            leva_gr = m.leva_gr;
            desna_gr = m.desna_gr;
        }

        public static bool operator ^(Interval a, Interval b) //vraca da li ima preklapanja izmedju ova 2 intervala
        {

            if (b.leva_gr > a.desna_gr) return false;
            if (a.leva_gr > b.desna_gr) return false;
            if (a.leva_gr == b.desna_gr && (a.otvorenLevo == 1 || b.otvorenDesno == 1)) return false;
            if (b.leva_gr == a.desna_gr && (b.otvorenLevo == 1 || a.otvorenDesno == 1)) return false;
            return true;
        }
        public static Interval operator +(Interval a, Interval b)// ovo vraca uniju
        {
            int ol, od;
            double levagr = Math.Min(a.leva_gr, b.leva_gr);
            double desnagr = Math.Max(a.desna_gr, b.desna_gr);
            if (a.leva_gr == b.leva_gr)
                ol = Math.Min(a.otvorenLevo, b.otvorenLevo);
            else if (levagr == a.leva_gr) ol = a.otvorenLevo;
            else ol = b.otvorenLevo;
            if (a.desna_gr == b.desna_gr)
                od = Math.Min(a.otvorenDesno, b.otvorenDesno);
            else if (desnagr == a.desna_gr) od = a.otvorenDesno;
            else od = b.otvorenDesno;
            return new Interval(levagr, desnagr, ol, od);
        }
        public static Interval operator *(Interval a, Interval b) // ovo vraca presek
        {
            int ol, od;
            if ((a ^ b) == false) return null;
            double levagr = Math.Max(a.leva_gr, b.leva_gr);
            double desnagr = Math.Min(a.desna_gr, b.desna_gr);
            if (a.leva_gr == b.leva_gr)
                ol = Math.Max(a.otvorenLevo, b.otvorenLevo);
            else if (levagr == a.leva_gr) ol = a.otvorenLevo;
            else ol = b.otvorenLevo;
            if (a.desna_gr == b.desna_gr)
                od = Math.Max(a.otvorenDesno, b.otvorenDesno);
            else if (desnagr == a.desna_gr) od = a.otvorenDesno;
            else od = b.otvorenDesno;
            return new Interval(levagr, desnagr, ol, od);
        }
        public override string ToString()
        {
            string s1 = "(", s2 = ")";
            if (otvorenLevo == 0 && otvorenDesno == 1)
            {
                s1 = "[";
                s2 = ")";
            }
            if (otvorenLevo == 1 && otvorenDesno == 0)
            {
                s1 = "(";
                s2 = "]";
            }
            if (otvorenLevo == 0 && otvorenDesno == 0)
            {
                s1 = "[";
                s2 = "]";
            }
            return s1 + Convert.ToString(leva_gr) + "," + Convert.ToString(desna_gr) + s2;
        }

        public bool Pripada(double x)
        {
            if (otvorenLevo == 1 && otvorenDesno == 1 && x > leva_gr && x < desna_gr) return true;
            if (otvorenLevo == 0 && otvorenDesno == 1 && x >= leva_gr && x < desna_gr) return true;
            if (otvorenLevo == 1 && otvorenDesno == 0 && x > leva_gr && x <= desna_gr) return true;
            if (otvorenLevo == 0 && otvorenDesno == 0 && x >= leva_gr && x <= desna_gr) return true;
            return false;
        }
    }




}