using System;
using System.Windows.Forms;
using SQL_Project.SQL.Forms;

namespace SQL_Project.SQL.Scripts
{
	static class Program
	{
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			LoginForm form = new LoginForm();
			form.Show();
			Application.Run();
		}
	}
}
