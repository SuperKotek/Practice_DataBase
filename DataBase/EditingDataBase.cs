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
    /// <summary>
    /// Класс для получения необходимых данных для редактирования базы данных
    /// </summary>
    public class EditingDataBase
    {
        /// <summary>
        /// Получение списка имен столбцов и их форматов
        /// </summary>
        /// <param name="PathToFile">Путь к файлу для подключения</param>
        /// <param name="tableName">Имя формы, из которой берутся данные</param>
        /// <param name="connection">Подключение</param>
        /// <returns>Кортеж списков (список имен столбцов и список их форматов)</returns>
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
        /// <summary>
        /// Обработка форматов в текстовый вариант
        /// </summary>
        /// <param name="oleDbType">Число, обозначающее формат</param>
        /// <returns>Строка с типом данных</returns>
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
    /// <summary>
    /// Класс для сохранения изменений в базе данных
    /// </summary>
    public class DatabaseEditor
    {
        /// <summary>
        /// Сохранение изменений в базе данных
        /// </summary>
        /// <param name="PathToFile">Путь к файлу для подключения</param>
        /// <param name="tableName">Имя формы, в которой происходит изменение</param>
        /// <param name="updateValues">Обновленные значения</param>
        /// <param name="whereConditions">Описание, куда были занесены изменения</param>
        /// <returns>True - обновление произошло, False - не произошло</returns>
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
