//###########################################################################################
//
// trida kulicky
//  -vytvoreno: 3.5 2023
//  -upraveno: 3.5 2023
//  -autor: Daniel Dvorak
//
//###########################################################################################
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakingWallGame
{
    internal class clsVozicek
    {
        //grafika pro krelsleni
        Graphics mobjGrafika;

        //promene cihly 
        int mintXVozicek, mintYVozicek;
        int mintSirkaVozicek;
        int mintVyskaVozicek;

        ///--------------------------------------
        /// konstruktor
        ///--------------------------------------
        public clsVozicek(Graphics objPlatno, int intSirkaVozicek, int intVyskaVozicek)
        {
            mobjGrafika = objPlatno;
            mintXVozicek = (int)objPlatno.VisibleClipBounds.Width / 2;
            mintYVozicek = (int)(objPlatno.VisibleClipBounds.Height / 2);
            mintSirkaVozicek = intSirkaVozicek;
            mintVyskaVozicek = intVyskaVozicek;
        }
        public void NakresleniVozicku()
        {
            //vykresleni
            mobjGrafika.FillRectangle(Brushes.CornflowerBlue, mintXVozicek, mintYVozicek, mintSirkaVozicek, mintVyskaVozicek);
        }
    }
}
