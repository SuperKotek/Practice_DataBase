using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.DirectoryServices;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DataBase
{
    public partial class SortingParam : Form
    {
        public static List<(string, bool)> SortParam = new List<(string, bool)>();
        private List<string> tables = new List<string>();
        private string PathToFile;
        private DataTable dataTable;
        private string tableName;
        private int SelectedTable;
        private List<string> ColumnNames = new List<string>();

        public SortingParam()
        {
            InitializeComponent();

            SelectedTable = DataB.SelectedTable;
            PathToFile = DataB.PathToFile;
            tables = DataB.tables;
            tableName = tables[SelectedTable];
            ColumnNames = DataB.ColumsNames;

            string[] options = { "По возрастанию", "По убыванию"};
            cmbSortDirection.Items.AddRange(options);
            for (int i = 0; i < ColumnNames.Count; i++)
            { cmbAvailableColumns.Items.Add(ColumnNames[i]); }
            cmbSortDirection.SelectedIndex = 0;
            cmbAvailableColumns.SelectedIndex = 0;

            SortParam.Clear();
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(PathToFile))
                {
                    string query = $"SELECT * FROM [{tableName}]";
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);

                    dataTable = new DataTable();
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
                this.Close();
            }
        }

        private void UpdateSortDataGridView()
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < SortParam.Count; i++)
            {
                dataGridView1.Rows.Add(SortParam[i].Item1, SortParam[i].Item2);
            }
        }

        private void btnAddSort_Click(object sender, EventArgs e)
        {
            string columnName = ColumnNames[cmbAvailableColumns.SelectedIndex];
            int sortDirectInt = cmbSortDirection.SelectedIndex;
            bool sortDirection = false;
            if (sortDirectInt == 0) 
            { sortDirection = true; }

            SortParam.Add((columnName, sortDirection));
            UpdateSortDataGridView();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string columnName = ColumnNames[cmbAvailableColumns.SelectedIndex];
            int sortDirectInt = cmbSortDirection.SelectedIndex;
            bool sortDirection = false;
            if (sortDirectInt == 0)
            { sortDirection = true; }

            SortParam.Remove((columnName, sortDirection));
            UpdateSortDataGridView();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
