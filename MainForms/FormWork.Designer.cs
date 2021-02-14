namespace CosmeticSalon.MainForms
{
    partial class FormWork
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
            this.tabControl_main = new System.Windows.Forms.TabControl();
            this.tab_schedule = new System.Windows.Forms.TabPage();
            this.tab_salary = new System.Windows.Forms.TabPage();
            this.tab_employees = new System.Windows.Forms.TabPage();
            this.btn_empl_cancel = new System.Windows.Forms.Button();
            this.btn_empl_approve = new System.Windows.Forms.Button();
            this.btn_empl_update = new System.Windows.Forms.Button();
            this.cb_posts = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tb_empl_salaryBonus = new System.Windows.Forms.TextBox();
            this.tb_empl_salaryBase = new System.Windows.Forms.TextBox();
            this.lbl_salaryBonus = new System.Windows.Forms.Label();
            this.lbl_salaryBase = new System.Windows.Forms.Label();
            this.lbl_empl_post = new System.Windows.Forms.Label();
            this.rtb_empl_exp = new System.Windows.Forms.RichTextBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.tb_empl_phone = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtn_unactiveList = new System.Windows.Forms.RadioButton();
            this.rbtn_activeList = new System.Windows.Forms.RadioButton();
            this.tb_empl_middleName = new System.Windows.Forms.TextBox();
            this.tb_empl_name = new System.Windows.Forms.TextBox();
            this.tb_employeesSearch = new System.Windows.Forms.TextBox();
            this.tb_empl_surname = new System.Windows.Forms.TextBox();
            this.lb_employees = new System.Windows.Forms.ListBox();
            this.lbl_empl_exp = new System.Windows.Forms.Label();
            this.lbl_empl_surname = new System.Windows.Forms.Label();
            this.lbl_empl_phone = new System.Windows.Forms.Label();
            this.lbl_empl_name = new System.Windows.Forms.Label();
            this.lbl_empl_middleName = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_post = new System.Windows.Forms.Label();
            this.lbl_id = new System.Windows.Forms.Label();
            this.btn_exit = new System.Windows.Forms.Button();
            this.tabControl_main.SuspendLayout();
            this.tab_employees.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl_main
            // 
            this.tabControl_main.Controls.Add(this.tab_schedule);
            this.tabControl_main.Controls.Add(this.tab_salary);
            this.tabControl_main.Controls.Add(this.tab_employees);
            this.tabControl_main.Location = new System.Drawing.Point(-4, 41);
            this.tabControl_main.Name = "tabControl_main";
            this.tabControl_main.SelectedIndex = 0;
            this.tabControl_main.Size = new System.Drawing.Size(808, 413);
            this.tabControl_main.TabIndex = 0;
            // 
            // tab_schedule
            // 
            this.tab_schedule.Location = new System.Drawing.Point(4, 22);
            this.tab_schedule.Name = "tab_schedule";
            this.tab_schedule.Padding = new System.Windows.Forms.Padding(3);
            this.tab_schedule.Size = new System.Drawing.Size(800, 387);
            this.tab_schedule.TabIndex = 0;
            this.tab_schedule.Text = "Розклад";
            this.tab_schedule.UseVisualStyleBackColor = true;
            // 
            // tab_salary
            // 
            this.tab_salary.Location = new System.Drawing.Point(4, 22);
            this.tab_salary.Name = "tab_salary";
            this.tab_salary.Padding = new System.Windows.Forms.Padding(3);
            this.tab_salary.Size = new System.Drawing.Size(800, 387);
            this.tab_salary.TabIndex = 1;
            this.tab_salary.Text = "Зарплата";
            this.tab_salary.UseVisualStyleBackColor = true;
            // 
            // tab_employees
            // 
            this.tab_employees.BackColor = System.Drawing.Color.Azure;
            this.tab_employees.Controls.Add(this.btn_empl_cancel);
            this.tab_employees.Controls.Add(this.btn_empl_approve);
            this.tab_employees.Controls.Add(this.btn_empl_update);
            this.tab_employees.Controls.Add(this.cb_posts);
            this.tab_employees.Controls.Add(this.groupBox2);
            this.tab_employees.Controls.Add(this.lbl_empl_post);
            this.tab_employees.Controls.Add(this.rtb_empl_exp);
            this.tab_employees.Controls.Add(this.btn_search);
            this.tab_employees.Controls.Add(this.tb_empl_phone);
            this.tab_employees.Controls.Add(this.groupBox1);
            this.tab_employees.Controls.Add(this.tb_empl_middleName);
            this.tab_employees.Controls.Add(this.tb_empl_name);
            this.tab_employees.Controls.Add(this.tb_employeesSearch);
            this.tab_employees.Controls.Add(this.tb_empl_surname);
            this.tab_employees.Controls.Add(this.lb_employees);
            this.tab_employees.Controls.Add(this.lbl_empl_exp);
            this.tab_employees.Controls.Add(this.lbl_empl_surname);
            this.tab_employees.Controls.Add(this.lbl_empl_phone);
            this.tab_employees.Controls.Add(this.lbl_empl_name);
            this.tab_employees.Controls.Add(this.lbl_empl_middleName);
            this.tab_employees.Location = new System.Drawing.Point(4, 22);
            this.tab_employees.Name = "tab_employees";
            this.tab_employees.Size = new System.Drawing.Size(800, 387);
            this.tab_employees.TabIndex = 2;
            this.tab_employees.Text = "Співробітники";
            // 
            // btn_empl_cancel
            // 
            this.btn_empl_cancel.Location = new System.Drawing.Point(555, 299);
            this.btn_empl_cancel.Name = "btn_empl_cancel";
            this.btn_empl_cancel.Size = new System.Drawing.Size(120, 23);
            this.btn_empl_cancel.TabIndex = 30;
            this.btn_empl_cancel.Text = "Скасувати";
            this.btn_empl_cancel.UseVisualStyleBackColor = true;
            this.btn_empl_cancel.Click += new System.EventHandler(this.btn_empl_cancel_Click);
            // 
            // btn_empl_approve
            // 
            this.btn_empl_approve.Location = new System.Drawing.Point(388, 299);
            this.btn_empl_approve.Name = "btn_empl_approve";
            this.btn_empl_approve.Size = new System.Drawing.Size(120, 23);
            this.btn_empl_approve.TabIndex = 29;
            this.btn_empl_approve.Text = "Затвердити";
            this.btn_empl_approve.UseVisualStyleBackColor = true;
            this.btn_empl_approve.Click += new System.EventHandler(this.btn_empl_approve_Click);
            // 
            // btn_empl_update
            // 
            this.btn_empl_update.Location = new System.Drawing.Point(471, 299);
            this.btn_empl_update.Name = "btn_empl_update";
            this.btn_empl_update.Size = new System.Drawing.Size(120, 23);
            this.btn_empl_update.TabIndex = 28;
            this.btn_empl_update.Text = "Оновити";
            this.btn_empl_update.UseVisualStyleBackColor = true;
            this.btn_empl_update.Click += new System.EventHandler(this.btn_empl_update_Click);
            // 
            // cb_posts
            // 
            this.cb_posts.FormattingEnabled = true;
            this.cb_posts.Location = new System.Drawing.Point(345, 204);
            this.cb_posts.Name = "cb_posts";
            this.cb_posts.Size = new System.Drawing.Size(179, 21);
            this.cb_posts.TabIndex = 27;
            this.cb_posts.SelectedIndexChanged += new System.EventHandler(this.cb_posts_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tb_empl_salaryBonus);
            this.groupBox2.Controls.Add(this.tb_empl_salaryBase);
            this.groupBox2.Controls.Add(this.lbl_salaryBonus);
            this.groupBox2.Controls.Add(this.lbl_salaryBase);
            this.groupBox2.Location = new System.Drawing.Point(530, 188);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(187, 67);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Заробітня плата";
            // 
            // tb_empl_salaryBonus
            // 
            this.tb_empl_salaryBonus.Location = new System.Drawing.Point(55, 39);
            this.tb_empl_salaryBonus.Name = "tb_empl_salaryBonus";
            this.tb_empl_salaryBonus.Size = new System.Drawing.Size(116, 20);
            this.tb_empl_salaryBonus.TabIndex = 27;
            // 
            // tb_empl_salaryBase
            // 
            this.tb_empl_salaryBase.Enabled = false;
            this.tb_empl_salaryBase.Location = new System.Drawing.Point(55, 13);
            this.tb_empl_salaryBase.Name = "tb_empl_salaryBase";
            this.tb_empl_salaryBase.Size = new System.Drawing.Size(116, 20);
            this.tb_empl_salaryBase.TabIndex = 26;
            // 
            // lbl_salaryBonus
            // 
            this.lbl_salaryBonus.AutoSize = true;
            this.lbl_salaryBonus.Location = new System.Drawing.Point(6, 42);
            this.lbl_salaryBonus.Name = "lbl_salaryBonus";
            this.lbl_salaryBonus.Size = new System.Drawing.Size(37, 13);
            this.lbl_salaryBonus.TabIndex = 25;
            this.lbl_salaryBonus.Text = "Бонус";
            // 
            // lbl_salaryBase
            // 
            this.lbl_salaryBase.AutoSize = true;
            this.lbl_salaryBase.Location = new System.Drawing.Point(6, 16);
            this.lbl_salaryBase.Name = "lbl_salaryBase";
            this.lbl_salaryBase.Size = new System.Drawing.Size(43, 13);
            this.lbl_salaryBase.TabIndex = 24;
            this.lbl_salaryBase.Text = "Ставка";
            // 
            // lbl_empl_post
            // 
            this.lbl_empl_post.AutoSize = true;
            this.lbl_empl_post.Location = new System.Drawing.Point(342, 188);
            this.lbl_empl_post.Name = "lbl_empl_post";
            this.lbl_empl_post.Size = new System.Drawing.Size(45, 13);
            this.lbl_empl_post.TabIndex = 23;
            this.lbl_empl_post.Text = "Посада";
            // 
            // rtb_empl_exp
            // 
            this.rtb_empl_exp.Location = new System.Drawing.Point(345, 128);
            this.rtb_empl_exp.Name = "rtb_empl_exp";
            this.rtb_empl_exp.Size = new System.Drawing.Size(372, 48);
            this.rtb_empl_exp.TabIndex = 22;
            this.rtb_empl_exp.Text = "";
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(225, 3);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(30, 20);
            this.btn_search.TabIndex = 3;
            this.btn_search.Text = "OK";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // tb_empl_phone
            // 
            this.tb_empl_phone.Location = new System.Drawing.Point(345, 76);
            this.tb_empl_phone.Name = "tb_empl_phone";
            this.tb_empl_phone.Size = new System.Drawing.Size(179, 20);
            this.tb_empl_phone.TabIndex = 21;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtn_unactiveList);
            this.groupBox1.Controls.Add(this.rbtn_activeList);
            this.groupBox1.Location = new System.Drawing.Point(12, 347);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 37);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // rbtn_unactiveList
            // 
            this.rbtn_unactiveList.AutoSize = true;
            this.rbtn_unactiveList.Location = new System.Drawing.Point(112, 14);
            this.rbtn_unactiveList.Name = "rbtn_unactiveList";
            this.rbtn_unactiveList.Size = new System.Drawing.Size(125, 17);
            this.rbtn_unactiveList.TabIndex = 1;
            this.rbtn_unactiveList.Text = "Очікують реєстрації";
            this.rbtn_unactiveList.UseVisualStyleBackColor = true;
            this.rbtn_unactiveList.CheckedChanged += new System.EventHandler(this.rbtn_unactiveList_CheckedChanged);
            // 
            // rbtn_activeList
            // 
            this.rbtn_activeList.AutoSize = true;
            this.rbtn_activeList.Location = new System.Drawing.Point(6, 14);
            this.rbtn_activeList.Name = "rbtn_activeList";
            this.rbtn_activeList.Size = new System.Drawing.Size(63, 17);
            this.rbtn_activeList.TabIndex = 0;
            this.rbtn_activeList.Text = "Активні";
            this.rbtn_activeList.UseVisualStyleBackColor = true;
            this.rbtn_activeList.CheckedChanged += new System.EventHandler(this.rbtn_active_CheckedChanged);
            // 
            // tb_empl_middleName
            // 
            this.tb_empl_middleName.Location = new System.Drawing.Point(597, 25);
            this.tb_empl_middleName.Name = "tb_empl_middleName";
            this.tb_empl_middleName.Size = new System.Drawing.Size(120, 20);
            this.tb_empl_middleName.TabIndex = 20;
            // 
            // tb_empl_name
            // 
            this.tb_empl_name.Location = new System.Drawing.Point(471, 25);
            this.tb_empl_name.Name = "tb_empl_name";
            this.tb_empl_name.Size = new System.Drawing.Size(120, 20);
            this.tb_empl_name.TabIndex = 19;
            // 
            // tb_employeesSearch
            // 
            this.tb_employeesSearch.Location = new System.Drawing.Point(12, 3);
            this.tb_employeesSearch.Name = "tb_employeesSearch";
            this.tb_employeesSearch.Size = new System.Drawing.Size(207, 20);
            this.tb_employeesSearch.TabIndex = 1;
            // 
            // tb_empl_surname
            // 
            this.tb_empl_surname.Location = new System.Drawing.Point(345, 25);
            this.tb_empl_surname.Name = "tb_empl_surname";
            this.tb_empl_surname.Size = new System.Drawing.Size(120, 20);
            this.tb_empl_surname.TabIndex = 18;
            // 
            // lb_employees
            // 
            this.lb_employees.FormattingEnabled = true;
            this.lb_employees.Location = new System.Drawing.Point(12, 26);
            this.lb_employees.Name = "lb_employees";
            this.lb_employees.Size = new System.Drawing.Size(243, 316);
            this.lb_employees.TabIndex = 0;
            this.lb_employees.SelectedIndexChanged += new System.EventHandler(this.lb_employees_SelectedIndexChanged);
            // 
            // lbl_empl_exp
            // 
            this.lbl_empl_exp.AutoSize = true;
            this.lbl_empl_exp.Location = new System.Drawing.Point(342, 112);
            this.lbl_empl_exp.Name = "lbl_empl_exp";
            this.lbl_empl_exp.Size = new System.Drawing.Size(80, 13);
            this.lbl_empl_exp.TabIndex = 17;
            this.lbl_empl_exp.Text = "Досвід роботи";
            // 
            // lbl_empl_surname
            // 
            this.lbl_empl_surname.AutoSize = true;
            this.lbl_empl_surname.Location = new System.Drawing.Point(342, 9);
            this.lbl_empl_surname.Name = "lbl_empl_surname";
            this.lbl_empl_surname.Size = new System.Drawing.Size(56, 13);
            this.lbl_empl_surname.TabIndex = 13;
            this.lbl_empl_surname.Text = "Прізвище";
            // 
            // lbl_empl_phone
            // 
            this.lbl_empl_phone.AutoSize = true;
            this.lbl_empl_phone.Location = new System.Drawing.Point(342, 60);
            this.lbl_empl_phone.Name = "lbl_empl_phone";
            this.lbl_empl_phone.Size = new System.Drawing.Size(52, 13);
            this.lbl_empl_phone.TabIndex = 16;
            this.lbl_empl_phone.Text = "Телефон";
            // 
            // lbl_empl_name
            // 
            this.lbl_empl_name.AutoSize = true;
            this.lbl_empl_name.Location = new System.Drawing.Point(468, 9);
            this.lbl_empl_name.Name = "lbl_empl_name";
            this.lbl_empl_name.Size = new System.Drawing.Size(26, 13);
            this.lbl_empl_name.TabIndex = 14;
            this.lbl_empl_name.Text = "Ім\'я";
            // 
            // lbl_empl_middleName
            // 
            this.lbl_empl_middleName.AutoSize = true;
            this.lbl_empl_middleName.Location = new System.Drawing.Point(594, 9);
            this.lbl_empl_middleName.Name = "lbl_empl_middleName";
            this.lbl_empl_middleName.Size = new System.Drawing.Size(67, 13);
            this.lbl_empl_middleName.TabIndex = 15;
            this.lbl_empl_middleName.Text = "По-батькові";
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_name.Location = new System.Drawing.Point(6, 6);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(139, 16);
            this.lbl_name.TabIndex = 1;
            this.lbl_name.Text = "Name Name Name";
            // 
            // lbl_post
            // 
            this.lbl_post.AutoSize = true;
            this.lbl_post.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_post.Location = new System.Drawing.Point(6, 22);
            this.lbl_post.Name = "lbl_post";
            this.lbl_post.Size = new System.Drawing.Size(28, 13);
            this.lbl_post.TabIndex = 2;
            this.lbl_post.Text = "Post";
            // 
            // lbl_id
            // 
            this.lbl_id.AutoSize = true;
            this.lbl_id.Location = new System.Drawing.Point(142, 8);
            this.lbl_id.Name = "lbl_id";
            this.lbl_id.Size = new System.Drawing.Size(36, 13);
            this.lbl_id.TabIndex = 3;
            this.lbl_id.Text = "(id : 1)";
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.SystemColors.Control;
            this.btn_exit.Location = new System.Drawing.Point(713, 12);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 23);
            this.btn_exit.TabIndex = 4;
            this.btn_exit.Text = "Вихід";
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // FormWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.lbl_id);
            this.Controls.Add(this.lbl_post);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.tabControl_main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormWork";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormWork";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormWork_FormClosed);
            this.tabControl_main.ResumeLayout(false);
            this.tab_employees.ResumeLayout(false);
            this.tab_employees.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl_main;
        private System.Windows.Forms.TabPage tab_schedule;
        private System.Windows.Forms.TabPage tab_salary;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lbl_post;
        private System.Windows.Forms.Label lbl_id;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.TabPage tab_employees;
        private System.Windows.Forms.ListBox lb_employees;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtn_unactiveList;
        private System.Windows.Forms.RadioButton rbtn_activeList;
        private System.Windows.Forms.TextBox tb_employeesSearch;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.RichTextBox rtb_empl_exp;
        private System.Windows.Forms.TextBox tb_empl_phone;
        private System.Windows.Forms.TextBox tb_empl_middleName;
        private System.Windows.Forms.TextBox tb_empl_name;
        private System.Windows.Forms.TextBox tb_empl_surname;
        private System.Windows.Forms.Label lbl_empl_exp;
        private System.Windows.Forms.Label lbl_empl_surname;
        private System.Windows.Forms.Label lbl_empl_phone;
        private System.Windows.Forms.Label lbl_empl_name;
        private System.Windows.Forms.Label lbl_empl_middleName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbl_salaryBonus;
        private System.Windows.Forms.Label lbl_salaryBase;
        private System.Windows.Forms.Label lbl_empl_post;
        private System.Windows.Forms.TextBox tb_empl_salaryBonus;
        private System.Windows.Forms.TextBox tb_empl_salaryBase;
        private System.Windows.Forms.ComboBox cb_posts;
        private System.Windows.Forms.Button btn_empl_cancel;
        private System.Windows.Forms.Button btn_empl_approve;
        private System.Windows.Forms.Button btn_empl_update;
    }
}