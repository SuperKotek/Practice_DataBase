namespace DataBase
{
    partial class DataB
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            menuStrip1 = new MenuStrip();
            DB_SignIn = new ToolStripMenuItem();
            DB_ConnectingButton = new ToolStripMenuItem();
            DB_RedactElement = new ToolStripMenuItem();
            отчетToolStripMenuItem = new ToolStripMenuItem();
            excelToolStripMenuItem = new ToolStripMenuItem();
            DB_Exit = new ToolStripMenuItem();
            dataGridView1 = new DataGridView();
            comboBox1 = new ComboBox();
            label1 = new Label();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { DB_SignIn, DB_ConnectingButton, DB_RedactElement, отчетToolStripMenuItem, DB_Exit });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(696, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // DB_SignIn
            // 
            DB_SignIn.Name = "DB_SignIn";
            DB_SignIn.Size = new Size(90, 20);
            DB_SignIn.Text = "Авторизация";
            DB_SignIn.Click += DB_SignIn_Click;
            // 
            // DB_ConnectingButton
            // 
            DB_ConnectingButton.Name = "DB_ConnectingButton";
            DB_ConnectingButton.Size = new Size(159, 20);
            DB_ConnectingButton.Text = "Подключить базу данных";
            DB_ConnectingButton.Click += DB_ConnectingButton_Click;
            // 
            // DB_RedactElement
            // 
            DB_RedactElement.Name = "DB_RedactElement";
            DB_RedactElement.Size = new Size(144, 20);
            DB_RedactElement.Text = "Работа с базой данных";
            DB_RedactElement.Click += DB_RedactElement_Click;
            // 
            // отчетToolStripMenuItem
            // 
            отчетToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { excelToolStripMenuItem });
            отчетToolStripMenuItem.Name = "отчетToolStripMenuItem";
            отчетToolStripMenuItem.Size = new Size(51, 20);
            отчетToolStripMenuItem.Text = "Отчет";
            // 
            // excelToolStripMenuItem
            // 
            excelToolStripMenuItem.Name = "excelToolStripMenuItem";
            excelToolStripMenuItem.Size = new Size(180, 22);
            excelToolStripMenuItem.Text = "Excel";
            excelToolStripMenuItem.Click += excelToolStripMenuItem_Click;
            // 
            // DB_Exit
            // 
            DB_Exit.Name = "DB_Exit";
            DB_Exit.Size = new Size(53, 20);
            DB_Exit.Text = "Выход";
            DB_Exit.Click += DB_Exit_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.Location = new Point(12, 67);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(672, 366);
            dataGridView1.TabIndex = 1;
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Segoe UI", 14F);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(198, 28);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(179, 33);
            comboBox1.TabIndex = 2;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            label1.Location = new Point(12, 28);
            label1.Name = "label1";
            label1.Size = new Size(180, 30);
            label1.TabIndex = 3;
            label1.Text = "Текущая форма:";
            // 
            // DataB
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(696, 444);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(405, 257);
            Name = "DataB";
            Text = "База данных Access";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem DB_ConnectingButton;
        private DataGridView dataGridView1;
        private ToolStripMenuItem DB_RedactElement;
        private ToolStripMenuItem DB_SignIn;
        private ToolStripMenuItem DB_Exit;
        private ComboBox comboBox1;
        private Label label1;
        private ToolStripMenuItem отчетToolStripMenuItem;
        private ToolStripMenuItem excelToolStripMenuItem;
    }
}
