using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using Microsoft.VisualBasic.ApplicationServices;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.VisualBasic.Logging;

namespace DataBase
{
    public partial class SignIn : Form
    {
        public static bool IsAuthenticated = false;
        string PathToFile = DataB.PathToFile;
        private string PathToUsersFile = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\
        tuzov\OneDrive\Рабочий стол\универ работы\практика\DataBase\
        DataBase\bin\Debug\net9.0-windows\Users.accdb;";
        public SignIn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtLogin.Text.Trim();
                string password = txtPassword.Text.Trim();
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Введите логин и пароль.");
                    return;
                }
                if (SignInDataBase.Login(username, password))
                {
                    IsAuthenticated = true;
                    DialogResult = DialogResult.OK;
                    this.Close();
                    // Открываем главную форму
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при проверке данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUp signUp = new SignUp();
            DialogResult = signUp.ShowDialog();
            if (DialogResult == DialogResult.OK)
            { IsAuthenticated = true; }
            this.Close();
        }
    }
}
