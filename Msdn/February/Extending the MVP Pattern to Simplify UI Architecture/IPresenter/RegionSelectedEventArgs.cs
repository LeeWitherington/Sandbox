// //------------------------------------------------------------------------------
// // Code disclaimer information
// // This document contains programming examples.
// // All sample code is provided for illustrative purposes only. These examples have not been thoroughly tested under all conditions. Therefore, cannot guarantee or imply reliability, serviceability, or function of these programs.
// // All programs contained herein are provided to you "AS IS" without any warranties of any kind.
// //------------------------------------------------------------------------------

using System;
using MVPDemo.UIModel;

namespace MVPDemo.IPresenter {
    public class RegionSelectedEventArgs : EventArgs {
        private Region _selectedRegion;

        public RegionSelectedEventArgs(Region selectedRegion) {
            _selectedRegion = selectedRegion;
        }

        public Region SelectedRegion {
            get { return _selectedRegion; }
            set {
                if (_selectedRegion == value)
                    return;
                _selectedRegion = value;
            }
        }
    }
}