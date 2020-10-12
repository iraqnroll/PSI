
namespace PSIShoppingEngine.UI
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
            this.HistoryButton = new System.Windows.Forms.Button();
            this.OptionsButton = new System.Windows.Forms.Button();
            this.ScanButton = new System.Windows.Forms.Button();
            this.panelChild = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.HistoryButton);
            this.panel1.Controls.Add(this.OptionsButton);
            this.panel1.Controls.Add(this.ScanButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 70);
            this.panel1.TabIndex = 0;
            // 
            // HistoryButton
            // 
            this.HistoryButton.BackColor = System.Drawing.Color.White;
            this.HistoryButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HistoryButton.FlatAppearance.BorderSize = 0;
            this.HistoryButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.HistoryButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.HistoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HistoryButton.Font = new System.Drawing.Font("AXIS Extra Bold", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HistoryButton.Location = new System.Drawing.Point(260, 0);
            this.HistoryButton.Name = "HistoryButton";
            this.HistoryButton.Size = new System.Drawing.Size(280, 70);
            this.HistoryButton.TabIndex = 2;
            this.HistoryButton.Text = "HISTORY";
            this.HistoryButton.UseVisualStyleBackColor = false;
            this.HistoryButton.Click += new System.EventHandler(this.HistoryButton_Click);
            // 
            // OptionsButton
            // 
            this.OptionsButton.BackColor = System.Drawing.Color.White;
            this.OptionsButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.OptionsButton.FlatAppearance.BorderSize = 0;
            this.OptionsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(51)))));
            this.OptionsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(51)))));
            this.OptionsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OptionsButton.Font = new System.Drawing.Font("AXIS Extra Bold", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OptionsButton.Location = new System.Drawing.Point(540, 0);
            this.OptionsButton.Name = "OptionsButton";
            this.OptionsButton.Size = new System.Drawing.Size(260, 70);
            this.OptionsButton.TabIndex = 1;
            this.OptionsButton.Text = "OPTIONS";
            this.OptionsButton.UseVisualStyleBackColor = false;
            this.OptionsButton.Click += new System.EventHandler(this.OptionsButton_Click);
            // 
            // ScanButton
            // 
            this.ScanButton.BackColor = System.Drawing.Color.White;
            this.ScanButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.ScanButton.FlatAppearance.BorderSize = 0;
            this.ScanButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(12)))), ((int)(((byte)(62)))));
            this.ScanButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(12)))), ((int)(((byte)(62)))));
            this.ScanButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ScanButton.Font = new System.Drawing.Font("AXIS Extra Bold", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScanButton.Location = new System.Drawing.Point(0, 0);
            this.ScanButton.Name = "ScanButton";
            this.ScanButton.Size = new System.Drawing.Size(260, 70);
            this.ScanButton.TabIndex = 0;
            this.ScanButton.Text = "SCAN";
            this.ScanButton.UseVisualStyleBackColor = false;
            this.ScanButton.Click += new System.EventHandler(this.ScanButton_Click);
            // 
            // panelChild
            // 
            this.panelChild.BackColor = System.Drawing.Color.White;
            this.panelChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChild.Location = new System.Drawing.Point(0, 70);
            this.panelChild.Name = "panelChild";
            this.panelChild.Size = new System.Drawing.Size(800, 380);
            this.panelChild.TabIndex = 1;
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelChild);
            this.Controls.Add(this.panel1);
            this.Name = "MainMenuForm";
            this.Text = "MainMenuForm";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button HistoryButton;
        private System.Windows.Forms.Button OptionsButton;
        private System.Windows.Forms.Button ScanButton;
        private System.Windows.Forms.Panel panelChild;
    }
}