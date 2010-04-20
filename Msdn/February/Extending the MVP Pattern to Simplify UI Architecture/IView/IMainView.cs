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

namespace MVPDemo.IView
{
    public interface IMainView
    {
        Region SelectedRegion { get;}
        Customer SelectedCustomer { get; }
        List<Order> Orders { set; }
        List<Region> RegionCandidates { set; }
        List<Customer> CustomerCandidates { set; }
        void ShowView ();
        void CloseView();

    }
}
