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


        private void    NewReceiptButton_Click(object sender, EventArgs e)
        {
            Color color = Color.FromArgb(0,120,255);
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

        private void ShoppingCartButton_Click(object sender, EventArgs e)
        {
            Color color = Color.FromArgb(0, 69, 216);
            activateButton(sender, color);
            openChildForm(new Form1(), color);

        }

        private void UserButton_Click(object sender, EventArgs e)
        {
            Color color = Color.FromArgb(1, 57, 178);
            activateButton(sender, color);
            Form UserForm = new UserForm();
            UserForm.Dock = DockStyle.Fill;
            openChildForm(UserForm, color);
        }

        private void PriceChanges_Click(object sender, EventArgs e)
        {
            Color color = Color.FromArgb(0, 39, 122);
            activateButton(sender, color);
            openChildForm(new Form1(), color);
        }

        private void ProfileButton_Click(object sender, EventArgs e)
        {
            Color color = Color.FromArgb(50, 39, 122);
            activateButton(sender, color);
            openChildForm(new Form1(), color);
        }

        private void panelChild_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {

        }
    }
}
