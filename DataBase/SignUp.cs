using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase
{
    public partial class SignUp : Form
    {
        private string PathToUsersFile = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\
        tuzov\OneDrive\Рабочий стол\универ работы\практика\DataBase\
        DataBase\bin\Debug\net9.0-windows\Users.accdb;";
        public SignUp()
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
                    MessageBox.Show("Введите логин и пароль");
                    return;
                }

                if (SignInDataBase.Register(username, password))
                {
                    MessageBox.Show("Регистрация успешна!");
                }
                else
                {
                    MessageBox.Show("Пользователь уже существует");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка регистрации: {ex.Message}");
            }
            this.Close();
        }
    }
}
