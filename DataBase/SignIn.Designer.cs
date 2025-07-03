namespace DataBase
{
    partial class SignIn
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            txtLogin = new TextBox();
            txtPassword = new TextBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 20.25F, FontStyle.Bold);
            label1.Location = new Point(75, 9);
            label1.Name = "label1";
            label1.Size = new Size(183, 37);
            label1.TabIndex = 0;
            label1.Text = "Авторизация";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 16.25F, FontStyle.Bold);
            label2.Location = new Point(12, 57);
            label2.Name = "label2";
            label2.Size = new Size(171, 30);
            label2.TabIndex = 1;
            label2.Text = "Введите Логин:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 16.25F, FontStyle.Bold);
            label3.Location = new Point(12, 126);
            label3.Name = "label3";
            label3.Size = new Size(185, 30);
            label3.TabIndex = 2;
            label3.Text = "Введите Пароль:";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.Location = new Point(54, 236);
            button1.Name = "button1";
            button1.Size = new Size(216, 48);
            button1.TabIndex = 3;
            button1.Text = "Авторизироваться";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtLogin
            // 
            txtLogin.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            txtLogin.Location = new Point(12, 90);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(314, 33);
            txtLogin.TabIndex = 4;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            txtPassword.Location = new Point(12, 159);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(314, 33);
            txtPassword.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.Control;
            label4.Font = new Font("Segoe UI Semibold", 12.25F, FontStyle.Bold);
            label4.ForeColor = SystemColors.HotTrack;
            label4.Location = new Point(44, 210);
            label4.Name = "label4";
            label4.Size = new Size(239, 23);
            label4.TabIndex = 6;
            label4.Text = "Нет аккаунта? - Регистрация";
            label4.Click += label4_Click;
            // 
            // SignIn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(338, 304);
            Controls.Add(label4);
            Controls.Add(txtPassword);
            Controls.Add(txtLogin);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "SignIn";
            Text = "Авторизация";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private TextBox txtLogin;
        private TextBox txtPassword;
        private Label label4;
    }
}