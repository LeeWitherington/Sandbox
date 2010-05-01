using Microsoft.Practices.Unity;
using MVPDemo.IPresenter;
using MVPDemo.Utility;

// //------------------------------------------------------------------------------
// // Code disclaimer information
// // This document contains programming examples.
// // All sample code is provided for illustrative purposes only. These examples have not been thoroughly tested under all conditions. Therefore, cannot guarantee or imply reliability, serviceability, or function of these programs.
// // All programs contained herein are provided to you "AS IS" without any warranties of any kind.
// //------------------------------------------------------------------------------

namespace MVPDemo.ProcessFlowControl {
    public class Controller {
        private IMainPresenter _mainPresenter;
        private IOrderTimeRangeQueryPresenter _orderTimeRangeQueryPresenter;

        public Controller(IOrderTimeRangeQueryPresenter presenter) {
            _orderTimeRangeQueryPresenter = presenter;
            _orderTimeRangeQueryPresenter.Search += (OnQuerySearch);
        }

        public Controller(IMainPresenter presenter) {
            _mainPresenter = presenter;
            _mainPresenter.SelectRegion += (OnSelectRegion);
            _mainPresenter.SelectCustomer += (OnSelectCustomer);
            _mainPresenter.RetrieveRegions += (OnRetrieveRegions);
        }

        #region Event handler to handle events raised from Presenter

        private void OnQuerySearch(object sender, OrderTimeRangeQueryEventArgs e) {
            IUnityContainer container = CacheSingleton.Instance.GetUnityContainer();
            _mainPresenter = container.Resolve<IMainPresenter>();
            _mainPresenter.OpenView();
            _mainPresenter.HandleRetrieveOrderEvent(e.QueryFrom, e.QueryTo);
            _orderTimeRangeQueryPresenter.CloseView();
        }

        private void OnSelectRegion(object sender, RegionSelectedEventArgs e) {
            //This event doesn't cause the switch to different flow control
            _mainPresenter.HandleSelectRegionEvent();
        }

        private void OnRetrieveRegions(object sender, RetrieveRegionsEventArgs e) {
            //This event doesn't cause the switch to different flow control
            _mainPresenter.HandleRetrieveRegionsEvent();
        }

        private void OnSelectCustomer(object sender, CustomerSelectedEventArgs e) {
            IUnityContainer container = CacheSingleton.Instance.GetUnityContainer();
            _orderTimeRangeQueryPresenter = container.Resolve<IOrderTimeRangeQueryPresenter>();
            _orderTimeRangeQueryPresenter.OpenView();
            container.RegisterInstance(_mainPresenter);
        }

        #endregion
    }
}