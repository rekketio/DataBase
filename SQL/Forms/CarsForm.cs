using System;
using System.Windows.Forms;
using WindowsFormsApp2.SQL.Scripts;

namespace WindowsFormsApp2.SQL.Forms
{
    public partial class CarsForm : Form
    {
        DataBaseInteraction db = new DataBaseInteraction();
        private bool needToExit = true;
        public CarsForm()
        {
            InitializeComponent();
        }

        private void carsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.carsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.accountsDataSet);

        }

        private void CarsForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "accountsDataSet.Cars". При необходимости она может быть перемещена или удалена.
            this.carsTableAdapter.Fill(this.accountsDataSet.Cars);

        }

        private void button1_Click(object sender, EventArgs e)
        {
           db.AddCar(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
           this.tableAdapterManager.UpdateAll(this.accountsDataSet);
        }

        private void CarsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (needToExit)
                Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainForm form = new MainForm();
            form.Show();
            needToExit = false;
            this.Close();
        }
    }
}
