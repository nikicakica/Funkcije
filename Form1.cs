using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FunkcijeAplikacija
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        Funkcija f1 ;
        Funkcija f2 ;
        Funkcija f3 ;
        Funkcija f4;
        Funkcija f;
        PointF O;
        private void Form1_Load(object sender, EventArgs e)
        {
            f1 = new PromenjivaFunkcija();
            f2 = new KonstantnaFunkcija(7);
            f3 = new SlozenaFunkcija(f2, f1, '*');
            f4 = new SlozenaFunkcija(f3, new KonstantnaFunkcija(7), '+');
            f = new SinusnaFunkcija(f4);
            O= new PointF(50, 20);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
        
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            
                f.Nacrtaj(e.Graphics,O,20,-50,50);
            
        }
    }
}
