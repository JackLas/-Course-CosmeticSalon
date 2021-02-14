using CosmeticSalon.DB;
using CosmeticSalon.Common;
using System.Windows.Forms;

namespace CosmeticSalon.MainForms
{
    partial class FormWork
    {
        private void initEmployeesList()
        {
            lb_employees.Items.Clear();
            foreach (string str in
                DBPresentation.instance().getStrListOfEmployees(
                    rbtn_activeList.Checked,
                    tb_employeesSearch.Text.Length > 0 ? tb_employeesSearch.Text : null))
            {
                lb_employees.Items.Add(str);
            }
        }

        private void initEmployeesTab(FormWork form)
        {
            rbtn_activeList.Checked = true;
            cb_posts.Items.AddRange(DBPresentation.instance().getPostsStringList());
            if (cb_posts.Items.Count > 0) cb_posts.Items.RemoveAt(0);
            initEmployeesList();
        }

        private void cleanEmployeeTabsFields()
        {
            tb_empl_surname.Text = "";
            tb_empl_name.Text = "";
            tb_empl_middleName.Text = "";
            tb_empl_phone.Text = "";
            rtb_empl_exp.Clear();
            cb_posts.SelectedIndex = -1;
            tb_empl_salaryBase.Text = "";
            tb_empl_salaryBonus.Text = "";
        }

        private void btn_search_Click(object sender, System.EventArgs e)
        {
            initEmployeesList();
        }

        private void rbtn_active_CheckedChanged(object sender, System.EventArgs e)
        {
            initEmployeesList();

            if (rbtn_activeList.Checked)
            {
                tb_empl_surname.Enabled = true;
                tb_empl_name.Enabled = true;
                tb_empl_middleName.Enabled = true;
                tb_empl_phone.Enabled = true;
                rtb_empl_exp.Enabled = true;
                btn_empl_approve.Hide();
                btn_empl_cancel.Hide();
                btn_empl_update.Show();
                cleanEmployeeTabsFields();
            }
        }

        private void rbtn_unactiveList_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rbtn_unactiveList.Checked)
            {
                tb_empl_surname.Enabled = false;
                tb_empl_name.Enabled = false;
                tb_empl_middleName.Enabled = false;
                tb_empl_phone.Enabled = false;
                rtb_empl_exp.Enabled = false;
                btn_empl_approve.Show();
                btn_empl_cancel.Show();
                btn_empl_update.Hide();
                cleanEmployeeTabsFields();
            }
        }

        private void lb_employees_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int selectedEmplID = 0;
            if (!Utils.getIDFromString(lb_employees.SelectedItem.ToString(), out selectedEmplID))
            {
                return;
            }

            Employee empl = DBPresentation.instance().getEmployeeByID(selectedEmplID);

            tb_empl_surname.Text = empl.Surname;
            tb_empl_name.Text = empl.Name;
            tb_empl_middleName.Text = empl.MiddleName;
            tb_empl_phone.Text = empl.Phone;
            rtb_empl_exp.Lines = empl.Expirience;
            cb_posts.SelectedIndex = cb_posts.Items.IndexOf(empl.PostID.ToString() + ": " + empl.Post);
            if (rbtn_activeList.Checked)
            {
                tb_empl_salaryBase.Text = DBPresentation.instance().getPostBaseSalaryByName(empl.Post).ToString();
            }
            tb_empl_salaryBonus.Text = empl.SalaryBonus.ToString();
        }

        private void cb_posts_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (cb_posts.SelectedIndex < 0) return;
            string postName = Utils.getIDBodyFromString(cb_posts.SelectedItem.ToString());
            tb_empl_salaryBase.Text = DBPresentation.instance().getPostBaseSalaryByName(postName).ToString();
        }

        private void btn_empl_approve_Click(object sender, System.EventArgs e)
        {
            if (lb_employees.SelectedItem == null)
            {
                MessageBox.Show("Необхідно обрати користувача");
                return;
            }

            if (cb_posts.SelectedItem == null)
            {
                MessageBox.Show("Необхідно обрати посаду");
                return;
            }

            int bonus = 0;
            if (!int.TryParse(tb_empl_salaryBonus.Text, out bonus))
            {
                MessageBox.Show("Невірний формат заробітньої плати");
                return;
            }

            int selectedEmplID = 0;
            if (!Utils.getIDFromString(lb_employees.SelectedItem.ToString(), out selectedEmplID))
                return;
            int postID = 0;
            if (!Utils.getIDFromString(cb_posts.SelectedItem.ToString(), out postID))
                return;

            DBPresentation.instance().aproveRegistration(selectedEmplID, postID, bonus);
            initEmployeesList();
            cleanEmployeeTabsFields();
            MessageBox.Show("Затверджено");
        }

        private void btn_empl_cancel_Click(object sender, System.EventArgs e)
        {
            if (lb_employees.SelectedItem == null)
            {
                MessageBox.Show("Необхідно обрати користувача");
                return;
            }

            int selectedEmplID = 0;
            if (!Utils.getIDFromString(lb_employees.SelectedItem.ToString(), out selectedEmplID))
                return;

            DBPresentation.instance().cancelRegistration(selectedEmplID);
            initEmployeesList();
            cleanEmployeeTabsFields();
            MessageBox.Show("Скасовано");
        }

        private void btn_empl_update_Click(object sender, System.EventArgs e)
        {
            if (lb_employees.SelectedIndex < 0)
            {
                MessageBox.Show("Оберіть співробітника");
                return;
            }

            Employee empl = new Employee();

            int id = 0;
            Utils.getIDFromString(lb_employees.SelectedItem.ToString(), out id);
            empl.ID = id;
            empl.Surname = tb_empl_surname.Text;
            empl.Name = tb_empl_name.Text;
            empl.MiddleName = tb_empl_middleName.Text;
            empl.Phone = tb_empl_phone.Text;
            empl.Expirience = rtb_empl_exp.Lines;
            int salary = 0;
            int.TryParse(tb_empl_salaryBonus.Text, out salary);
            empl.SalaryBonus = salary;
            int postID = 0;
            Utils.getIDFromString(cb_posts.SelectedItem.ToString(), out postID);
            empl.PostID = postID;

            DBPresentation.instance().updateEmployee(empl);
            MessageBox.Show("Оновлено");
        }
    }
}