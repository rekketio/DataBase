using System;
using System.Windows.Forms;
using SQL_Project.SQL.Scripts;

namespace SQL_Project.SQL.Forms
{
    public partial class Contracts : Form
    {
        DataBaseInteraction db = new DataBaseInteraction();
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

        private void button1_Click(object sender, EventArgs e)
        {
            db.AddContract(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
            this.tableAdapterManager.UpdateAll(this.contractsDataSet);
        }

        private void contractsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.contractsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.contractsDataSet);
        }

        private void Contracts_Load(object sender, EventArgs e)
        {
            this.contractsTableAdapter.Fill(this.contractsDataSet.Contracts);
        }
    }
}
