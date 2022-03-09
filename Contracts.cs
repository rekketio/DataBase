using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBase1;

namespace WindowsFormsApp2
{
    public partial class Contracts : Form
    {
        bool needToClose = true;
        public Contracts()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
			SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rekketio\source\repos\WindowsFormsApp2\Accounts.mdf;Integrated Security=True");
			connection.Open();
			string commandText = "INSERT INTO Contracts (autoid, begin_date, contract_long, cost, return_date, notes) VALUES (@autoid, @bd, @cl, @cost, @rd, @notes)";
			SqlCommand command = new SqlCommand(commandText, connection);

			command.Parameters.Add("@autoid", SqlDbType.NChar);
			command.Parameters.Add("@bd", SqlDbType.Date);
			command.Parameters.Add("@cl", SqlDbType.Int);
			command.Parameters.Add("@cost", SqlDbType.Money);
			command.Parameters.Add("@rd", SqlDbType.Date);
			command.Parameters.Add("@notes", SqlDbType.NVarChar);

			command.Parameters["@autoid"].Value = textBox3.Text;
			command.Parameters["@bd"].Value = DateTime.Parse(textBox2.Text);
			command.Parameters["@cl"].Value = textBox3.Text;
			command.Parameters["@cost"].Value = Convert.ToInt32(textBox4.Text);
			command.Parameters["@rd"].Value = DateTime.Parse(textBox5.Text);
			command.Parameters["@notes"].Value = textBox6.Text;

			command.ExecuteNonQuery();
			connection.Close();
		}

        private void contractsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.contractsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.contractsDataSet);

        }

        private void Contracts_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "contractsDataSet.Contracts". При необходимости она может быть перемещена или удалена.
            this.contractsTableAdapter.Fill(this.contractsDataSet.Contracts);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainForm form = new MainForm();
            form.Show();
            needToClose = false;
            this.Close();
        }

        private void Contracts_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (needToClose)
                Application.Exit();
        }
    }
}
