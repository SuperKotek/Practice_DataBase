namespace DataBase
{
    partial class SignUp
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
            txtPassword = new TextBox();
            txtLogin = new TextBox();
            label3 = new Label();
            label2 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 20.25F, FontStyle.Bold);
            label1.Location = new Point(78, 9);
            label1.Name = "label1";
            label1.Size = new Size(175, 37);
            label1.TabIndex = 1;
            label1.Text = "Регистрация";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            txtPassword.Location = new Point(12, 157);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(314, 33);
            txtPassword.TabIndex = 9;
            // 
            // txtLogin
            // 
            txtLogin.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            txtLogin.Location = new Point(12, 88);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(314, 33);
            txtLogin.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 16.25F, FontStyle.Bold);
            label3.Location = new Point(12, 124);
            label3.Name = "label3";
            label3.Size = new Size(185, 30);
            label3.TabIndex = 7;
            label3.Text = "Введите Пароль:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 16.25F, FontStyle.Bold);
            label2.Location = new Point(12, 55);
            label2.Name = "label2";
            label2.Size = new Size(171, 30);
            label2.TabIndex = 6;
            label2.Text = "Введите Логин:";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.Location = new Point(53, 244);
            button1.Name = "button1";
            button1.Size = new Size(216, 48);
            button1.TabIndex = 10;
            button1.Text = "Зарегистрироваться";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // SignUp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(338, 304);
            Controls.Add(button1);
            Controls.Add(txtPassword);
            Controls.Add(txtLogin);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "SignUp";
            Text = "SignUp";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtPassword;
        private TextBox txtLogin;
        private Label label3;
        private Label label2;
        private Button button1;
    }
}