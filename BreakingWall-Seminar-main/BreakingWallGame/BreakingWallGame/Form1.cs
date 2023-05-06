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
        const int mintSirskaCihly = 92, mintVyskaCihly = 22;
        const int mintVelikostMezery = 35;
        const int mintPocetRadCihel = 3;

        int mintZniceneCihly = 0;
            
        //trida pro vozicek
        clsVozicek mobjVozicek;
        bool mblPosunVozickuVlevo;

        const int mintSirkaVozicek = 140;
        const int mintVyskaVozicek = 25;

        //end GUI
        const int mintMezeraElemntu = 80;

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

            //vytvoreni vozicku 
            mobjVozicek = new clsVozicek(mobjGrafika, mintSirkaVozicek, mintVyskaVozicek);


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

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //po zmacknuti mezerniku meni smer kterym se pohybuje hrac
            if (e.KeyCode == Keys.Space && mblPosunVozickuVlevo == false)
            {
                mblPosunVozickuVlevo = true;
            }
            else if (e.KeyCode == Keys.Space)
            {
                mblPosunVozickuVlevo = false;
            }
        }

        private void btStartOver_Click(object sender, EventArgs e)
        {
            //restartovani hry;
            Application.Restart();
        }

        //obrazovka po skoceni hry
        private void EndGameGUI(string mstrEndText)
        {
            //zastaveni hry
            tmrRedraw.Stop();

            //tlacitko pro restart hry
            btStartOver.BackColor = Color.DarkBlue;
            btStartOver.Enabled = true;
            btStartOver.Text = "Start Again";
            btStartOver.ForeColor = Color.WhiteSmoke;
            btStartOver.Font = new Font("Arial", 40, FontStyle.Bold);
            btStartOver.Width = (int)(pbplatno.Width / 2.5f);
            btStartOver.Height = (int)pbplatno.Height / 7;
            btStartOver.Location = new Point((int)pbplatno.Width / 2 - btStartOver.Width / 2, (int)pbplatno.Height / 2 - btStartOver.Height / 2 + mintMezeraElemntu);
            btStartOver.Visible = true;

            //Game over text
            lbGameOver.Text = mstrEndText;
            lbGameOver.Location = new Point(pbplatno.Width / 2 - lbGameOver.Width / 2, pbplatno.Height / 2 - lbGameOver.Height / 2 - mintMezeraElemntu);
            lbGameOver.Visible = true;
        }

        private void tmrRedraw_Tick(object sender, EventArgs e)
        {
            //smazat scenu
            mobjGrafika.Clear(Color.White);
            
            //posun kulicky
            mobjKulicka.Pohyb();

            //kontrola jestli hrac neprohral
            if (mobjKulicka.MimoPlatno()) {EndGameGUI("Game Over"); }

            //kontrola jestli hrace nevyhral 
            if(mintZniceneCihly ==  mintPocetCihel) { EndGameGUI("You Won!!"); }

            //vykresleni hrace
            mobjVozicek.Pohyb(mblPosunVozickuVlevo);

            //test kolize hrace
            if (mobjVozicek.TestKolize(mobjKulicka.intXK, mobjKulicka.intYK, mobjKulicka.intWK, mobjKulicka.intHK))
            {
                mobjKulicka.intPY = mobjKulicka.intPY * (-1);
                mobjKulicka.intYK = mobjVozicek.intYV - mobjKulicka.intRK;
            }

            //test kolize vsech cihel
            //vykresleni vsech cihel
            foreach (clsCihla objCihla in mobjCihla)
            {
               if (objCihla.TestKolize(mobjKulicka.intXK, mobjKulicka.intYK, mobjKulicka.intWK, mobjKulicka.intHK))
                {
                    mobjKulicka.intPY = mobjKulicka.intPY * (-1);
                    mintZniceneCihly++;
                }   

                objCihla.NakresleniCihly();
            }
        
        
        }
    }
}


