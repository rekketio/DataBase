using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase1
{
	public partial class RegistrationForm : Form
	{
		public RegistrationForm()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\AutoShow.mdf;Integrated Security=True");
			connection.Open();

            string commandText = $"INSERT INTO Accounts (login, password) VALUES (@login, @password)";

            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(textBox2.Text, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            SqlCommand command = new SqlCommand(commandText, connection);
            command.Parameters.Add("@login", SqlDbType.VarChar);
            command.Parameters["@login"].Value = textBox1.Text;
            command.Parameters.Add("@password", SqlDbType.Binary);
            command.Parameters["@password"].Value = hashBytes;
            command.ExecuteNonQuery();
			connection.Close();
		}
    }
}
