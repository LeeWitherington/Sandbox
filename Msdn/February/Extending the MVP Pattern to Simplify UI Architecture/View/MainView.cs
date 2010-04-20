// //------------------------------------------------------------------------------
// // Code disclaimer information
// // This document contains programming examples.
// // All sample code is provided for illustrative purposes only. These examples have not been thoroughly tested under all conditions. Therefore, cannot guarantee or imply reliability, serviceability, or function of these programs.
// // All programs contained herein are provided to you "AS IS" without any warranties of any kind.
// //------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MVPDemo.Presenter;
using UIModel = MVPDemo.UIModel;
using MVPDemo.IView;

namespace MVPDemo.View
{
    public partial class MainView : Form, IMainView
    {
        private MainPresenter _presenter;
        private UIModel.Region _region;
        private UIModel.Customer _customer;
        private List<UIModel.Order> _orders;
        private List<UIModel.Region> _regionCandidates;
        private List<UIModel.Customer> _customerCandidates;
        private BindingSource _bindingSource = new BindingSource();

        public MainView()
        {
            InitializeComponent();
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            _presenter = new MainPresenter(this);
            _presenter.OnRetrieveRegionCandidates();
        }

        #region IMainView Members

        public UIModel.Region SelectedRegion
        {
            get
            {
                return _region;
            } 
        }
        
        public UIModel.Customer SelectedCustomer
        { 
            get
            {
                return _customer;
            }
        }
        
        public List<UIModel.Order> Orders 
        {
            set
            {
                _orders = value;
                PopulateOrdersGrid();
            }
        }

        public List<UIModel.Region> RegionCandidates
        {
            set
            {
                _regionCandidates = value;
                PopulateRegionCandidates();
            }
        }

        public List<UIModel.Customer> CustomerCandidates
        {
            set
            {
                _customerCandidates = value;
                PopulateCustomerCandidates();
            }
        }

        public void ShowView()
        {
            this.Show();
        }

        public void CloseView()
        {
            this.Hide();
        }

        #endregion

        private void cboRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < _regionCandidates.Count; i++)
            {
                if (_regionCandidates[i].Name == cboRegionList.SelectedItem.ToString ())
                {
                    _region = _regionCandidates[i];

                    i = _regionCandidates.Count;
                }
            }
            _presenter.OnRegionSelected();
        }

        private void cboCustomerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < _customerCandidates.Count; i++)
            {
                if (_customerCandidates[i].Name == cboCustomerList.SelectedItem.ToString ())
                {
                    _customer = _customerCandidates[i];

                    i = _customerCandidates.Count;
                }
            }
            _presenter.OnCustomerSelected ();
        }

        private void PopulateCustomerCandidates()
        {
            for (int i = 0; i < _customerCandidates.Count; i++)
            {
                cboCustomerList.Items.Add(_customerCandidates[i].Name);
            }
        }

        private void PopulateRegionCandidates()
        {
            for (int i = 0; i < _regionCandidates.Count; i++)
            {
                cboRegionList.Items.Add(_regionCandidates[i].Name);
            }
        }

        private void PopulateOrdersGrid()
        {
            gridorderHistory.Rows.Clear();
            for (int i = 0; i < _orders.Count; i++)
            {
                _bindingSource.Add(_orders[i]);
            }
            gridorderHistory.DataSource = _bindingSource;
        }
    }
}
