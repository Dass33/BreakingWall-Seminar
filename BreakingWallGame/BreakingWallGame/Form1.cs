using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BreakingWallGame
{
    public partial class Form1 : Form
    {

        //grafika pro krelsleni
        Graphics mobjGrafika;

        //trida kulicky
        //objekt vytvoreny z tridy kulicka
        clsKulicka mobjKulicka;

        //trida pro cihly
        int mintPocetCihel;
        clsCihla[] mobjCihla;

        //timer
        const int tmrRedrawSpeed = 20;

        private void Form1_Load(object sender, EventArgs e)
        {
            //init Timeru 
            tmrRedraw.Interval = tmrRedrawSpeed;
            tmrRedraw.Start();
        }

        //konstruktor se vola pred loadem
        public Form1()
        {
            InitializeComponent();

            //init promenych
            mobjGrafika = pbplatno.CreateGraphics();

            //vytvoreni kulicky
            mobjKulicka = new clsKulicka(mobjGrafika);

            //vytvoreni pole
            mintPocetCihel = 10;
            mobjCihla = new clsCihla[mintPocetCihel];

            //vytvoreni cihel
            for (int i=0; i<mintPocetCihel; i++)
            {
                //vytvoreni jednitlivych cihel
                mobjCihla[i] = new clsCihla();
            }
        }

        private void tmrRedraw_Tick(object sender, EventArgs e)
        {
            //smazat scenu
            mobjGrafika.Clear(Color.White);

            //posun kulicky
            mobjKulicka.Pohyb();
        }
    }
}
