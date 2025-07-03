using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DataBase
{
    public class SignInDataBase
    {
        private static string _dbPath = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\tuzov\OneDrive\Рабочий стол\универ работы\практика\DataBase\DataBase\bin\Debug\net9.0-windows\Users.accdb;";

        // Инициализация с указанием пути к базе
        public static void Initialize(string dbPath)
        {
            _dbPath = dbPath;
        }

        // Регистрация нового пользователя
        public static bool Register(string username, string password)
        {
            if (UserExists(username))
                return false;

            using (var connection = new OleDbConnection(_dbPath))
            {
                connection.Open();
                using (var cmd = new OleDbCommand("INSERT INTO Users ([Username], [Password]) VALUES (?, ?)", connection))
                {
                    cmd.Parameters.AddWithValue("?", username);
                    cmd.Parameters.AddWithValue("?", password);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        // Проверка логина и пароля
        public static bool Login(string username, string password)
        {
            using (var connection = new OleDbConnection(_dbPath))
            {
                connection.Open();
                using (var cmd = new OleDbCommand(
                    "SELECT COUNT(*) FROM Users WHERE Username = ? AND Password = ?",
                    connection))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }
        private static bool UserExists(string username)
        {
            using (var connection = new OleDbConnection(_dbPath))
            {
                connection.Open();
                using (var cmd = new OleDbCommand(
                    "SELECT COUNT(*) FROM Users WHERE Username = ?",
                    connection))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }
    }
}
