namespace CosmeticSalon
{
    partial class FormLogin
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_login = new System.Windows.Forms.TextBox();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.lbl_login = new System.Windows.Forms.Label();
            this.lbl_password = new System.Windows.Forms.Label();
            this.btn_login = new System.Windows.Forms.Button();
            this.btn_registration = new System.Windows.Forms.Button();
            this.lbl_wrongLogPass = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_login
            // 
            this.tb_login.Location = new System.Drawing.Point(15, 25);
            this.tb_login.Name = "tb_login";
            this.tb_login.Size = new System.Drawing.Size(246, 20);
            this.tb_login.TabIndex = 0;
            // 
            // tb_password
            // 
            this.tb_password.Location = new System.Drawing.Point(15, 64);
            this.tb_password.Name = "tb_password";
            this.tb_password.Size = new System.Drawing.Size(246, 20);
            this.tb_password.TabIndex = 1;
            // 
            // lbl_login
            // 
            this.lbl_login.AutoSize = true;
            this.lbl_login.Location = new System.Drawing.Point(12, 9);
            this.lbl_login.Name = "lbl_login";
            this.lbl_login.Size = new System.Drawing.Size(34, 13);
            this.lbl_login.TabIndex = 2;
            this.lbl_login.Text = "Логін";
            // 
            // lbl_password
            // 
            this.lbl_password.AutoSize = true;
            this.lbl_password.Location = new System.Drawing.Point(12, 48);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(45, 13);
            this.lbl_password.TabIndex = 3;
            this.lbl_password.Text = "Пароль";
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(15, 90);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(75, 23);
            this.btn_login.TabIndex = 4;
            this.btn_login.Text = "Увійти";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // btn_registration
            // 
            this.btn_registration.Location = new System.Drawing.Point(186, 90);
            this.btn_registration.Name = "btn_registration";
            this.btn_registration.Size = new System.Drawing.Size(75, 23);
            this.btn_registration.TabIndex = 5;
            this.btn_registration.Text = "Реєстрація";
            this.btn_registration.UseVisualStyleBackColor = true;
            this.btn_registration.Click += new System.EventHandler(this.btn_registration_Click);
            // 
            // lbl_wrongLogPass
            // 
            this.lbl_wrongLogPass.AutoSize = true;
            this.lbl_wrongLogPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_wrongLogPass.ForeColor = System.Drawing.Color.Red;
            this.lbl_wrongLogPass.Location = new System.Drawing.Point(64, 9);
            this.lbl_wrongLogPass.Name = "lbl_wrongLogPass";
            this.lbl_wrongLogPass.Size = new System.Drawing.Size(198, 13);
            this.lbl_wrongLogPass.TabIndex = 6;
            this.lbl_wrongLogPass.Text = "Неправильний логін або пароль";
            this.lbl_wrongLogPass.Visible = false;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 124);
            this.Controls.Add(this.lbl_wrongLogPass);
            this.Controls.Add(this.btn_registration);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.lbl_password);
            this.Controls.Add(this.lbl_login);
            this.Controls.Add(this.tb_password);
            this.Controls.Add(this.tb_login);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Косметичний салон";
            this.Shown += new System.EventHandler(this.FormLogin_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_login;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.Label lbl_login;
        private System.Windows.Forms.Label lbl_password;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Button btn_registration;
        private System.Windows.Forms.Label lbl_wrongLogPass;
    }
}

