using System.Windows.Forms.DataVisualization.Charting;

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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.FrequentShopPieChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.FrequentlyBoughItemsPieChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.MoneySpentPanel = new System.Windows.Forms.Panel();
            this.ShoppingPerMonthChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.MonthChartListView = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.FrequentShopPieChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrequentlyBoughItemsPieChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShoppingPerMonthChart)).BeginInit();
            this.SuspendLayout();
            // 
            // FrequentShopPieChart
            // 
            chartArea1.Name = "ChartArea1";
            this.FrequentShopPieChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.FrequentShopPieChart.Legends.Add(legend1);
            this.FrequentShopPieChart.Location = new System.Drawing.Point(24, 21);
            this.FrequentShopPieChart.Name = "FrequentShopPieChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.FrequentShopPieChart.Series.Add(series1);
            this.FrequentShopPieChart.Size = new System.Drawing.Size(347, 202);
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
            chartArea2.Name = "ChartArea1";
            this.FrequentlyBoughItemsPieChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.FrequentlyBoughItemsPieChart.Legends.Add(legend2);
            this.FrequentlyBoughItemsPieChart.Location = new System.Drawing.Point(543, 12);
            this.FrequentlyBoughItemsPieChart.Name = "FrequentlyBoughItemsPieChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.FrequentlyBoughItemsPieChart.Series.Add(series2);
            this.FrequentlyBoughItemsPieChart.Size = new System.Drawing.Size(379, 211);
            this.FrequentlyBoughItemsPieChart.TabIndex = 1;
            this.FrequentlyBoughItemsPieChart.Text = "chart1";
            // 
            // MoneySpentPanel
            // 
            this.MoneySpentPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MoneySpentPanel.Location = new System.Drawing.Point(24, 316);
            this.MoneySpentPanel.Name = "MoneySpentPanel";
            this.MoneySpentPanel.Size = new System.Drawing.Size(291, 220);
            this.MoneySpentPanel.TabIndex = 2;
            // 
            // ShoppingPerMonthChart
            // 
            chartArea3.Name = "ChartArea1";
            this.ShoppingPerMonthChart.ChartAreas.Add(chartArea3);
            legend3.Enabled = false;
            legend3.Name = "Legend1";
            this.ShoppingPerMonthChart.Legends.Add(legend3);
            this.ShoppingPerMonthChart.Location = new System.Drawing.Point(442, 263);
            this.ShoppingPerMonthChart.Name = "ShoppingPerMonthChart";
            this.ShoppingPerMonthChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.IsVisibleInLegend = false;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            series3.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            this.ShoppingPerMonthChart.Series.Add(series3);
            this.ShoppingPerMonthChart.Size = new System.Drawing.Size(480, 273);
            this.ShoppingPerMonthChart.TabIndex = 3;
            this.ShoppingPerMonthChart.Text = "chart1";
            this.ShoppingPerMonthChart.CursorPositionChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.CursorEventArgs>(this.ShoppingPerMonthChart_CursorPositionChanged);
            this.ShoppingPerMonthChart.Click += new System.EventHandler(this.ShoppingPerMonthChart_Click);
            // 
            // MonthChartListView
            // 
            this.MonthChartListView.HideSelection = false;
            this.MonthChartListView.Location = new System.Drawing.Point(928, 263);
            this.MonthChartListView.Name = "MonthChartListView";
            this.MonthChartListView.Size = new System.Drawing.Size(89, 147);
            this.MonthChartListView.TabIndex = 4;
            this.MonthChartListView.UseCompatibleStateImageBehavior = false;
            this.MonthChartListView.SelectedIndexChanged += new System.EventHandler(this.MonthChartListView_SelectedIndexChanged);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 564);
            this.Controls.Add(this.MonthChartListView);
            this.Controls.Add(this.ShoppingPerMonthChart);
            this.Controls.Add(this.MoneySpentPanel);
            this.Controls.Add(this.FrequentlyBoughItemsPieChart);
            this.Controls.Add(this.FrequentShopPieChart);
            this.Name = "UserForm";
            this.Text = "UserForm";
            this.Load += new System.EventHandler(this.UserForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FrequentShopPieChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrequentlyBoughItemsPieChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShoppingPerMonthChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart FrequentShopPieChart;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.DataVisualization.Charting.Chart FrequentlyBoughItemsPieChart;
        private System.Windows.Forms.Panel MoneySpentPanel;
        private System.Windows.Forms.DataVisualization.Charting.Chart ShoppingPerMonthChart;
        private System.Windows.Forms.ListView MonthChartListView;
    }
}