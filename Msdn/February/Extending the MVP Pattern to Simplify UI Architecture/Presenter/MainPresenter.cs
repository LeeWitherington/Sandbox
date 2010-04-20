﻿// //------------------------------------------------------------------------------
// // Code disclaimer information
// // This document contains programming examples.
// // All sample code is provided for illustrative purposes only. These examples have not been thoroughly tested under all conditions. Therefore, cannot guarantee or imply reliability, serviceability, or function of these programs.
// // All programs contained herein are provided to you "AS IS" without any warranties of any kind.
// //------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVPDemo.ServiceAgent;
using MVPDemo.UIModel;
using MVPDemo.IPresenter;
using MVPDemo.IView;
using MVPDemo.ProcessFlowControl;

namespace MVPDemo.Presenter
{
    public class MainPresenter:IMainPresenter
    {
        private readonly IMainView _view;
        private readonly Controller _controller;

        public MainPresenter() { }
        public MainPresenter(IMainView view)
        {
            _view = view;
            _controller = new Controller(this);
        }

        #region IOrderTimeRangeQueryPresenter Members

        public event EventHandler<CustomerSelectedEventArgs> SelectCustomer;

        public event EventHandler<RegionSelectedEventArgs> SelectRegion;

        public event EventHandler<RetrieveRegionsEventArgs> RetrieveRegions;

        public void OpenView()
        {
            _view.ShowView ();
        }

        public void CloseView()
        {
            _view.CloseView();
        }

        #endregion

        #region React to Controller's requests
        public void HandleRetrieveOrderEvent(DateTime queryFrom, DateTime queryTo)
        {
            OrderAdminServiceAgent agent = new OrderAdminServiceAgent();
            List<Order> orders = agent.RetrieveOrders(_view.SelectedCustomer, queryFrom, queryTo);
            _view.Orders = orders;
        }

        public void HandleSelectRegionEvent()
        {
            CustomerAdminServiceAgent agent = new CustomerAdminServiceAgent();
            List<Customer> customerCandidates = agent.RetrieveCustomers(_view.SelectedRegion);
            _view.CustomerCandidates = customerCandidates;
        }

        public void HandleRetrieveRegionsEvent()
        {
            RegionAdminServiceAgent agent = new RegionAdminServiceAgent();
            List<Region> regionCandidates = agent.RetriveRegions();
            _view.RegionCandidates = regionCandidates;
        }

        #endregion 
        
        #region React to View's requests
        public void OnRegionSelected()
        {
            if (SelectRegion != null)
            {
                SelectRegion(this, new RegionSelectedEventArgs(_view.SelectedRegion));
            }
        }

        public void OnCustomerSelected()
        {
            if (SelectCustomer != null)
            {
                SelectCustomer(this, new CustomerSelectedEventArgs(_view.SelectedCustomer));
            }
        }
        
        public void OnRetrieveRegionCandidates()
        {
            if (RetrieveRegions != null)
            {
                RetrieveRegions(this, new RetrieveRegionsEventArgs());
            }
        }
        #endregion
    }
}