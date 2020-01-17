using StoelVinder.lib.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NS_Stoel_Vinder_Lib.DAL.Contexts.TestContext
{
    public class WagonTestContext
    {
        readonly Wagon wagon = new Wagon(9, 4,  1, false);

        public bool WagonContext(int wagonnr, int klasse, bool toilet)
        {
            if (wagon.Wagonnumber == wagonnr && wagon.TrainClass == klasse && wagon.Toilet == toilet)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
