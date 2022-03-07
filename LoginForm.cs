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
	public partial class LoginForm : Form
	{
		bool isLoginSuccessfull = false;
		public LoginForm()
		{
			InitializeComponent();
		}

		private void label4_Click(object sender, EventArgs e)
		{
			RegistrationForm form = new RegistrationForm();
			form.Show();
		}

		private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!isLoginSuccessfull)
				Application.Exit();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\AutoShow.mdf;Integrated Security=True");
			connection.Open();

			string commandText = $"SELECT password FROM Accounts WHERE login = @login";

			SqlCommand command = new SqlCommand(commandText, connection);
			command.Parameters.Add("@login", SqlDbType.VarChar);
			command.Parameters["@login"].Value = textBox1.Text;
			byte[] hashedPassword;
			using(SqlDataReader reader = command.ExecuteReader())
			{
				if (reader.Read())
				{
					hashedPassword = (byte[])reader.GetValue(0);
					byte[] salt = new byte[16];
					Array.Copy(hashedPassword, 0, salt, 0, 16);
					var pbkdf2 = new Rfc2898DeriveBytes(textBox2.Text, salt, 100000);
					byte[] hash = pbkdf2.GetBytes(20);
					for (int i = 0; i < 20; i++)
						if (hashedPassword[i+16] != hash[i])
						{
							MessageBox.Show("Неверный логин или пароль", "Авторизация не пройдена", MessageBoxButtons.OK, MessageBoxIcon.Error);
							connection.Close();
							return;
						}
					MainForm form = new MainForm();
					form.Show();
					connection.Close();
					isLoginSuccessfull = true;
					this.Close();
				} 
				else
				{
					label3.Text = "Неверный логин или пароль";
				}
			}

			connection.Close();
		}
	}
}
