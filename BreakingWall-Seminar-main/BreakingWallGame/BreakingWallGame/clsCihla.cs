//###########################################################################################
//
// trida kulicky
//  -vytvoreno: 26.4 2023
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
    internal class clsCihla
    {
        //grafika pro krelsleni
        Graphics mobjGrafika;

        //promene cihly 
        int mintXCihly, mintYCihly;
        int mintSirkaCihly, mintVyskaCihly;
        bool mblJeVidet = true;

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
            //pokud cihla znicena, preksoceni vykresleni
            if (mblJeVidet == false) return;
            
            //vykresleni
            mobjGrafika.FillRectangle(Brushes.Orange, mintXCihly, mintYCihly, mintSirkaCihly, mintVyskaCihly);
        }

        ///--------------------------------------
        /// test kolize
        /// -true : doslo ke kolizi
        ///--------------------------------------
        public bool TestKolize(int intXK, int intYK, int intWK, int intHK)
        {
            //pokud cihla znicena, preskoceni testovani
            if (mblJeVidet == false) return false;

            //test kolize
            if ((intYK + intHK >= mintYCihly) &&
                (intYK + intHK <= mintYCihly + mintVyskaCihly *2) &&
                (intXK + intWK >= mintXCihly) &&
                (intXK <= mintXCihly + mintSirkaCihly))
            {
                mblJeVidet = false;
                return true;

            }
            else
            {
                mblJeVidet = true;
                return false;
            }
        }
    }
}
