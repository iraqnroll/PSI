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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend9 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.FrequentShopPieChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.FrequentlyBoughItemsPieChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.MoneySpentPanel = new System.Windows.Forms.Panel();
            this.ShoppingPerMonthChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.MonthChartListView = new System.Windows.Forms.ListView();
            this.MonthSelect = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.FrequentShopPieChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FrequentlyBoughItemsPieChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShoppingPerMonthChart)).BeginInit();
            this.SuspendLayout();
            // 
            // FrequentShopPieChart
            // 
            chartArea7.Name = "ChartArea1";
            this.FrequentShopPieChart.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            this.FrequentShopPieChart.Legends.Add(legend7);
            this.FrequentShopPieChart.Location = new System.Drawing.Point(12, 32);
            this.FrequentShopPieChart.Name = "FrequentShopPieChart";
            series7.ChartArea = "ChartArea1";
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            this.FrequentShopPieChart.Series.Add(series7);
            this.FrequentShopPieChart.Size = new System.Drawing.Size(359, 211);
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
            chartArea8.Name = "ChartArea1";
            this.FrequentlyBoughItemsPieChart.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            this.FrequentlyBoughItemsPieChart.Legends.Add(legend8);
            this.FrequentlyBoughItemsPieChart.Location = new System.Drawing.Point(685, 32);
            this.FrequentlyBoughItemsPieChart.Name = "FrequentlyBoughItemsPieChart";
            series8.ChartArea = "ChartArea1";
            series8.Legend = "Legend1";
            series8.Name = "Series1";
            this.FrequentlyBoughItemsPieChart.Series.Add(series8);
            this.FrequentlyBoughItemsPieChart.Size = new System.Drawing.Size(379, 211);
            this.FrequentlyBoughItemsPieChart.TabIndex = 1;
            this.FrequentlyBoughItemsPieChart.Text = "chart1";
            // 
            // MoneySpentPanel
            // 
            this.MoneySpentPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MoneySpentPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoneySpentPanel.Location = new System.Drawing.Point(388, 32);
            this.MoneySpentPanel.Name = "MoneySpentPanel";
            this.MoneySpentPanel.Size = new System.Drawing.Size(291, 211);
            this.MoneySpentPanel.TabIndex = 2;
            // 
            // ShoppingPerMonthChart
            // 
            chartArea9.Name = "ChartArea1";
            this.ShoppingPerMonthChart.ChartAreas.Add(chartArea9);
            legend9.Enabled = false;
            legend9.Name = "Legend1";
            this.ShoppingPerMonthChart.Legends.Add(legend9);
            this.ShoppingPerMonthChart.Location = new System.Drawing.Point(291, 315);
            this.ShoppingPerMonthChart.Name = "ShoppingPerMonthChart";
            this.ShoppingPerMonthChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series9.IsVisibleInLegend = false;
            series9.Legend = "Legend1";
            series9.Name = "Series1";
            series9.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            this.ShoppingPerMonthChart.Series.Add(series9);
            this.ShoppingPerMonthChart.Size = new System.Drawing.Size(584, 297);
            this.ShoppingPerMonthChart.TabIndex = 3;
            this.ShoppingPerMonthChart.Text = "chart1";
            this.ShoppingPerMonthChart.CursorPositionChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.CursorEventArgs>(this.ShoppingPerMonthChart_CursorPositionChanged);
            // 
            // MonthChartListView
            // 
            this.MonthChartListView.AutoArrange = false;
            this.MonthChartListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MonthChartListView.GridLines = true;
            this.MonthChartListView.HideSelection = false;
            this.MonthChartListView.LabelWrap = false;
            this.MonthChartListView.Location = new System.Drawing.Point(882, 313);
            this.MonthChartListView.Name = "MonthChartListView";
            this.MonthChartListView.Size = new System.Drawing.Size(129, 86);
            this.MonthChartListView.TabIndex = 4;
            this.MonthChartListView.UseCompatibleStateImageBehavior = false;
            // 
            // MonthSelect
            // 
            this.MonthSelect.FormattingEnabled = true;
            this.MonthSelect.Location = new System.Drawing.Point(881, 425);
            this.MonthSelect.Name = "MonthSelect";
            this.MonthSelect.Size = new System.Drawing.Size(90, 21);
            this.MonthSelect.TabIndex = 5;
            this.MonthSelect.SelectedIndexChanged += new System.EventHandler(this.MonthSelect_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(449, 286);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Shopping frequency per month :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(81, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Most frequently visited shops :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(750, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(221, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Top 5 most frequently bought items :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(388, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Money spent :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(881, 409);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Month:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(881, 297);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Shops visited :";
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 612);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MonthSelect);
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
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart FrequentShopPieChart;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.DataVisualization.Charting.Chart FrequentlyBoughItemsPieChart;
        private System.Windows.Forms.Panel MoneySpentPanel;
        private System.Windows.Forms.DataVisualization.Charting.Chart ShoppingPerMonthChart;
        private System.Windows.Forms.ListView MonthChartListView;
        private System.Windows.Forms.ComboBox MonthSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}