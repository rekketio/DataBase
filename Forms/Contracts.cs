using System;
using System.Windows.Forms;

namespace WindowsFormsApp2.Forms
{
    public partial class Contracts : Form
    {
        private bool needToClose = true;
        public Contracts()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainForm form = new MainForm();
            form.Show();
            needToClose = false;
            this.Close();
        }

        private void Contracts_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (needToClose)
                Application.Exit();
        }
    }
}
