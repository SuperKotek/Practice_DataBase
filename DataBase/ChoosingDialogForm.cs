using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using static System.Windows.Forms.DataFormats;
using System.Data.OleDb;
using System.Threading.Channels;

namespace DataBase
{
    public partial class ChoosingDialogForm : Form
    {
        public static Dictionary<string, object> newRec = new Dictionary<string, object>();
        private int SelectedTable = 0;
        private List<string> tables = new List<string>();
        private DataTable dataTable;
        private string tableName = "";
        private string PathToFile = "";

        public ChoosingDialogForm()
        {
            InitializeComponent();

            this.AcceptButton = buttoon; // Enter будет нажимать эту кнопку

            SelectedTable = DataB.SelectedTable;
            PathToFile = DataB.PathToFile;
            tables = DataB.tables;
            tableName = tables[SelectedTable];

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

                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
                this.Close();
            }
        }

        private void buttoon_Click(object sender, EventArgs e)
        {
            DataTable? changes = dataTable.GetChanges();
            if (changes == null)
            {
                MessageBox.Show("Нет изменений для сохранения", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                using (var connection = new OleDbConnection(PathToFile))
                {
                    connection.Open();
                    using (var adapter = new OleDbDataAdapter($"SELECT * FROM [{tableName}]", connection))
                    {
                        var builder = new OleDbCommandBuilder(adapter);
                        builder.QuotePrefix = "[";
                        builder.QuoteSuffix = "]";
                        adapter.UpdateCommand = builder.GetUpdateCommand();
                        adapter.InsertCommand = builder.GetInsertCommand();
                        adapter.DeleteCommand = builder.GetDeleteCommand();

                        int changeCount = adapter.Update(changes);
                        dataTable.AcceptChanges();
                        MessageBox.Show($"Успешно сохранено {changeCount} изменений");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
            }
            this.Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
