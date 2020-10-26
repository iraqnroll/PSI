namespace PSIShoppingEngine.Forms
{
    partial class UserForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.FrequentShopPieChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.FrequentlyBoughItemsPieChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.MoneySpentPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.FrequentShopPieChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrequentlyBoughItemsPieChart)).BeginInit();
            this.SuspendLayout();
            // 
            // FrequentShopPieChart
            // 
            chartArea5.Name = "ChartArea1";
            this.FrequentShopPieChart.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.FrequentShopPieChart.Legends.Add(legend5);
            this.FrequentShopPieChart.Location = new System.Drawing.Point(24, 21);
            this.FrequentShopPieChart.Name = "FrequentShopPieChart";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.FrequentShopPieChart.Series.Add(series5);
            this.FrequentShopPieChart.Size = new System.Drawing.Size(311, 208);
            this.FrequentShopPieChart.TabIndex = 0;
            this.FrequentShopPieChart.Text = "chart1";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // FrequentlyBoughItemsPieChart
            // 
            chartArea6.Name = "ChartArea1";
            this.FrequentlyBoughItemsPieChart.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.FrequentlyBoughItemsPieChart.Legends.Add(legend6);
            this.FrequentlyBoughItemsPieChart.Location = new System.Drawing.Point(462, 21);
            this.FrequentlyBoughItemsPieChart.Name = "FrequentlyBoughItemsPieChart";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.FrequentlyBoughItemsPieChart.Series.Add(series6);
            this.FrequentlyBoughItemsPieChart.Size = new System.Drawing.Size(311, 208);
            this.FrequentlyBoughItemsPieChart.TabIndex = 1;
            this.FrequentlyBoughItemsPieChart.Text = "chart1";
            // 
            // MoneySpentPanel
            // 
            this.MoneySpentPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MoneySpentPanel.Location = new System.Drawing.Point(24, 248);
            this.MoneySpentPanel.Name = "MoneySpentPanel";
            this.MoneySpentPanel.Size = new System.Drawing.Size(234, 190);
            this.MoneySpentPanel.TabIndex = 2;
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MoneySpentPanel);
            this.Controls.Add(this.FrequentlyBoughItemsPieChart);
            this.Controls.Add(this.FrequentShopPieChart);
            this.Name = "UserForm";
            this.Text = "UserForm";
            this.Load += new System.EventHandler(this.UserForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FrequentShopPieChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrequentlyBoughItemsPieChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart FrequentShopPieChart;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.DataVisualization.Charting.Chart FrequentlyBoughItemsPieChart;
        private System.Windows.Forms.Panel MoneySpentPanel;
    }
}