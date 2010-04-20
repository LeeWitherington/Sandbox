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

namespace MVPDemo.IView
{
    public interface IOrderTimeRangeQueryView
    {
        DateTime SearchQueryFrom { get; }
        DateTime SearchQueryTo { get; }
        void ShowView();
        void CloseView();

    }
}
