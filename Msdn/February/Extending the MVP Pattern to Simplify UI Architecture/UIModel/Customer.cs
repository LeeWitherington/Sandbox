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

namespace MVPDemo.UIModel
{
    public class Customer
    {
        string _name;
      
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
    }
}
