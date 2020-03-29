using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CrtanjeFunkcije
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Funkcija Citaj(string s, int i, int l, int r)
        {
            Funkcija f = new Konstanta(0);
            char znak = 'z';
            while (i < r)
            {
                Funkcija g = new Konstanta(0);
                if ('1' <= s[i] && s[i] <= '9')
                {
                    int br = 0;
                    while ('0' <= s[i] && s[i] <= '9')
                    {
                        br = br * 10 + (s[i] - '0');
                        i++;
                        if (i == r) break;
                    }
                    g = new Konstanta(br);
                }
                else if (s[i] == 'x')
                {
                    g = new Promenljiva();
                    i++;
                }
                else if (s[i] == '(')
                {
                    int idx = i;
                    while (s[i] != ')') i++;
                    g = new Konstanta(0);
                    g = Citaj(s, idx + 1, idx + 1, i);
                }
                else if (s[i] == 's')//sinus
                {
                    i += 3;
                    if (s[i] == '(')
                    {
                        int idx = i;
                        while (s[i] != ')') i++;
                        Funkcija g1;
                        g1 = new Konstanta(0);
                        g1 = Citaj(s, idx + 1, idx + 1, i);
                        g = new SpecFunkcija(g1, "sin");
                    }
                    else if (s[i] == 'x')
                    {
                        g = new SpecFunkcija(new Promenljiva(), "sin");
                        i++;
                    }
                    else
                    {
                        int br = 0;
                        while ('0' <= s[i] && s[i] <= '9')
                        {
                            br = br * 10 + (s[i] - '0');
                            i++;
                            if (i == r) break;
                        }
                        g = new SpecFunkcija(new Konstanta(br), "sin");
                    }
                }
                else if (s[i] == 'c')//kosinus
                {
                    i += 3;
                    if (s[i] == '(')
                    {
                        int idx = i;
                        while (s[i] != ')') i++;
                        Funkcija g1;
                        g1 = new Konstanta(0);
                        g1 = Citaj(s, idx + 1, idx + 1, i);
                        g = new SpecFunkcija(g1, "cos");
                    }
                    else if (s[i] == 'x')
                    {
                        g = new SpecFunkcija(new Promenljiva(), "cos");
                        i++;
                    }
                    else
                    {
                        int br = 0;
                        while ('0' <= s[i] && s[i] <= '9')
                        {
                            br = br * 10 + (s[i] - '0');
                            i++;
                            if (i == r) break;
                        }
                        g = new SpecFunkcija(new Konstanta(br), "cos");
                    }
                }
                else if (s[i] == 't')//tangens
                {
                    i += 2;
                    if (s[i] == '(')
                    {
                        int idx = i;
                        while (s[i] != ')') i++;
                        Funkcija g1;
                        g1 = new Konstanta(0);
                        g1 = Citaj(s, idx + 1, idx + 1, i);
                        g = new SpecFunkcija(g1, "tg");
                    }
                    else if (s[i] == 'x')
                    {
                        g = new SpecFunkcija(new Promenljiva(), "tg");
                        i++;
                    }
                    else
                    {
                        int br = 0;
                        while ('0' <= s[i] && s[i] <= '9')
                        {
                            br = br * 10 + (s[i] - '0');
                            i++;
                            if (i == r) break;
                        }
                        g = new SpecFunkcija(new Konstanta(br), "tg");
                    }
                }
                else if (s[i] == 'l')//logaritam
                {
                    i += 2;
                    if (s[i] == '(')
                    {
                        int idx = i;
                        while (s[i] != ')') i++;
                        Funkcija g1;
                        g1 = new Konstanta(0);
                        g1 = Citaj(s, idx + 1, idx + 1, i);
                        g = new SpecFunkcija(g1, "ln");
                    }
                    else if (s[i] == 'x')
                    {
                        g = new SpecFunkcija(new Promenljiva(), "ln");
                        i++;
                    }
                    else
                    {
                        int br = 0;
                        while ('0' <= s[i] && s[i] <= '9')
                        {
                            br = br * 10 + (s[i] - '0');
                            i++;
                            if (i == r) break;
                        }
                        g = new SpecFunkcija(new Konstanta(br), "ln");
                    }
                }
                if (i < r)
                {
                    if(s[i]=='+' || s[i]=='-' || s[i]=='*' || s[i]=='/' || s[i]=='^')
                    {
                        if (znak == 'z') f = g;
                        else if (znak == '+') f += g;
                        else if (znak == '-') f -= g;
                    }
                    if (s[i] == '+')
                    {
                        znak = '+';
                    }
                    else if (s[i] == '-') znak = '-';
                    else if (s[i] == '*') znak = '*';
                    else if (s[i] == '/') znak = '/';
                    else if (s[i] == '^') znak = '^';
                    i++;
                }
                if (znak == 'z') f = g;
                else if (znak == '+') f += g;
                else if (znak == '-') f -= g;
                if (i == r) return f;
            }
            return f;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PointF O = new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2);
            Graphics g = pictureBox1.CreateGraphics();
            Funkcija f = new Konstanta(0);
            string s = textBox1.Text;
            f = Citaj(s, 0, 0, s.Length);
            f.Nacrtaj(g, O, 5, -100, 100, pictureBox1.Height);
        }
    }
}
