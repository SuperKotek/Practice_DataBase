using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML;
using ClosedXML.Excel;

namespace DataBase
{
    /// <summary>
    /// Класс для создания отчетов
    /// </summary>
    public class ReportGenerator
    {
        /// <summary>
        /// Экспортирует указанную таблицу из Access в Excel (.xlsx)
        /// </summary>
        /// <param name="tableName">Имя таблицы в Access</param>
        /// <param name="excelFilePath">Путь к файлу Excel для сохранения</param>
        public static void ExportTableToExcel(string PathToFile, string tableName, string excelFilePath)
        {
            try
            {
                DataTable dataTable = GetDataFromAccess(PathToFile, tableName);

                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("Таблица пуста.");
                    return;
                }

                // Создаем новую книгу Excel
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add(tableName);

                    // Заполняем заголовки
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        worksheet.Cell(1, i + 1).Value = dataTable.Columns[i].ColumnName;
                    }

                    // Заполняем данные
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataTable.Columns.Count; j++)
                        {
                            worksheet.Cell(i + 2, j + 1).Value = dataTable.Rows[i][j]?.ToString();
                        }
                    }

                    // Автоподгон ширины столбцов
                    worksheet.Columns().AdjustToContents();

                    // Сохраняем файл
                    workbook.SaveAs(excelFilePath);
                }

                MessageBox.Show($"Файл успешно сохранён:\n{excelFilePath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при экспорте в Excel: " + ex.Message);
            }
        }
        /// <summary>
        /// Получает данные из таблицы Access
        /// </summary>
        /// <param name="PathToFile">Путь к файлу базы данных</param>
        /// <param name="tableName">Имя выбранной формы</param>
        /// <returns>Данные из базы данных</returns>
        private static DataTable GetDataFromAccess(string PathToFile, string tableName)
        {
            using (OleDbConnection conn = new OleDbConnection(PathToFile))
            {
                conn.Open();
                string query = $"SELECT * FROM [{tableName}]";
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }
    }
}
