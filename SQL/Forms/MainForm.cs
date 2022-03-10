using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp2.SQL.Forms
{
	public partial class MainForm : Form
	{
		private bool needToClose = true;
		public MainForm()
		{
			InitializeComponent();
		}

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
			if (needToClose)
				Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Data\AutoShow.mdf;Integrated Security=True");
            connection.Open();
            SqlCommand carscommand = new SqlCommand($"SELECT COUNT(*) FROM Cars", connection);
            SqlCommand contractscommand = new SqlCommand($"SELECT COUNT(*) FROM Contracts", connection);
            int carscount = (Int32)carscommand.ExecuteScalar();
            int contractscount = (Int32)contractscommand.ExecuteScalar();
            label1.Text = $"Всего записей в таблице Автомобили: {carscount}";
            label2.Text = $"Всего записей в таблице Контракты: {contractscount}";
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CarsForm form = new CarsForm();
            form.Show();
            needToClose = false;
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Contracts form = new Contracts();
            form.Show();
            needToClose = false;
            this.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            RegistrationForm form = new RegistrationForm();
            form.Show();
        }
    }
}
