﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2.Scripts
{
    public class DataBaseInteraction
    {
        private SqlConnection connection;
        public DataBaseInteraction()
        {
#if DEBUG
            string workingDirectory = Environment.CurrentDirectory;
            string path = Directory.GetParent(workingDirectory).Parent.FullName;
            AppDomain.CurrentDomain.SetData("DataDirectory", path);
#endif

#if !DEBUG
            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(executable));
            AppDomain.CurrentDomain.SetData("DataDirectory", path);
#endif
        }
        public void Connect(Form form)
        {
            form.FormClosing += Disconnect;
            connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Data\DataBases\AutoShow.mdf;Integrated Security=True");
            connection.Open();
        }

        private void Disconnect(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }

        public void CreateAccount(string login, string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Data\DataBases\AutoShow.mdf;Integrated Security=True";
            connection.Open();
            var command = new SqlCommand($"INSERT INTO Accounts (username, password) VALUES (@username, @password);", connection);

            command.Parameters.Add("@login", SqlDbType.VarChar);
            command.Parameters["@login"].Value = login;

            command.Parameters.Add("@password", SqlDbType.Binary);
            command.Parameters["@password"].Value = hashBytes;

            command.ExecuteNonQuery();
            connection.Close();
        }

        public bool Login(string login, string password)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Data\DataBases\AutoShow.mdf;Integrated Security=True";
            connection.Open();

            SqlCommand command = new SqlCommand($"SELECT password FROM Accounts WHERE login = @login;", connection);
            command.Parameters.Add("@login", SqlDbType.NVarChar);
            command.Parameters["@login"].Value = login;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    byte[] hashBytes = (byte[])reader.GetValue(0);
                    byte[] salt = new byte[16];
                    Array.Copy(hashBytes, 0, salt, 0, 16);
                    var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
                    byte[] hash = pbkdf2.GetBytes(20);
                    for (int i = 0; i < 20; i++)
                        if (hashBytes[i + 16] != hash[i])
                        {
                            MessageBox.Show("Неверный логин или пароль", "Авторизация не пройдена", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            connection.Close();
                            return false;
                        }
                }
                connection.Close();
                return true;
            }
        }
        public void AddCar(string manufacture, string model, int releaseyear, string carbody, int horsepowers, string gosnumber)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Data\DataBases\AutoShow.mdf;Integrated Security=True";
            connection.Open();

            SqlCommand command = new SqlCommand($"INSERT INTO Cars (manyfactory, model, releaseyear, carbody, hp, gosnumber) VALUES (@mf, @model, @ry, @cb, @hp, @gosnum);", connection);

            command.Parameters.Add("@mf", SqlDbType.NVarChar);
            command.Parameters.Add("@model", SqlDbType.NVarChar);
            command.Parameters.Add("@ry", SqlDbType.Int);
            command.Parameters.Add("@cb", SqlDbType.NVarChar);
            command.Parameters.Add("@hp", SqlDbType.Int);
            command.Parameters.Add("@gosnum", SqlDbType.NChar);

            command.Parameters["@mf"].Value = manufacture;
            command.Parameters["@model"].Value = model;
            command.Parameters["@ry"].Value = releaseyear;
            command.Parameters["@cb"].Value = carbody;
            command.Parameters["@hp"].Value = horsepowers;
            command.Parameters["@gosnum"].Value = gosnumber;

            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}

