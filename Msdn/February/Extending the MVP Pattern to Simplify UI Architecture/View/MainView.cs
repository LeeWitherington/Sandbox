// //------------------------------------------------------------------------------
// // Code disclaimer information
// // This document contains programming examples.
// // All sample code is provided for illustrative purposes only. These examples have not been thoroughly tested under all conditions. Therefore, cannot guarantee or imply reliability, serviceability, or function of these programs.
// // All programs contained herein are provided to you "AS IS" without any warranties of any kind.
// //------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MVPDemo.IView;
using MVPDemo.Presenter;
using MVPDemo.UIModel;

namespace MVPDemo.View {
    public partial class MainView : Form, IMainView {
        private readonly BindingSource _bindingSource = new BindingSource();
        private Customer _customer;
        private List<Customer> _customerCandidates;
        private List<Order> _orders;
        private MainPresenter _presenter;
        private Region _region;
        private List<Region> _regionCandidates;

        public MainView() {
            InitializeComponent();
        }

        #region IMainView Members

        public Region SelectedRegion {
            get { return _region; }
        }

        public Customer SelectedCustomer {
            get { return _customer; }
        }

        public List<Order> Orders {
            set {
                _orders = value;
                PopulateOrdersGrid();
            }
        }

        public List<Region> RegionCandidates {
            set {
                _regionCandidates = value;
                PopulateRegionCandidates();
            }
        }

        public List<Customer> CustomerCandidates {
            set {
                _customerCandidates = value;
                PopulateCustomerCandidates();
            }
        }

        public void ShowView() {
            Show();
        }

        public void CloseView() {
            Hide();
        }

        #endregion

        private void MainView_Load(object sender, EventArgs e) {
            _presenter = new MainPresenter(this);
            _presenter.OnRetrieveRegionCandidates();
        }

        private void cboRegion_SelectedIndexChanged(object sender, EventArgs e) {
            for (int i = 0; i < _regionCandidates.Count; i++) {
                if (_regionCandidates[i].Name == cboRegionList.SelectedItem.ToString()) {
                    _region = _regionCandidates[i];

                    i = _regionCandidates.Count;
                }
            }
            _presenter.OnRegionSelected();
        }

        private void cboCustomerList_SelectedIndexChanged(object sender, EventArgs e) {
            for (int i = 0; i < _customerCandidates.Count; i++) {
                if (_customerCandidates[i].Name == cboCustomerList.SelectedItem.ToString()) {
                    _customer = _customerCandidates[i];

                    i = _customerCandidates.Count;
                }
            }
            _presenter.OnCustomerSelected();
        }

        private void PopulateCustomerCandidates() {
            for (int i = 0; i < _customerCandidates.Count; i++)
                cboCustomerList.Items.Add(_customerCandidates[i].Name);
        }

        private void PopulateRegionCandidates() {
            for (int i = 0; i < _regionCandidates.Count; i++)
                cboRegionList.Items.Add(_regionCandidates[i].Name);
        }

        private void PopulateOrdersGrid() {
            gridorderHistory.Rows.Clear();
            foreach (Order t in _orders) _bindingSource.Add(t);
            gridorderHistory.DataSource = _bindingSource;
        }
    }
}