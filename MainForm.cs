using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase1
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

        private void button2_Click(object sender, EventArgs e)
        {
			SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\rekketio\source\repos\WindowsFormsApp2\Accounts.mdf;Integrated Security=True");
			connection.Open();
			string commandText = "INSERT INTO Cars (manyfactory, model, releaseyear, carbody, hp) VALUES (@mf, @model, @ry, @cb, @hp)";
			SqlCommand command = new SqlCommand(commandText, connection);

			command.Parameters.Add("@mf", SqlDbType.NVarChar);
			command.Parameters["@mf"].Value = textBox2.Text;
			command.Parameters.Add("@model", SqlDbType.NVarChar);
			command.Parameters["@model"].Value = textBox3.Text;
			command.Parameters.Add("@ry", SqlDbType.Int);
			command.Parameters["@ry"].Value = Convert.ToInt32(textBox4.Text);
			command.Parameters.Add("@cb", SqlDbType.NVarChar);
			command.Parameters["@cb"].Value = textBox5.Text;
			command.Parameters.Add("@hp", SqlDbType.Int);
			command.Parameters["@hp"].Value = Convert.ToInt32(textBox6.Text);

			command.ExecuteNonQuery();
			connection.Close();
		}

        private void button1_Click(object sender, EventArgs e)
        {
#if DEBUG
			string workingDirecrory = Environment.CurrentDirectory;
			string path = Directory.GetParent(workingDirecrory).Parent.FullName;
			AppDomain.CurrentDomain.SetData("DataDirectory", path);
#endif

#if !DEBUG
			string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
			string path = Path.GetDirectoryName(executable);
			AppDomain.CurrentDomain.SetData("DataDirectory", path);

			
#endif
		}

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
			Application.Exit();
        }

        private void carsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.carsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.accountsDataSet);

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "accountsDataSet.Cars". При необходимости она может быть перемещена или удалена.
            this.carsTableAdapter.Fill(this.accountsDataSet.Cars);

        }
    }
}
