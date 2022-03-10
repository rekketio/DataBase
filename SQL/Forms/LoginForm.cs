using System;
using System.Windows.Forms;
using WindowsFormsApp2.SQL.Scripts;

namespace WindowsFormsApp2.SQL.Forms
{
	public partial class LoginForm : Form
	{
		private DataBaseInteraction db;
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
			
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (db.Login(textBox1.Text, textBox2.Text))
			{
				MainForm form = new MainForm();
				form.Show();
				this.Close();
			}
			else
			{
				label3.Text = "Неверный логин или пароль";
			}
		}

        private void LoginForm_Load(object sender, EventArgs e)
        {
			db = new DataBaseInteraction();
		}
    }
}
