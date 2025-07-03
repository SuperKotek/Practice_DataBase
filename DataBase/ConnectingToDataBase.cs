using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data.Common;

namespace DataBase
{
    /// <summary>
    /// Класс для подключения базы данных
    /// </summary>
    public class ConnectingToDataBase
    {
        /// <summary>
        /// Выбор файла базы данных для подключения
        /// </summary>
        /// <returns>Строка с полным адрессом подключения</returns>
        public static string GetPathToDataBase()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Настройки диалогового окна
                openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory; // Начальная директория
                openFileDialog.Filter = "Access База Данных (*.accdb)|*.accdb|Access База Данных (*.mdb)|*.mdb";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Получаем выбранный файл
                    string filePath = openFileDialog.FileName;
                    string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";";
                    return connectionString;
                }
                else
                {
                    return "Error";
                }
            }
        }
        /// <summary>
        /// Получение данных из базы данных для получения списка форм
        /// </summary>
        /// <param name="PathToFile">Путь к файлу для подключения</param>
        /// <returns>Данные из базы данных</returns>
        public static DataTable GetNamesOfForms(string PathToFile)
        {
            try
            {
                // Подключение к базе данных
                OleDbConnection connection = new OleDbConnection(PathToFile);
                connection.Open();
                // Получаем список таблиц
                DataTable schemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,
                new object[] { null, null, null, "TABLE" });
                return schemaTable;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка получения списка форм: {ex.Message}");
            }
        }
        /// <summary>
        /// Получение списка форм базы данных
        /// </summary>
        /// <param name="PathToFile">Путь к файлу для подключения</param>
        /// <param name="SchemaTable">Данные из базы данных</param>
        /// <param name="CmbTables">ComboBox, который будет отвечать за переключение между форм</param>
        /// <returns>Список форм из базы данных</returns>
        public static List<string> GetAccessTablesBase(string PathToFile, DataTable SchemaTable, ComboBox CmbTables)
        {
            List<string> tables = new List<string>();
            try
            {
                using (OleDbConnection connection = new OleDbConnection(PathToFile))
                {
                    if (CmbTables.Items.Count > 0)
                    { CmbTables.Items.Clear(); }
                    foreach (DataRow row in SchemaTable.Rows)
                    { 
                        CmbTables.Items.Add(row["TABLE_NAME"].ToString());
                        tables.Add(row["TABLE_NAME"].ToString());
                    }
                    if (CmbTables.Items.Count > 0)
                    {
                        MessageBox.Show("Подключение прошло успешно!");
                    }
                    else
                    {
                        MessageBox.Show("В базе данных нет таблиц");
                    }
                }
                return tables;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка получения списка форм: {ex.Message}");
            }
        }
        /// <summary>
        /// Подключение базы данных к программе, ввод данных в datagridview
        /// </summary>
        /// <param name="PathToFile">Путь к файлу для подключения</param>
        /// <param name="DataGrid">DataGridView, в который выводятся данные текущей формы</param>
        /// <param name="SelectedInd">Выбранная форма</param>
        /// <param name="tables">Список форм из базы данных</param>
        public static void GetAccessDataBase(string PathToFile, DataGridView DataGrid, int SelectedInd, List<string> tables)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(PathToFile))
                {
                    string query = "SELECT * FROM [" + tables[SelectedInd] + "]";
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Привязка данных к DataGridView
                    DataGrid.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }
}
