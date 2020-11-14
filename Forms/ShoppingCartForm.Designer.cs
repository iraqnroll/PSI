namespace PSIShoppingEngine.Forms
{
    partial class ShoppingCartForm
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
            this.components = new System.ComponentModel.Container();
            this.ReceiptDataGrid = new System.Windows.Forms.DataGridView();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSaveReceipt = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.itemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ReceiptDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ReceiptDataGrid
            // 
            this.ReceiptDataGrid.AllowUserToAddRows = false;
            this.ReceiptDataGrid.AllowUserToOrderColumns = true;
            this.ReceiptDataGrid.AllowUserToResizeColumns = false;
            this.ReceiptDataGrid.AllowUserToResizeRows = false;
            this.ReceiptDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ReceiptDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemName});
            this.ReceiptDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.ReceiptDataGrid.Location = new System.Drawing.Point(12, 22);
            this.ReceiptDataGrid.Name = "ReceiptDataGrid";
            this.ReceiptDataGrid.Size = new System.Drawing.Size(626, 294);
            this.ReceiptDataGrid.TabIndex = 0;
            this.ReceiptDataGrid.CurrentCellDirtyStateChanged += new System.EventHandler(this.ReceiptDataGrid_CurrentCellDirtyStateChanged);
            // 
            // ItemName
            // 
            this.ItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemName.HeaderText = "Item Name";
            this.ItemName.Name = "ItemName";
            // 
            // btnSaveReceipt
            // 
            this.btnSaveReceipt.Location = new System.Drawing.Point(12, 415);
            this.btnSaveReceipt.Name = "btnSaveReceipt";
            this.btnSaveReceipt.Size = new System.Drawing.Size(75, 23);
            this.btnSaveReceipt.TabIndex = 1;
            this.btnSaveReceipt.Text = "Save";
            this.btnSaveReceipt.UseVisualStyleBackColor = true;
            this.btnSaveReceipt.Click += new System.EventHandler(this.btnSaveReceipt_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 331);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Add Item";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // itemBindingSource
            // 
            this.itemBindingSource.DataSource = typeof(PSIShoppingEngine.Classes.Item);
            // 
            // ShoppingCartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSaveReceipt);
            this.Controls.Add(this.ReceiptDataGrid);
            this.Name = "ShoppingCartForm";
            this.Text = "New Receipt";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.NewReceipt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReceiptDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ReceiptDataGrid;
        private System.Windows.Forms.Button btnSaveReceipt;
        private System.Windows.Forms.BindingSource itemBindingSource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
    }
}