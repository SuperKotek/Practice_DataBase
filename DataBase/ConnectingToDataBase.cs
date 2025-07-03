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
    public class ConnectingToDataBase
    {
        public static string GetPathToDataBase()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Настройки диалогового окна
                openFileDialog.InitialDirectory = "C:\\Users\\tuzov\\OneDrive\\Рабочий стол\\универ работы\\практика"; // Начальная директория
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
