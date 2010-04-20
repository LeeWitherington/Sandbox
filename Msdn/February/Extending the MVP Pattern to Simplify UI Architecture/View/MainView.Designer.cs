namespace MVPDemo.View
{
    partial class MainView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TreePanel = new System.Windows.Forms.Panel();
            this.cboCustomerList = new System.Windows.Forms.ComboBox();
            this.lblCustomerList = new System.Windows.Forms.Label();
            this.cboRegionList = new System.Windows.Forms.ComboBox();
            this.lblRegionList = new System.Windows.Forms.Label();
            this.ResultPanel = new System.Windows.Forms.Panel();
            this.gridorderHistory = new System.Windows.Forms.DataGridView();
            this.TreePanel.SuspendLayout();
            this.ResultPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridorderHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // TreePanel
            // 
            this.TreePanel.Controls.Add(this.cboCustomerList);
            this.TreePanel.Controls.Add(this.lblCustomerList);
            this.TreePanel.Controls.Add(this.cboRegionList);
            this.TreePanel.Controls.Add(this.lblRegionList);
            this.TreePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.TreePanel.Location = new System.Drawing.Point(0, 0);
            this.TreePanel.Name = "TreePanel";
            this.TreePanel.Size = new System.Drawing.Size(257, 397);
            this.TreePanel.TabIndex = 0;
            // 
            // cboCustomerList
            // 
            this.cboCustomerList.FormattingEnabled = true;
            this.cboCustomerList.Location = new System.Drawing.Point(40, 223);
            this.cboCustomerList.Name = "cboCustomerList";
            this.cboCustomerList.Size = new System.Drawing.Size(181, 21);
            this.cboCustomerList.TabIndex = 3;
            this.cboCustomerList.SelectedIndexChanged += new System.EventHandler(this.cboCustomerList_SelectedIndexChanged);
            // 
            // lblCustomerList
            // 
            this.lblCustomerList.AutoSize = true;
            this.lblCustomerList.Location = new System.Drawing.Point(37, 180);
            this.lblCustomerList.Name = "lblCustomerList";
            this.lblCustomerList.Size = new System.Drawing.Size(70, 13);
            this.lblCustomerList.TabIndex = 2;
            this.lblCustomerList.Text = "Customer List";
            // 
            // cboRegionList
            // 
            this.cboRegionList.FormattingEnabled = true;
            this.cboRegionList.Location = new System.Drawing.Point(37, 111);
            this.cboRegionList.Name = "cboRegionList";
            this.cboRegionList.Size = new System.Drawing.Size(184, 21);
            this.cboRegionList.TabIndex = 1;
            this.cboRegionList.SelectedIndexChanged += new System.EventHandler(this.cboRegion_SelectedIndexChanged);
            // 
            // lblRegionList
            // 
            this.lblRegionList.AutoSize = true;
            this.lblRegionList.Location = new System.Drawing.Point(34, 80);
            this.lblRegionList.Name = "lblRegionList";
            this.lblRegionList.Size = new System.Drawing.Size(60, 13);
            this.lblRegionList.TabIndex = 0;
            this.lblRegionList.Text = "Region List";
            // 
            // ResultPanel
            // 
            this.ResultPanel.Controls.Add(this.gridorderHistory);
            this.ResultPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.ResultPanel.Location = new System.Drawing.Point(263, 0);
            this.ResultPanel.Name = "ResultPanel";
            this.ResultPanel.Size = new System.Drawing.Size(471, 397);
            this.ResultPanel.TabIndex = 1;
            // 
            // gridorderHistory
            // 
            this.gridorderHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridorderHistory.Location = new System.Drawing.Point(15, 80);
            this.gridorderHistory.Name = "gridorderHistory";
            this.gridorderHistory.Size = new System.Drawing.Size(444, 181);
            this.gridorderHistory.TabIndex = 0;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 397);
            this.Controls.Add(this.ResultPanel);
            this.Controls.Add(this.TreePanel);
            this.Name = "MainView";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.MainView_Load);
            this.TreePanel.ResumeLayout(false);
            this.TreePanel.PerformLayout();
            this.ResultPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridorderHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TreePanel;
        private System.Windows.Forms.ComboBox cboCustomerList;
        private System.Windows.Forms.Label lblCustomerList;
        private System.Windows.Forms.ComboBox cboRegionList;
        private System.Windows.Forms.Label lblRegionList;
        private System.Windows.Forms.Panel ResultPanel;
        private System.Windows.Forms.DataGridView gridorderHistory;
    }
}

