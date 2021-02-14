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
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_post = new System.Windows.Forms.Label();
            this.lbl_id = new System.Windows.Forms.Label();
            this.btn_exit = new System.Windows.Forms.Button();
            this.tab_employees = new System.Windows.Forms.TabPage();
            this.lb_employees = new System.Windows.Forms.ListBox();
            this.tb_employeesSearch = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtn_active = new System.Windows.Forms.RadioButton();
            this.rbtn_unactiveList = new System.Windows.Forms.RadioButton();
            this.btn_search = new System.Windows.Forms.Button();
            this.tabControl_main.SuspendLayout();
            this.tab_employees.SuspendLayout();
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
            // tab_employees
            // 
            this.tab_employees.Controls.Add(this.btn_search);
            this.tab_employees.Controls.Add(this.groupBox1);
            this.tab_employees.Controls.Add(this.tb_employeesSearch);
            this.tab_employees.Controls.Add(this.lb_employees);
            this.tab_employees.Location = new System.Drawing.Point(4, 22);
            this.tab_employees.Name = "tab_employees";
            this.tab_employees.Size = new System.Drawing.Size(800, 387);
            this.tab_employees.TabIndex = 2;
            this.tab_employees.Text = "Співробітники";
            this.tab_employees.UseVisualStyleBackColor = true;
            // 
            // lb_employees
            // 
            this.lb_employees.FormattingEnabled = true;
            this.lb_employees.Location = new System.Drawing.Point(12, 26);
            this.lb_employees.Name = "lb_employees";
            this.lb_employees.Size = new System.Drawing.Size(243, 316);
            this.lb_employees.TabIndex = 0;
            // 
            // tb_employeesSearch
            // 
            this.tb_employeesSearch.Location = new System.Drawing.Point(12, 3);
            this.tb_employeesSearch.Name = "tb_employeesSearch";
            this.tb_employeesSearch.Size = new System.Drawing.Size(207, 20);
            this.tb_employeesSearch.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtn_unactiveList);
            this.groupBox1.Controls.Add(this.rbtn_active);
            this.groupBox1.Location = new System.Drawing.Point(12, 347);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 37);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // rbtn_active
            // 
            this.rbtn_active.AutoSize = true;
            this.rbtn_active.Checked = true;
            this.rbtn_active.Location = new System.Drawing.Point(6, 14);
            this.rbtn_active.Name = "rbtn_active";
            this.rbtn_active.Size = new System.Drawing.Size(63, 17);
            this.rbtn_active.TabIndex = 0;
            this.rbtn_active.TabStop = true;
            this.rbtn_active.Text = "Активні";
            this.rbtn_active.UseVisualStyleBackColor = true;
            this.rbtn_active.CheckedChanged += new System.EventHandler(this.rbtn_active_CheckedChanged);
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
        private System.Windows.Forms.RadioButton rbtn_active;
        private System.Windows.Forms.TextBox tb_employeesSearch;
        private System.Windows.Forms.Button btn_search;
    }
}