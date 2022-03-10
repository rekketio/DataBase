using System;
using System.Windows.Forms;
using WindowsFormsApp2.SQL.Forms;

namespace WindowsFormsApp2.SQL.Scripts
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
