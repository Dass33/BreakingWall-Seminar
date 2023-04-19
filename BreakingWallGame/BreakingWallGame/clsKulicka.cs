//###########################################################################################
//
// trida kulicky
//  -vytvoreno: 19.4 2023
//  -upraveno: 19.4 2023
//  -autor: Daniel Dvorak
//
//###########################################################################################

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BreakingWallGame
{
    class clsKulicka
    {
        //grafika pro krelsleni
        Graphics mobjGrafika;
        //promene kulicky
        int mintXKulicky, mintYKulicky;
        int mintPohybX, mintPohybY;
        const int mintRKulicky = 15;
        const int mintRychlostPosunu = 3;
        const int tmrRedrawSpeed = 20;

        ///--------------------------------------
        /// konstruktor
        ///--------------------------------------
        public clsKulicka(Graphics objPlatno)
        {
            mobjGrafika = objPlatno;

            mintXKulicky = (int)objPlatno.VisibleClipBounds.Width / 2;
            mintYKulicky = (int)objPlatno.VisibleClipBounds.Height / 2;
            mintPohybX = mintRychlostPosunu;
            mintPohybY = mintRychlostPosunu;
        }

        ///--------------------------------------
        /// pohyb kulicky po platne
        ///--------------------------------------
        public void Pohyb()
        {
            //vykresleni kulicky
            mobjGrafika.FillEllipse(Brushes.Red, mintXKulicky, mintYKulicky, mintRKulicky, mintRKulicky);

            //posun
            mintXKulicky += mintPohybX;
            mintYKulicky += mintPohybY;

            if ((mintYKulicky + mintRKulicky) > mobjGrafika.VisibleClipBounds.Height || (mintYKulicky + mintRKulicky) < 0)
            {
                mintPohybY = mintPohybY * (-1);
            }
            if ((mintXKulicky + mintRKulicky) > mobjGrafika.VisibleClipBounds.Width || (mintXKulicky + mintRKulicky) < 0)
            {
                mintPohybX = mintPohybX * (-1);
            }
        }
    }
}
