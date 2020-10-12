using PSIShoppingEngine.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSIShoppingEngine.Forms
{
    public partial class MainMenuForm : Form
    {
        private Form currentForm = null;
        private Button currentBtn;

        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void openChildForm(Form child, Color color)
        {
            if (currentForm != null)
            {
                currentForm.Close(); // Closes previous open form
            }
            currentForm = child;
            currentForm.TopLevel = false;
            currentForm.FormBorderStyle = FormBorderStyle.None;
            currentForm.Dock = DockStyle.Fill;
            currentForm.BackColor = color;
            panelChild.Controls.Add(currentForm);
            panelChild.Tag = currentForm;
            
            currentForm.BringToFront();
            currentForm.Show();
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.White;
                currentBtn.ForeColor = Color.Black;
            }
        }


        private void ScanButton_Click(object sender, EventArgs e)
        {
            Color color = Color.FromArgb(144, 12, 62);
            activateButton(sender, color);
            openChildForm(new Form1(), color);
        }
        private void activateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                currentBtn = (Button)senderBtn;
                currentBtn.BackColor = color;
                currentBtn.ForeColor = Color.White;
              
            }
        }

        private void HistoryButton_Click(object sender, EventArgs e)
        {
            Color color = Color.FromArgb(199, 0, 57);
            activateButton(sender, color);
            openChildForm(new HistoryForm(), color);
        }

        private void OptionsButton_Click(object sender, EventArgs e)
        {
            Color color = Color.FromArgb(255, 87, 51);
            activateButton(sender, color);
            openChildForm(new OptionsForm(), color);

        }
    }
}
