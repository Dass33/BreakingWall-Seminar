using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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
        const int mintSirskaCihly = 80, mintVyskaCihly = 20;
        const int mintVelikostMezery = 20;
        const int mintPocetRadCihel = 3;

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
            int lintX, lintY;

            InitializeComponent();

            //init promenych
            mobjGrafika = pbplatno.CreateGraphics();

            //vytvoreni kulicky
            mobjKulicka = new clsKulicka(mobjGrafika);

            //vytvoreni pole
            mintPocetCihel = mintPocetRadCihel * ((pbplatno.Width - mintVelikostMezery) / (mintSirskaCihly + mintVelikostMezery));
            mobjCihla = new clsCihla[mintPocetCihel];


            //vytvoreni cihel
            lintX = lintY = mintVelikostMezery;
            for (int i=0; i<mintPocetCihel; i++)
            {
                //pokud se dalsi cihla nevejde nekresli se dalsi
                if ((lintX + mintSirskaCihly + mintVelikostMezery)> pbplatno.Width)
                {
                    //resetovani x souradnice
                    lintX = mintVelikostMezery;
                    lintY += mintVyskaCihly + mintVelikostMezery;
                }

                //vytvoreni jednitlivych cihel
                mobjCihla[i] = new clsCihla(mobjGrafika, lintX, lintY, mintSirskaCihly, mintVyskaCihly);
                
                //zmena souradnic
                lintX += mintSirskaCihly + mintVelikostMezery;
            }
        }

        private void tmrRedraw_Tick(object sender, EventArgs e)
        {
            //smazat scenu
            mobjGrafika.Clear(Color.White);

            //posun kulicky
            mobjKulicka.Pohyb();

            //vykresleni vsech cihel
            foreach (clsCihla objCihla in mobjCihla)
            {
                objCihla.NakresleniCihly();
            }
        }
    }
}
