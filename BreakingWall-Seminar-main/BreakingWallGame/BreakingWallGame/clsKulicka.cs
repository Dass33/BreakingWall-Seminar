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
using System.Xml.Linq;
using System.Security.Cryptography.X509Certificates;

namespace BreakingWallGame
{
    class clsKulicka
    {
        //grafika pro krelsleni
        Graphics mobjGrafika;
        //promene kulicky
        int mintXKulicky, mintYKulicky;
        int mintPohybX, mintPohybY;
        const int mintRKulicky = 25;
        const int mintRychlostPosunu = 8;

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

        //nacteni hodnot
        public int intRK { get { return mintRKulicky; } }
        public int intXK { get { return mintXKulicky; } }
        public int intYK { get { return mintYKulicky; } set { mintYKulicky = value; } }
        public int intWK { get { return mintRKulicky; } }
        public int intHK { get { return mintRKulicky; } }
        
        public int intPY { get { return mintPohybY; } set {mintPohybY = value; } }

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

            //odrazeni kulicky
            if (mintYKulicky < 0)
            {
                mintPohybY = mintPohybY * (-1);
            }
            if ((mintXKulicky + mintRKulicky) > mobjGrafika.VisibleClipBounds.Width || mintXKulicky < 0)
            {
                mintPohybX = mintPohybX * (-1);
            }
        }
        //pokud se kulicka dostane mimo platno => propadne dolni hranou ukonci se hra
        public bool MimoPlatno()
        {
            if((mintYKulicky + mintRKulicky) > mobjGrafika.VisibleClipBounds.Height)
            {
                return true;
            }
            else return false;
        }
    }
}
