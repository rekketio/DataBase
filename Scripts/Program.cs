using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Forms;

namespace WindowsFormsApp2.Scripts
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
