// //------------------------------------------------------------------------------
// // Code disclaimer information
// // This document contains programming examples.
// // All sample code is provided for illustrative purposes only. These examples have not been thoroughly tested under all conditions. Therefore, cannot guarantee or imply reliability, serviceability, or function of these programs.
// // All programs contained herein are provided to you "AS IS" without any warranties of any kind.
// //------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVPDemo.UIModel;

namespace MVPDemo.ServiceAgent
{
   public class RegionAdminServiceAgent
    {
        public List<Region> RetriveRegions()
        {
            //Not to call real service. Mock up data here
            List<Region> regions = new List<Region>();

            Region region = new Region();
            region.Name = "East Region";
            regions.Add(region);

            region = new Region();
            region.Name = "West Region";
            regions.Add(region);

            return regions;
        }
    }
}
