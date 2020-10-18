namespace PSIShoppingEngine
{
    partial class Form1
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stripStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnAddManually = new System.Windows.Forms.Button();
            this.btnAddOCR = new System.Windows.Forms.Button();
            this.receiptListGridView = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.selectedReceiptGridView = new System.Windows.Forms.DataGridView();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.receiptListGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedReceiptGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 456);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(686, 22);
            this.statusStrip1.TabIndex = 8;
            // 
            // stripStatus
            // 
            this.stripStatus.Name = "stripStatus";
            this.stripStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // btnAddManually
            // 
            this.btnAddManually.Location = new System.Drawing.Point(13, 418);
            this.btnAddManually.Name = "btnAddManually";
            this.btnAddManually.Size = new System.Drawing.Size(61, 35);
            this.btnAddManually.TabIndex = 9;
            this.btnAddManually.Text = "Add Manually";
            this.btnAddManually.UseVisualStyleBackColor = true;
            this.btnAddManually.Click += new System.EventHandler(this.btnAddManually_Click_1);
            // 
            // btnAddOCR
            // 
            this.btnAddOCR.Location = new System.Drawing.Point(80, 418);
            this.btnAddOCR.Name = "btnAddOCR";
            this.btnAddOCR.Size = new System.Drawing.Size(75, 35);
            this.btnAddOCR.TabIndex = 10;
            this.btnAddOCR.Text = "Add with OCR";
            this.btnAddOCR.UseVisualStyleBackColor = true;
            this.btnAddOCR.Click += new System.EventHandler(this.btnAddOCR_Click_1);
            // 
            // receiptListGridView
            // 
            this.receiptListGridView.AllowUserToAddRows = false;
            this.receiptListGridView.AllowUserToDeleteRows = false;
            this.receiptListGridView.AllowUserToResizeColumns = false;
            this.receiptListGridView.AllowUserToResizeRows = false;
            this.receiptListGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.receiptListGridView.Location = new System.Drawing.Point(13, 12);
            this.receiptListGridView.MultiSelect = false;
            this.receiptListGridView.Name = "receiptListGridView";
            this.receiptListGridView.ReadOnly = true;
            this.receiptListGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.receiptListGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.receiptListGridView.Size = new System.Drawing.Size(240, 392);
            this.receiptListGridView.TabIndex = 11;
            this.receiptListGridView.SelectionChanged += new System.EventHandler(this.selectedRowsButton_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(161, 418);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(61, 35);
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // selectedReceiptGridView
            // 
            this.selectedReceiptGridView.AllowUserToAddRows = false;
            this.selectedReceiptGridView.AllowUserToDeleteRows = false;
            this.selectedReceiptGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.selectedReceiptGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemName,
            this.ItemPrice,
            this.ItemType});
            this.selectedReceiptGridView.Location = new System.Drawing.Point(270, 12);
            this.selectedReceiptGridView.Name = "selectedReceiptGridView";
            this.selectedReceiptGridView.ReadOnly = true;
            this.selectedReceiptGridView.Size = new System.Drawing.Size(404, 392);
            this.selectedReceiptGridView.TabIndex = 13;
            // 
            // ItemName
            // 
            this.ItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemName.HeaderText = "Item Name";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            // 
            // ItemPrice
            // 
            this.ItemPrice.HeaderText = "Item Price";
            this.ItemPrice.Name = "ItemPrice";
            this.ItemPrice.ReadOnly = true;
            // 
            // ItemType
            // 
            this.ItemType.HeaderText = "Item Type";
            this.ItemType.Name = "ItemType";
            this.ItemType.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 478);
            this.Controls.Add(this.selectedReceiptGridView);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.receiptListGridView);
            this.Controls.Add(this.btnAddOCR);
            this.Controls.Add(this.btnAddManually);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.receiptListGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedReceiptGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel stripStatus;
        private System.Windows.Forms.Button btnAddManually;
        private System.Windows.Forms.Button btnAddOCR;
        private System.Windows.Forms.DataGridView receiptListGridView;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView selectedReceiptGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemType;
    }
}

