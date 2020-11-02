
namespace PSIShoppingEngine.Forms
{
    partial class MainMenuForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ProfileButton = new System.Windows.Forms.Button();
            this.PriceChanges = new System.Windows.Forms.Button();
            this.UserButton = new System.Windows.Forms.Button();
            this.ShoppingCartButton = new System.Windows.Forms.Button();
            this.NewReceiptButton = new System.Windows.Forms.Button();
            this.panelChild = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ProfileButton);
            this.panel1.Controls.Add(this.PriceChanges);
            this.panel1.Controls.Add(this.UserButton);
            this.panel1.Controls.Add(this.ShoppingCartButton);
            this.panel1.Controls.Add(this.NewReceiptButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1186, 46);
            this.panel1.TabIndex = 0;
            // 
            // ProfileButton
            // 
            this.ProfileButton.BackColor = System.Drawing.Color.White;
            this.ProfileButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProfileButton.FlatAppearance.BorderSize = 0;
            this.ProfileButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(39)))), ((int)(((byte)(122)))));
            this.ProfileButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(39)))), ((int)(((byte)(122)))));
            this.ProfileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProfileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfileButton.Location = new System.Drawing.Point(900, 0);
            this.ProfileButton.Name = "ProfileButton";
            this.ProfileButton.Size = new System.Drawing.Size(286, 46);
            this.ProfileButton.TabIndex = 6;
            this.ProfileButton.Text = "PROFILE";
            this.ProfileButton.UseVisualStyleBackColor = false;
            this.ProfileButton.Click += new System.EventHandler(this.ProfileButton_Click);
            // 
            // PriceChanges
            // 
            this.PriceChanges.AutoSize = true;
            this.PriceChanges.BackColor = System.Drawing.Color.White;
            this.PriceChanges.Dock = System.Windows.Forms.DockStyle.Left;
            this.PriceChanges.FlatAppearance.BorderSize = 0;
            this.PriceChanges.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(39)))), ((int)(((byte)(122)))));
            this.PriceChanges.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(39)))), ((int)(((byte)(122)))));
            this.PriceChanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PriceChanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PriceChanges.Location = new System.Drawing.Point(675, 0);
            this.PriceChanges.Name = "PriceChanges";
            this.PriceChanges.Size = new System.Drawing.Size(225, 46);
            this.PriceChanges.TabIndex = 5;
            this.PriceChanges.Text = "PRICE CHANGES";
            this.PriceChanges.UseVisualStyleBackColor = false;
            this.PriceChanges.Click += new System.EventHandler(this.PriceChanges_Click);
            // 
            // UserButton
            // 
            this.UserButton.BackColor = System.Drawing.Color.White;
            this.UserButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.UserButton.FlatAppearance.BorderSize = 0;
            this.UserButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(57)))), ((int)(((byte)(178)))));
            this.UserButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(57)))), ((int)(((byte)(178)))));
            this.UserButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UserButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserButton.Location = new System.Drawing.Point(450, 0);
            this.UserButton.Name = "UserButton";
            this.UserButton.Size = new System.Drawing.Size(225, 46);
            this.UserButton.TabIndex = 3;
            this.UserButton.Text = "USER";
            this.UserButton.UseVisualStyleBackColor = false;
            this.UserButton.Click += new System.EventHandler(this.UserButton_Click);
            // 
            // ShoppingCartButton
            // 
            this.ShoppingCartButton.AutoSize = true;
            this.ShoppingCartButton.BackColor = System.Drawing.Color.White;
            this.ShoppingCartButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.ShoppingCartButton.FlatAppearance.BorderSize = 0;
            this.ShoppingCartButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(69)))), ((int)(((byte)(216)))));
            this.ShoppingCartButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(69)))), ((int)(((byte)(216)))));
            this.ShoppingCartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShoppingCartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShoppingCartButton.Location = new System.Drawing.Point(225, 0);
            this.ShoppingCartButton.Name = "ShoppingCartButton";
            this.ShoppingCartButton.Size = new System.Drawing.Size(225, 46);
            this.ShoppingCartButton.TabIndex = 2;
            this.ShoppingCartButton.Text = "SHOPPING CART";
            this.ShoppingCartButton.UseVisualStyleBackColor = false;
            this.ShoppingCartButton.Click += new System.EventHandler(this.ShoppingCartButton_Click);
            // 
            // NewReceiptButton
            // 
            this.NewReceiptButton.BackColor = System.Drawing.Color.White;
            this.NewReceiptButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.NewReceiptButton.FlatAppearance.BorderSize = 0;
            this.NewReceiptButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.NewReceiptButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.NewReceiptButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewReceiptButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewReceiptButton.Location = new System.Drawing.Point(0, 0);
            this.NewReceiptButton.Name = "NewReceiptButton";
            this.NewReceiptButton.Size = new System.Drawing.Size(225, 46);
            this.NewReceiptButton.TabIndex = 0;
            this.NewReceiptButton.Text = "NEW RECEiPT";
            this.NewReceiptButton.UseVisualStyleBackColor = false;
            this.NewReceiptButton.Click += new System.EventHandler(this.NewReceiptButton_Click);
            // 
            // panelChild
            // 
            this.panelChild.BackColor = System.Drawing.Color.White;
            this.panelChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChild.Location = new System.Drawing.Point(0, 46);
            this.panelChild.Name = "panelChild";
            this.panelChild.Size = new System.Drawing.Size(1186, 647);
            this.panelChild.TabIndex = 1;
            this.panelChild.Paint += new System.Windows.Forms.PaintEventHandler(this.panelChild_Paint);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 693);
            this.Controls.Add(this.panelChild);
            this.Controls.Add(this.panel1);
            this.Name = "MainMenuForm";
            this.Text = "MainMenuForm";
            this.Load += new System.EventHandler(this.MainMenuForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button NewReceiptButton;
        private System.Windows.Forms.Panel panelChild;
        private System.Windows.Forms.Button UserButton;
        private System.Windows.Forms.Button ShoppingCartButton;
        private System.Windows.Forms.Button ProfileButton;
        private System.Windows.Forms.Button PriceChanges;
    }
}