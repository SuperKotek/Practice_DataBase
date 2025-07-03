using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class EditingDataBase
    {
        public static int AddRecordToForm(string PathToFile, string tableName, Dictionary<string, object> conditions, OleDbConnection connection)
        {
            try
            {
                using (connection = new OleDbConnection(PathToFile))
                {
                    // Формируем SQL-запрос
                    string columns = string.Join(", ", conditions.Keys.Select(k => "[" + k + "]"));
                    string parameters = string.Join(", ", conditions.Keys.Select(k => "?"));

                    string query = $"INSERT INTO [{tableName}] ({columns}) VALUES ({parameters})";

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        // Добавляем параметры (порядок важен для Access)
                        foreach (var values in conditions)
                        {
                            command.Parameters.AddWithValue("?", values.Value ?? DBNull.Value);
                        }
                        // Открываем соединение, если оно закрыто
                        if (connection.State != System.Data.ConnectionState.Open)
                        { connection.Open(); }

                        return command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении записи: {ex.Message}");
                return 0;
            }
        }
        /// <summary>
        /// Удаляет строки по нескольким условиям
        /// </summary>
        /// <param name="tableName">Имя таблицы</param>
        /// <param name="conditions">Словарь условий (столбец-значение)</param>
        /// <returns>Количество удаленных строк</returns>
        public static int RemoveRecordFromForm(string PathToFile, string tableName, Dictionary<string, object> conditions, OleDbConnection connection)
        {
            try
            {
                using (connection = new OleDbConnection(PathToFile))
                {
                    // Формируем WHERE часть запроса
                    string whereClause = string.Join(" AND ", conditions.Keys.Select(c => $"[{c}] = ?"));
                    string query = $"DELETE FROM [{tableName}] WHERE {whereClause}";

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        // Добавляем параметры в том же порядке, что и условия
                        foreach (var value in conditions.Values)
                        {
                            command.Parameters.AddWithValue("?", value ?? DBNull.Value);
                        }
                        // Открываем соединение, если оно закрыто
                        if (connection.State != System.Data.ConnectionState.Open)
                        { connection.Open(); }
                        // Выполняем запрос
                        return command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при удалении записей: {ex.Message}");
                return 0;
            }
        }
        public static (List<string>, List<string>) GetTableColumns(string PathToFile, string tableName, OleDbConnection connection)
        {
            List<string> columns = new List<string>();
            List<string> datatypes = new List<string>();
            try
            {
                using (connection = new OleDbConnection(PathToFile))
                {
                    if (connection.State != System.Data.ConnectionState.Open)
                    { connection.Open(); }

                    // Получаем схему таблицы
                    DataTable schemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Columns,
                    new object[] { null, null, tableName, null });
                    foreach (DataRow row in schemaTable.Rows)
                    {
                        columns.Add(row["COLUMN_NAME"].ToString());
                        datatypes.Add(GetOleDbTypeName(Convert.ToInt32(row["DATA_TYPE"])));
                    }
                    return (columns, datatypes);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при получении списка столбцов: {ex.Message}");
                return (columns, datatypes);
            }
        }
        private static string GetOleDbTypeName(int oleDbType)
        {
            switch (oleDbType)
            {
                case 2: return "Целое число (короткое)";  // SmallInt (Short)
                case 3: return "Целое число";             // Integer (Long)
                case 4: return "Вещественное число";      // Single (Float)
                case 5: return "Действительное число";    // Double
                case 6: return "Денежный";                // Currency
                case 7: return "Дата/время";              // Date
                case 11: return "Логический";             // Boolean (Yes/No)
                case 17: return "Байт";                   // UnsignedTinyInt
                case 72: return "GUID";                   // GUID (в Access обычно "Код репликации")
                case 128: return "Двоичный";              // Binary
                case 130: return "Текст (Unicode)";       // WChar
                case 131: return "Числовой";              // Numeric (Decimal)
                case 202: return "Текст";                 // VarWChar (в Access просто "Текст")
                case 203: return "Поле MEMO";             // LongVarWChar (Memo)
                default: return $"Неизвестный ({oleDbType})";
            }
        }
    }
    public class DataGridEditor
    {
        public static void SaveChanges(string PathToFile, DataGridView dataGridView, string tableName)
        {
            try
            {
                var dbEditor = new DatabaseEditor();
                var changes = new List<Dictionary<string, object>>();

                // Собираем измененные строки
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if (row.IsNewRow || !row.IsDirty()) continue;

                    var rowValues = new Dictionary<string, object>();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        rowValues[dataGridView.Columns[cell.ColumnIndex].Name] = cell.Value;
                    }
                    changes.Add(rowValues);
                }

                // Применяем изменения
                foreach (var change in changes)
                {
                    var id = change["ID"]; // Предполагаем наличие ID
                    var where = new Dictionary<string, object> { { "ID", id } };

                    dbEditor.UpdateRecord(PathToFile, tableName, change, where);
                }

                MessageBox.Show($"Сохранено {changes.Count} изменений");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}");
            }
        }
    }
    public static class DataGridViewExtensions
    {
        public static bool IsDirty(this DataGridViewRow row)
        {
            return row.Cells.Cast<DataGridViewCell>().Any(c => c.IsDirty());
        }

        public static bool IsDirty(this DataGridViewCell cell)
        {
            return cell.Value != null && !cell.Value.Equals(cell.OwningColumn.DefaultCellStyle?.NullValue);
        }
    }
    public class DatabaseEditor
    {
        // Основной метод для обновления записей
        public bool UpdateRecord(string PathToFile, string tableName, Dictionary<string, object> updateValues, Dictionary<string, object> whereConditions)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(PathToFile))
                {
                    connection.Open();

                    // Формируем SET часть запроса
                    var setClause = string.Join(", ", updateValues.Keys.Select(k => $"[{k}] = ?"));

                    // Формируем WHERE часть
                    var whereClause = string.Join(" AND ", whereConditions.Keys.Select(k => $"[{k}] = ?"));

                    string query = $"UPDATE [{tableName}] SET {setClause} WHERE {whereClause}";

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        // Добавляем параметры для SET
                        foreach (var value in updateValues.Values)
                        {
                            command.Parameters.AddWithValue("?", value ?? DBNull.Value);
                        }

                        // Добавляем параметры для WHERE
                        foreach (var value in whereConditions.Values)
                        {
                            command.Parameters.AddWithValue("?", value ?? DBNull.Value);
                        }

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении записи: {ex.Message}");
                return false;
            }
        }
    }
}
