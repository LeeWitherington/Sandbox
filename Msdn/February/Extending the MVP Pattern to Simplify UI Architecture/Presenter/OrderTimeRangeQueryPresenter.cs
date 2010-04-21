// //------------------------------------------------------------------------------
// // Code disclaimer information
// // This document contains programming examples.
// // All sample code is provided for illustrative purposes only. These examples have not been thoroughly tested under all conditions. Therefore, cannot guarantee or imply reliability, serviceability, or function of these programs.
// // All programs contained herein are provided to you "AS IS" without any warranties of any kind.
// //------------------------------------------------------------------------------

using System;
using MVPDemo.IPresenter;
using MVPDemo.IView;
using MVPDemo.ProcessFlowControl;

namespace MVPDemo.Presenter {
    public class OrderTimeRangeQueryPresenter : IOrderTimeRangeQueryPresenter {
        private readonly IOrderTimeRangeQueryView _view;
        private Controller _controller;
        public OrderTimeRangeQueryPresenter() {}

        public OrderTimeRangeQueryPresenter(IOrderTimeRangeQueryView view) {
            _view = view;
            _controller = new Controller(this);
        }

        #region IOrderTimeRangeQueryPresenter Members

        public event EventHandler<OrderTimeRangeQueryEventArgs> Search;

        public void OpenView() {
            _view.ShowView();
        }

        public void CloseView() {
            _view.CloseView();
        }

        #endregion

        public void OnQuerySubmitted() {
            if (Search != null)
                Search(this, new OrderTimeRangeQueryEventArgs(_view.SearchQueryFrom, _view.SearchQueryTo));
        }
    }
}