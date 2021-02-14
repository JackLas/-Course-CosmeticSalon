using CosmeticSalon.DB;
using CosmeticSalon.Common;
using System.Windows.Forms;

namespace CosmeticSalon.MainForms
{
    partial class FormWork
    {
        public void initOtherTab()
        {
            initServiceList();
            initPostList();
        }

        private void initServiceList()
        {
            cb_updService_name.Items.Clear();
            cb_updService_name.Items.AddRange(DBPresentation.instance().getServicesStringList());
        }

        private void initPostList()
        {
            cb_updPost_name.Items.Clear();
            cb_updPost_name.Items.AddRange(DBPresentation.instance().getPostsStringList());
            if (cb_updPost_name.Items.Count > 0) cb_updPost_name.Items.RemoveAt(0);
        }

        private void btn_newService_add_Click(object sender, System.EventArgs e)
        {
            if (tb_newService_name.Text.Length == 0)
            {
                MessageBox.Show("Введіть назву");
                return;
            }
            int price = 0;
            if (!int.TryParse(tb_newService_price.Text , out price))
            {
                MessageBox.Show("Невірний формат ціни");
                return;
            }

            DBPresentation.instance().addService(tb_newService_name.Text, price);
            tb_newService_name.Text = "";
            tb_newService_price.Text = "";
            initServiceList();
            showSuccessMessage();
        }

        private void btn_newPost_add_Click(object sender, System.EventArgs e)
        {
            if (tb_newPost_name.Text.Length == 0)
            {
                MessageBox.Show("Введіть назву");
                return;
            }
            int salary = 0;
            if (!int.TryParse(tb_newPost_salary.Text, out salary))
            {
                MessageBox.Show("Невірний формат заробітної плати");
                return;
            }

            DBPresentation.instance().addPost(tb_newPost_name.Text, salary);
            tb_newPost_name.Text = "";
            tb_newPost_salary.Text = "";
            initPostList();
            showSuccessMessage();
        }

        private void btn_updService_upd_Click(object sender, System.EventArgs e)
        {
            if (cb_updService_name.SelectedIndex < 0)
            {
                MessageBox.Show("Оберіть послугу");
                return;
            }
            int price = 0;
            if (!int.TryParse(tb_updService_price.Text, out price))
            {
                MessageBox.Show("Введіть ціну");
                return;
            }
            int id = 0;
            if (!Utils.getIDFromString(cb_updService_name.SelectedItem.ToString(), out id))
            {
                return;
            }
            DBPresentation.instance().updateService(id, price);
            showSuccessMessage();
        }

        private void btn_updPost_upd_Click(object sender, System.EventArgs e)
        {
            if (cb_updPost_name.SelectedIndex < 0)
            {
                MessageBox.Show("Оберіть посаду");
                return;
            }
            int salary = 0;
            if (!int.TryParse(tb_updPost_salary.Text, out salary))
            {
                MessageBox.Show("Введіть заробітну плату");
                return;
            }
            int id = 0;
            if (!Utils.getIDFromString(cb_updPost_name.SelectedItem.ToString(), out id))
            {
                return;
            }
            DBPresentation.instance().updatePost(id, salary);
            showSuccessMessage();
        }

        private void cb_updService_name_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (cb_updService_name.SelectedIndex < 0) return;
            int id = 0;
            if (!Utils.getIDFromString(cb_updService_name.SelectedItem.ToString(), out id))
            {
                return;
            }
            tb_updService_price.Text = 
                DBPresentation.instance().getServicePriceByID(id).ToString();
        }

        private void cb_updPost_name_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (cb_updPost_name.SelectedIndex < 0) return;
            int id = 0;
            if (!Utils.getIDFromString(cb_updPost_name.SelectedItem.ToString(), out id))
            {
                return;
            }
            tb_updPost_salary.Text =
                DBPresentation.instance().getPostSalaryByID(id).ToString();
        }
    }
}