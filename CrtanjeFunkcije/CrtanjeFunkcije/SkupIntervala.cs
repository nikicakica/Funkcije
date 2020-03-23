using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrtanjeFunkcije
{
    class SkupIntervala
    {
        Interval[] intervals;
        //poenta ovog konstruktora je da niz intervala koji dobije kao argument sazme u drugi ekvivalentan niz
        //niz intervala sa najmanjim mogucim brojem clanova
        // 
        public SkupIntervala(Interval[] intervals)
        {
            Interval[] pom;
            //ove dve for petlje sluze za prolazak kroz sve parove intervala u nizu
            for (int i = 0; i <intervals.Length; i++)
            {
                for (int j = i+1; j < intervals.Length; j++)
                {
                    //ovaj if proverava da li ima preklapanja izmedju intervala i i j
                    if (intervals[i] ^ intervals[j])
                    {
                        //ukoliko ima preklapanja spajamo intervale i i j i smestamo novodobijeni interval na i-to mesto u nizu
                        
                        intervals[i] = intervals[i] + intervals[j];
                        //onda sve intervale koji su posle j pomeramo na jednu poziciju manje
                        // na taj nacin brisemo j
                        for (int k = j; k < intervals.Length-1; i++)
                        {
                            intervals[k] = new Interval(intervals[k + 1]);
                        }
                        //problem je u tome sto zelimo da se i duzina intervala smanji
                        //zato pravimo pomocni niz u koji smestamo sve elemente intervals sem poslednjeg
                        //koji je zapravo isti kao i pretposlednji
                        
                        pom = new Interval[intervals.Length - 1];
                        for (int m = 0; m < intervals.Length-1; m++)
                        {
                            pom[m] = new Interval(intervals[m]);
                        }
                        //nakon toga pravimo novi niz intervala ispravne duzine na koji od sada pokazuje referenca intervals

                        intervals = new Interval[pom.Length];
                        for (int t = 0; t < pom.Length; t++)
                        {
                            intervals[t] = new Interval(pom[t]);
                        }
                        j--;
                        
                        //sada u taj novi niz kopiramo elemente iz pomocnog niza
                    }
                }
                
                
            }
            this.intervals = new Interval[intervals.Length]; 
            for (int i = 0; i < intervals.Length; i++)
            {
                this.intervals[i] = new Interval(intervals[i]);
            }
        }
        public override string ToString()
        {
            string res = intervals[0].ToString();
            for (int i = 1; i < intervals.Length; i++)
            {
                res += (" U "+intervals[i].ToString());
            }
            return res;
        }
        public bool Pripada(double x)
        {
            for (int i = 0; i < intervals.Length; i++) {
                if (intervals[i].Pripada(x)) return true;
            }
            return false;
        }

    }
}