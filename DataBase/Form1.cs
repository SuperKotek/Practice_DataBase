using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using System;
using System.Data.Common;
using static System.Windows.Forms.DataFormats;
using System.Security.Cryptography.Pkcs;
using Microsoft.VisualBasic.ApplicationServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;


namespace DataBase
{
    public partial class DataB : Form
    {
        public static string PathToFile = "Error";
        private OleDbConnection connection;
        public static List<string> tables = new List<string>();
        public static List<string> ColumsNames = new List<string>();
        public static List<string> ColumsTypes = new List<string>();
        public static int SelectedTable = 0;
        public DataB()
        {
            InitializeComponent();
            DB_ConnectingButton.Enabled = false;
            DB_RedactElement.Enabled = false;
        }
        /// <summary>
        /// Подключение к базе данных
        /// </summary>
        private void DB_ConnectingButton_Click(object sender, EventArgs e)
        {
            PathToFile = ConnectingToDataBase.GetPathToDataBase();
            if (PathToFile != "Error")
            {
                try
                {
                    using (connection = new OleDbConnection(PathToFile))
                    {
                        if (connection != null && connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        connection.Open();
                        DataTable dataTable = ConnectingToDataBase.GetNamesOfForms(PathToFile);
                        tables = ConnectingToDataBase.GetAccessTablesBase(PathToFile, dataTable, comboBox1);
                        ConnectingToDataBase.GetAccessDataBase(PathToFile, dataGridView1, 0, tables);
                        comboBox1.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }
        /// <summary>
        /// Авторизация в базе данных
        /// </summary>
        private void DB_SignIn_Click(object sender, EventArgs e)
        {
            SignInDataBase dbHelper = new SignInDataBase();
            using (Form LoginForm = new SignIn())
            {
                if (LoginForm.ShowDialog() == DialogResult.OK)
                {
                    if (SignIn.IsAuthenticated == true)
                    {
                        MessageBox.Show("Авторизация успешна!");
                        DB_SignIn.Enabled = false;
                        DB_RedactElement.Enabled = true;
                        DB_ConnectingButton.Enabled = true;
                        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TuzovskyNI_var18.accdb");
                        PathToFile = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";";
                        try
                        {
                            using (connection = new OleDbConnection(PathToFile))
                            {
                                if (connection != null && connection.State == ConnectionState.Open)
                                {
                                    connection.Close();
                                }
                                connection.Open();
                                DataTable dataTable = ConnectingToDataBase.GetNamesOfForms(PathToFile);
                                tables = ConnectingToDataBase.GetAccessTablesBase(PathToFile, dataTable, comboBox1);
                                ConnectingToDataBase.GetAccessDataBase(PathToFile, dataGridView1, 0, tables);
                                comboBox1.SelectedIndex = 0;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка: " + ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ошибка авторизации!");
                    }
                }
            }
        }
        /// <summary>
        /// Выход из базы данных
        /// </summary>
        private void DB_Exit_Click(object sender, EventArgs e)
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
                connection.Dispose();
            }
            this.Close();
        }
        /// <summary>
        /// Изменение просматриваемой формы
        /// </summary>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PathToFile != "Error")
            {
                try
                {
                    using (connection = new OleDbConnection(PathToFile))
                    {
                        ConnectingToDataBase.GetAccessDataBase(PathToFile, dataGridView1, comboBox1.SelectedIndex, tables);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Ошибка: Отсутствует подключение к базе данных.");
            }
        }
        /// <summary>
        /// Создание отчета (сохранение текущей таблицы в excel файле)
        /// </summary>
        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PathToFile != "Error")
            {
                string savePath = @"C:\Users\tuzov\OneDrive\Рабочий стол\универ работы\практика\DataBase\DataBase\bin\Debug\net9.0-windows\Report.xlsx";
                ReportGenerator.ExportTableToExcel(PathToFile, tables[SelectedTable], savePath);
            }
            else
            {
                MessageBox.Show("Ошибка: Отсутствует подключение к базе данных.");
            }
        }
        /// <summary>
        /// Редактирование текущей формы (добавление записей, удаление записей, редактирование записей)
        /// </summary>
        private void DB_RedactElement_Click(object sender, EventArgs e)
        {
            if (PathToFile != "Error")
            {
                string tableName = tables[comboBox1.SelectedIndex];
                (ColumsNames, ColumsTypes) = EditingDataBase.GetTableColumns(PathToFile, tableName, connection);
                SelectedTable = comboBox1.SelectedIndex;
                ChoosingDialogForm form = new ChoosingDialogForm();
                DialogResult result = form.ShowDialog();
                ConnectingToDataBase.GetAccessDataBase(PathToFile, dataGridView1, comboBox1.SelectedIndex, tables);
            }
            else
            {
                MessageBox.Show("Ошибка: Отсутствует подключение к базе данных.");
            }
        }
    }
}
