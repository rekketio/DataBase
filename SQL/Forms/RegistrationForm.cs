using System;
using System.Windows.Forms;
using SQL_Project.SQL.Scripts;

namespace SQL_Project.SQL.Forms
{
	public partial class RegistrationForm : Form
	{
        private DataBaseInteraction db = new DataBaseInteraction();
		public RegistrationForm()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			db.CreateAccount(textBox1.Text, textBox2.Text);
		}
    }
}
