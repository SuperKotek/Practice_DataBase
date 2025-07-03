using System.ComponentModel;

namespace DataBase
{
    partial class SortingParam
    {
        private Button btnAddSort;
        private Button btnRemove;
        private Button btnApply;
        private Button btnCancel;
        private Label label1;
        private Label label2;

        private void InitializeComponent()
        {
            btnAddSort = new Button();
            btnRemove = new Button();
            btnApply = new Button();
            btnCancel = new Button();
            label1 = new Label();
            label2 = new Label();
            dataGridView1 = new DataGridView();
            cmbSortDirection = new ComboBox();
            cmbAvailableColumns = new ComboBox();
            ColumnMain = new DataGridViewTextBoxColumn();
            ColumnBonus = new DataGridViewTextBoxColumn();
            ((ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnAddSort
            // 
            btnAddSort.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnAddSort.Location = new Point(413, 106);
            btnAddSort.Name = "btnAddSort";
            btnAddSort.Size = new Size(167, 41);
            btnAddSort.TabIndex = 2;
            btnAddSort.Text = "Добавить";
            btnAddSort.Click += btnAddSort_Click;
            // 
            // btnRemove
            // 
            btnRemove.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnRemove.Location = new Point(413, 153);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(167, 41);
            btnRemove.TabIndex = 4;
            btnRemove.Text = "Удалить";
            btnRemove.Click += btnRemove_Click;
            // 
            // btnApply
            // 
            btnApply.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnApply.Location = new Point(429, 282);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(151, 34);
            btnApply.TabIndex = 7;
            btnApply.Text = "Применить";
            btnApply.Click += btnApply_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnCancel.Location = new Point(262, 282);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(145, 34);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Отмена";
            btnCancel.Click += btnCancel_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(10, 9);
            label1.Name = "label1";
            label1.Size = new Size(169, 23);
            label1.TabIndex = 9;
            label1.Text = "Доступные столбцы:";
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(10, 73);
            label2.Name = "label2";
            label2.Size = new Size(416, 23);
            label2.TabIndex = 10;
            label2.Text = "Текущие параметры сортировка:";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ColumnMain, ColumnBonus });
            dataGridView1.Location = new Point(10, 106);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(397, 156);
            dataGridView1.TabIndex = 11;
            // 
            // cmbSortDirection
            // 
            cmbSortDirection.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            cmbSortDirection.FormattingEnabled = true;
            cmbSortDirection.Location = new Point(413, 41);
            cmbSortDirection.Name = "cmbSortDirection";
            cmbSortDirection.Size = new Size(167, 29);
            cmbSortDirection.TabIndex = 12;
            // 
            // cmbAvailableColumns
            // 
            cmbAvailableColumns.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            cmbAvailableColumns.FormattingEnabled = true;
            cmbAvailableColumns.Location = new Point(12, 41);
            cmbAvailableColumns.Name = "cmbAvailableColumns";
            cmbAvailableColumns.Size = new Size(395, 29);
            cmbAvailableColumns.TabIndex = 13;
            // 
            // ColumnMain
            // 
            ColumnMain.HeaderText = "Порядок сортировки";
            ColumnMain.MinimumWidth = 20;
            ColumnMain.Name = "ColumnMain";
            ColumnMain.ReadOnly = true;
            ColumnMain.Width = 170;
            // 
            // ColumnBonus
            // 
            ColumnBonus.HeaderText = "Направление сортировки";
            ColumnBonus.Name = "ColumnBonus";
            ColumnBonus.ReadOnly = true;
            ColumnBonus.Width = 184;
            // 
            // SortingParam
            // 
            ClientSize = new Size(592, 328);
            Controls.Add(cmbAvailableColumns);
            Controls.Add(cmbSortDirection);
            Controls.Add(dataGridView1);
            Controls.Add(btnAddSort);
            Controls.Add(btnRemove);
            Controls.Add(btnApply);
            Controls.Add(btnCancel);
            Controls.Add(label1);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SortingParam";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Настройка сортировки";
            ((ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        private DataGridView dataGridView1;
        private ComboBox cmbSortDirection;
        private ComboBox cmbAvailableColumns;
        private DataGridViewTextBoxColumn ColumnMain;
        private DataGridViewTextBoxColumn ColumnBonus;
    }
}