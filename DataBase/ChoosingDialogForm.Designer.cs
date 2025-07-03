namespace DataBase
{
    partial class ChoosingDialogForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dataGridView1 = new DataGridView();
            buttoon = new Button();
            Info_Label = new Label();
            button_cancel = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.Location = new Point(12, 50);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(613, 230);
            dataGridView1.TabIndex = 6;
            // 
            // buttoon
            // 
            buttoon.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttoon.Location = new Point(12, 286);
            buttoon.Name = "buttoon";
            buttoon.Size = new Size(293, 38);
            buttoon.TabIndex = 5;
            buttoon.Text = "Подтвердить изменения";
            buttoon.UseVisualStyleBackColor = true;
            buttoon.Click += buttoon_Click;
            // 
            // Info_Label
            // 
            Info_Label.AutoSize = true;
            Info_Label.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            Info_Label.Location = new Point(12, 9);
            Info_Label.Name = "Info_Label";
            Info_Label.Size = new Size(340, 25);
            Info_Label.TabIndex = 4;
            Info_Label.Text = "Проведите необходимые изменения";
            // 
            // button_cancel
            // 
            button_cancel.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button_cancel.Location = new Point(332, 286);
            button_cancel.Name = "button_cancel";
            button_cancel.Size = new Size(293, 38);
            button_cancel.TabIndex = 7;
            button_cancel.Text = "Отменить изменения";
            button_cancel.UseVisualStyleBackColor = true;
            button_cancel.Click += button_cancel_Click;
            // 
            // ChoosingDialogForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(637, 336);
            Controls.Add(button_cancel);
            Controls.Add(dataGridView1);
            Controls.Add(buttoon);
            Controls.Add(Info_Label);
            Name = "ChoosingDialogForm";
            Text = "Выбор данных";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button buttoon;
        private Label Info_Label;
        private Button button_cancel;
    }
}