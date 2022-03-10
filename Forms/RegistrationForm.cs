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
using WindowsFormsApp2.Scripts;

namespace WindowsFormsApp2.Forms
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
