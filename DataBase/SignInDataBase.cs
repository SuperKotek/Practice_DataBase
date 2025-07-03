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
    /// <summary>
    /// Класс для регистрации и авторизации
    /// </summary>
    public class SignInDataBase
    {
        // Получения пути к базе данных, которая содержит информацию о пользователях Users.accdb
        private static string appDirectory = AppDomain.CurrentDomain.BaseDirectory; // Путь к папке с программой
        private static string path = Path.Combine(appDirectory, "Users.accdb");
        private static string _dbPath = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";";

        /// <summary>
        /// Регистрация нового пользователя
        /// </summary>
        /// <param name="username">Введенный никнейм</param>
        /// <param name="password">Введенный пароль</param>
        /// <returns>True - пользователь зарегистрирован, False - ошибка регистрации</returns>
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
        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="username">Введенный никнейм</param>
        /// <param name="password">Введенный пароль</param>
        /// <returns>True - пользователь авторизирован, False - ошибка авторизации</returns>
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
        /// <summary>
        /// Проверка на существования пользователя
        /// </summary>
        /// <param name="username">Никнейм пользователя</param>
        /// <returns>True - существует, False - не существует</returns>
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
