// //------------------------------------------------------------------------------
// // Code disclaimer information
// // This document contains programming examples.
// // All sample code is provided for illustrative purposes only. These examples have not been thoroughly tested under all conditions. Therefore, cannot guarantee or imply reliability, serviceability, or function of these programs.
// // All programs contained herein are provided to you "AS IS" without any warranties of any kind.
// //------------------------------------------------------------------------------

using System;
using System.Windows.Forms;
using MVPDemo.IView;
using MVPDemo.Presenter;

namespace MVPDemo.View {
    public partial class OrderTimeRangeQueryView : Form, IOrderTimeRangeQueryView {
        private OrderTimeRangeQueryPresenter _presenter;

        public OrderTimeRangeQueryView() {
            InitializeComponent();
        }

        #region IOrderTimeRangeQueryView Members

        public DateTime SearchQueryFrom {
            get { return Convert.ToDateTime(txtFrom.Text); }
        }

        public DateTime SearchQueryTo {
            get { return Convert.ToDateTime(txtTo.Text); }
        }

        public void ShowView() {
            Show();
        }

        public void CloseView() {
            Hide();
        }

        #endregion

        private void btnSubmit_Click(object sender, EventArgs e) {
            _presenter.OnQuerySubmitted();
        }

        private void OrderTimeRangeQueryView_Load(object sender, EventArgs e) {
            _presenter = new OrderTimeRangeQueryPresenter(this);
        }
    }
}