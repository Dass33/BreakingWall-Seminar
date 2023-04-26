//###########################################################################################
//
// trida kulicky
//  -vytvoreno: 26.4 2023
//  -upraveno: 26.4 2023
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
    internal class clsCihla
    {
        //grafika pro krelsleni
        Graphics mobjGrafika;

        //promene cihly 
        int mintXCihly, mintYCihly;
        int mintSirkaCihly, mintVyskaCihly;

        ///--------------------------------------
        /// konstruktor
        ///--------------------------------------

        public clsCihla(Graphics objPlatno, int intXCihly, int intYCihly, int intSirkaCihly, int intVyskaCihly)
        {
            mobjGrafika = objPlatno;
            mintXCihly = intXCihly;
            mintYCihly = intYCihly;
            mintVyskaCihly = intVyskaCihly;
            mintSirkaCihly = intSirkaCihly;

        }
        ///--------------------------------------
        /// Vykresleni cihly
        ///--------------------------------------
        public void NakresleniCihly()
        {
            mobjGrafika.FillRectangle(Brushes.Orange, mintXCihly, mintYCihly, mintSirkaCihly, mintVyskaCihly);
        }

    }
}
