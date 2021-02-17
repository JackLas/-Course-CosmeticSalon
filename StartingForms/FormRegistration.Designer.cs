namespace CosmeticSalon
{
    partial class FormRegistration
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
            this.lbl_surname = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_middleName = new System.Windows.Forms.Label();
            this.lbl_login = new System.Windows.Forms.Label();
            this.lbl_password = new System.Windows.Forms.Label();
            this.lbl_phone = new System.Windows.Forms.Label();
            this.lbl_exp = new System.Windows.Forms.Label();
            this.gb_account = new System.Windows.Forms.GroupBox();
            this.tb_repassword = new System.Windows.Forms.TextBox();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.tb_login = new System.Windows.Forms.TextBox();
            this.lbl_repassword = new System.Windows.Forms.Label();
            this.tb_surname = new System.Windows.Forms.TextBox();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.tb_middleName = new System.Windows.Forms.TextBox();
            this.tb_phone = new System.Windows.Forms.TextBox();
            this.rtb_exp = new System.Windows.Forms.RichTextBox();
            this.btn_registration = new System.Windows.Forms.Button();
            this.gb_account.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_surname
            // 
            this.lbl_surname.AutoSize = true;
            this.lbl_surname.Location = new System.Drawing.Point(12, 9);
            this.lbl_surname.Name = "lbl_surname";
            this.lbl_surname.Size = new System.Drawing.Size(56, 13);
            this.lbl_surname.TabIndex = 0;
            this.lbl_surname.Text = "Прізвище";
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(138, 9);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(26, 13);
            this.lbl_name.TabIndex = 1;
            this.lbl_name.Text = "Ім\'я";
            // 
            // lbl_middleName
            // 
            this.lbl_middleName.AutoSize = true;
            this.lbl_middleName.Location = new System.Drawing.Point(264, 9);
            this.lbl_middleName.Name = "lbl_middleName";
            this.lbl_middleName.Size = new System.Drawing.Size(67, 13);
            this.lbl_middleName.TabIndex = 2;
            this.lbl_middleName.Text = "По-батькові";
            // 
            // lbl_login
            // 
            this.lbl_login.AutoSize = true;
            this.lbl_login.Location = new System.Drawing.Point(54, 16);
            this.lbl_login.Name = "lbl_login";
            this.lbl_login.Size = new System.Drawing.Size(34, 13);
            this.lbl_login.TabIndex = 3;
            this.lbl_login.Text = "Логін";
            // 
            // lbl_password
            // 
            this.lbl_password.AutoSize = true;
            this.lbl_password.Location = new System.Drawing.Point(54, 55);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(45, 13);
            this.lbl_password.TabIndex = 4;
            this.lbl_password.Text = "Пароль";
            // 
            // lbl_phone
            // 
            this.lbl_phone.AutoSize = true;
            this.lbl_phone.Location = new System.Drawing.Point(12, 60);
            this.lbl_phone.Name = "lbl_phone";
            this.lbl_phone.Size = new System.Drawing.Size(52, 13);
            this.lbl_phone.TabIndex = 5;
            this.lbl_phone.Text = "Телефон";
            // 
            // lbl_exp
            // 
            this.lbl_exp.AutoSize = true;
            this.lbl_exp.Location = new System.Drawing.Point(12, 112);
            this.lbl_exp.Name = "lbl_exp";
            this.lbl_exp.Size = new System.Drawing.Size(80, 13);
            this.lbl_exp.TabIndex = 6;
            this.lbl_exp.Text = "Досвід роботи";
            // 
            // gb_account
            // 
            this.gb_account.Controls.Add(this.tb_repassword);
            this.gb_account.Controls.Add(this.tb_password);
            this.gb_account.Controls.Add(this.tb_login);
            this.gb_account.Controls.Add(this.lbl_repassword);
            this.gb_account.Controls.Add(this.lbl_login);
            this.gb_account.Controls.Add(this.lbl_password);
            this.gb_account.Location = new System.Drawing.Point(15, 268);
            this.gb_account.Name = "gb_account";
            this.gb_account.Size = new System.Drawing.Size(372, 151);
            this.gb_account.TabIndex = 7;
            this.gb_account.TabStop = false;
            this.gb_account.Text = "Акаунт";
            // 
            // tb_repassword
            // 
            this.tb_repassword.Location = new System.Drawing.Point(57, 112);
            this.tb_repassword.Name = "tb_repassword";
            this.tb_repassword.Size = new System.Drawing.Size(235, 20);
            this.tb_repassword.TabIndex = 8;
            this.tb_repassword.UseSystemPasswordChar = true;
            // 
            // tb_password
            // 
            this.tb_password.Location = new System.Drawing.Point(57, 72);
            this.tb_password.Name = "tb_password";
            this.tb_password.PasswordChar = '*';
            this.tb_password.Size = new System.Drawing.Size(235, 20);
            this.tb_password.TabIndex = 7;
            this.tb_password.UseSystemPasswordChar = true;
            // 
            // tb_login
            // 
            this.tb_login.Location = new System.Drawing.Point(57, 32);
            this.tb_login.Name = "tb_login";
            this.tb_login.Size = new System.Drawing.Size(235, 20);
            this.tb_login.TabIndex = 6;
            // 
            // lbl_repassword
            // 
            this.lbl_repassword.AutoSize = true;
            this.lbl_repassword.Location = new System.Drawing.Point(54, 95);
            this.lbl_repassword.Name = "lbl_repassword";
            this.lbl_repassword.Size = new System.Drawing.Size(100, 13);
            this.lbl_repassword.TabIndex = 5;
            this.lbl_repassword.Text = "Повторити пароль";
            // 
            // tb_surname
            // 
            this.tb_surname.Location = new System.Drawing.Point(15, 25);
            this.tb_surname.Name = "tb_surname";
            this.tb_surname.Size = new System.Drawing.Size(120, 20);
            this.tb_surname.TabIndex = 8;
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(141, 25);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(120, 20);
            this.tb_name.TabIndex = 9;
            // 
            // tb_middleName
            // 
            this.tb_middleName.Location = new System.Drawing.Point(267, 25);
            this.tb_middleName.Name = "tb_middleName";
            this.tb_middleName.Size = new System.Drawing.Size(120, 20);
            this.tb_middleName.TabIndex = 10;
            // 
            // tb_phone
            // 
            this.tb_phone.Location = new System.Drawing.Point(15, 76);
            this.tb_phone.Name = "tb_phone";
            this.tb_phone.Size = new System.Drawing.Size(179, 20);
            this.tb_phone.TabIndex = 11;
            // 
            // rtb_exp
            // 
            this.rtb_exp.Location = new System.Drawing.Point(15, 128);
            this.rtb_exp.Name = "rtb_exp";
            this.rtb_exp.Size = new System.Drawing.Size(372, 125);
            this.rtb_exp.TabIndex = 12;
            this.rtb_exp.Text = "";
            // 
            // btn_registration
            // 
            this.btn_registration.Location = new System.Drawing.Point(161, 424);
            this.btn_registration.Name = "btn_registration";
            this.btn_registration.Size = new System.Drawing.Size(75, 23);
            this.btn_registration.TabIndex = 13;
            this.btn_registration.Text = "Реєстрація";
            this.btn_registration.UseVisualStyleBackColor = true;
            this.btn_registration.Click += new System.EventHandler(this.btn_registration_Click);
            // 
            // FormRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 459);
            this.Controls.Add(this.btn_registration);
            this.Controls.Add(this.rtb_exp);
            this.Controls.Add(this.tb_phone);
            this.Controls.Add(this.tb_middleName);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.tb_surname);
            this.Controls.Add(this.gb_account);
            this.Controls.Add(this.lbl_exp);
            this.Controls.Add(this.lbl_phone);
            this.Controls.Add(this.lbl_middleName);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.lbl_surname);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormRegistration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Косметичний салон - Реєстрація";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormRegistration_FormClosed);
            this.gb_account.ResumeLayout(false);
            this.gb_account.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_surname;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lbl_middleName;
        private System.Windows.Forms.Label lbl_login;
        private System.Windows.Forms.Label lbl_password;
        private System.Windows.Forms.Label lbl_phone;
        private System.Windows.Forms.Label lbl_exp;
        private System.Windows.Forms.GroupBox gb_account;
        private System.Windows.Forms.TextBox tb_repassword;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.TextBox tb_login;
        private System.Windows.Forms.Label lbl_repassword;
        private System.Windows.Forms.TextBox tb_surname;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.TextBox tb_middleName;
        private System.Windows.Forms.TextBox tb_phone;
        private System.Windows.Forms.RichTextBox rtb_exp;
        private System.Windows.Forms.Button btn_registration;
    }
}