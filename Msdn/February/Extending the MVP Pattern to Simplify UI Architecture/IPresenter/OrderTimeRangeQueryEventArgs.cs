// //------------------------------------------------------------------------------
// // Code disclaimer information
// // This document contains programming examples.
// // All sample code is provided for illustrative purposes only. These examples have not been thoroughly tested under all conditions. Therefore, cannot guarantee or imply reliability, serviceability, or function of these programs.
// // All programs contained herein are provided to you "AS IS" without any warranties of any kind.
// //------------------------------------------------------------------------------

using System;

namespace MVPDemo.IPresenter {
    public class OrderTimeRangeQueryEventArgs : EventArgs {
        private DateTime _queryFrom;
        private DateTime _queryTo;

        public OrderTimeRangeQueryEventArgs(DateTime queryFrom, DateTime queryTo) {
            _queryFrom = queryFrom;
            _queryTo = queryTo;
        }

        public DateTime QueryFrom {
            get { return _queryFrom; }
            set {
                if (_queryFrom == value)
                    return;
                _queryFrom = value;
            }
        }

        public DateTime QueryTo {
            get { return _queryTo; }
            set {
                if (_queryTo == value)
                    return;
                _queryTo = value;
            }
        }
    }
}