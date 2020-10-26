
namespace PSIShoppingEngine.Forms
{
    partial class ShoppingCartInfoForm
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
            this.AddShoppingCart = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // AddShoppingCart
            // 
            this.AddShoppingCart.FlatAppearance.BorderSize = 0;
            this.AddShoppingCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddShoppingCart.Location = new System.Drawing.Point(47, 47);
            this.AddShoppingCart.Name = "AddShoppingCart";
            this.AddShoppingCart.Size = new System.Drawing.Size(149, 44);
            this.AddShoppingCart.TabIndex = 0;
            this.AddShoppingCart.Text = "Add a new shopping cart";
            this.AddShoppingCart.UseVisualStyleBackColor = true;
            this.AddShoppingCart.Click += new System.EventHandler(this.AddShoppingCart_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(121, 140);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGrid
            // 
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(363, 47);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(343, 190);
            this.dataGrid.TabIndex = 3;
            // 
            // ShoppingCartInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.AddShoppingCart);
            this.Name = "ShoppingCartInfoForm";
            this.Text = "ShoppingCartInfoForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddShoppingCart;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGrid;
    }
}