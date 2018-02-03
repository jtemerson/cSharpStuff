using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk_3_JTEmerson
{
    class DeskQuote
    {
        private decimal pwidth;
        private decimal pdepth;
        private int pnumberOfDrawers;
        private string pmaterial;
        private int prushDays;

        private decimal SURFACECOST = 1; //cost per square inch over the base size
        private decimal BASESIZE = 1000; //

        public string customerName { get; set; }
        public DateTime quoteDate { get; set; }

        public DeskQuote(decimal width, decimal depth, int numberOfDrawers, string material, int rushDays)
        {
            pwidth = width;
            pdepth = depth;
        }

        //logic for surface cost
        public decimal surfaceAreaCost()
        {
            //determine if size of desk is large enough for an additional charge
            if ( pwidth * pdepth > BASESIZE)
            {
                return (pwidth * pdepth - BASESIZE) * SURFACECOST;
            }
            else
            {
                return 0;
            }
        }

    }
}


/*
public string customerName { get; set; }
public DateTime quoteDate { get; set; }
public int rushDays { get; set; }
public Desk desk = new Desk();
public int quoteAmmount { get; set; }

private const int PRICEBASE = 200;
private const int SIZE_THRESHOLD = 1000;
private const int PRICE_PER_DRAWER = 50;
private const int PRICE_PER_SURFACEAREA = 1;
private const int RUSH1 = 3;
private const int RUSH2 = 5;
private const int RUSH3 = 7;
private const int RUSH_THRESHOLD = 2000;
    }

    public DeskQuote(string customerName, DateTime quoteDate, int width, int depth, int drawers, DesktopMaterial material, int rushDays)
        (
            CustomerName = customerName;
            Desk.width = width;
            Desk.depth = depth;
            Desk.numberOfDrawers = drawers;
            Desk.desktopMaterial = material;
            RushDays = rushDays;
        )
        */