//###########################################################################################
//
// trida kulicky
//  -vytvoreno: 3.5 2023
//  -upraveno: 4.5 2023
//  -autor: Daniel Dvorak
//
//###########################################################################################
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BreakingWallGame
{
    internal class clsVozicek
    {
        //grafika pro krelsleni
        Graphics mobjGrafika;

        //promene vozicku
        int mintXVozicek, mintYVozicek;
        int mintSirkaVozicek;
        int mintVyskaVozicek;
        const int mintRychlostVozicek = 12;

        const float mflYUmisteniVozicku = 1.15f;

        ///--------------------------------------
        /// konstruktor
        ///--------------------------------------
        public clsVozicek(Graphics objPlatno, int intSirkaVozicek, int intVyskaVozicek)
        {
            mobjGrafika = objPlatno;
            mintXVozicek = (int)objPlatno.VisibleClipBounds.Width / 2;
            mintYVozicek = (int)(objPlatno.VisibleClipBounds.Height / mflYUmisteniVozicku);
            mintSirkaVozicek = intSirkaVozicek;
            mintVyskaVozicek = intVyskaVozicek;
        }
        //nacteni hodnot
        public int intYV{ get { return mintYVozicek; }}

        public void Pohyb(bool blPosunVlevo)
        {
            //vykresleni
            mobjGrafika.FillRectangle(Brushes.CornflowerBlue, mintXVozicek, mintYVozicek, mintSirkaVozicek, mintVyskaVozicek);
            
            //posun
            if (blPosunVlevo && mintXVozicek > 0)
            {
                mintXVozicek -= mintRychlostVozicek;
            }
            else if (blPosunVlevo == false && (mintXVozicek + mintSirkaVozicek) < mobjGrafika.VisibleClipBounds.Width)
            {
                mintXVozicek += mintRychlostVozicek;
            }

        }

        ///--------------------------------------
        /// test kolize
        /// -true : doslo ke kolizi
        ///--------------------------------------
        public bool TestKolize(int intXK, int intYK, int intWK, int intHK)
        {
            //test kolize
            if ((intYK + intHK >= mintYVozicek) &&
                (intYK + intHK <= mintYVozicek + mintVyskaVozicek * 2) &&
                (intXK + intWK >= mintXVozicek) &&
                (intXK <= mintXVozicek + mintSirkaVozicek))
            {
                return true;
            }
            else return false;
        }
    }
}
