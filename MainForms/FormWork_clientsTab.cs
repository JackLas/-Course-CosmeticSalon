using CosmeticSalon.DB;
using CosmeticSalon.Common;
using System.Windows.Forms;

namespace CosmeticSalon.MainForms
{
    partial class FormWork
    {
        public void initClientsTab()
        {
            initClientsList();
            cleanClientsFields();
        }

        public void initClientsList(bool useSearch = false)
        {
            lb_clients.Items.Clear();
            lb_clients.Items.AddRange(
                DBPresentation.instance().getClientsStringList(
                    (useSearch && (tb_clients_search.Text.Length > 0)) ? tb_clients_search.Text  : null));
            lb_clients.SelectedIndex = -1;
        }

        private void cleanClientsFields()
        {
            lb_clients.SelectedIndex = -1;
            tb_clients_fullName.Text = "";
            tb_clients_phone.Text = "";
            btn_clients_add.Show();
            btn_clients_delete.Hide();
            btn_clients_reset.Hide();
            btn_clients_update.Hide();
        }

        private void btn_clients_update_Click(object sender, System.EventArgs e)
        {
            Client client = new Client();

            if (lb_clients.SelectedIndex < 0)
            {
                return;
            }

            if (!Utils.checkPhoneFormat(tb_clients_phone.Text))
            {
                return;
            }

            int id = 0;
            if (!Utils.getIDFromString(lb_clients.SelectedItem.ToString(), out id))
            {
                return;
            }

            client.ID = id;
            client.FullName = tb_clients_fullName.Text;
            client.Phone = tb_clients_phone.Text;

            DBPresentation.instance().updateClients(client);

            initClientsList();
            cleanClientsFields();
        }

        private void btn_clients_delete_Click(object sender, System.EventArgs e)
        {
            if (lb_clients.SelectedIndex < 0)
            {
                return;
            }
            int id = 0;
            if (!Utils.getIDFromString(lb_clients.SelectedItem.ToString(), out id))
            {
                return;
            }
            DBPresentation.instance().deleteClientByID(id);
            initClientsList();
            cleanClientsFields();
        }

        private void btn_clients_reset_Click(object sender, System.EventArgs e)
        {
            cleanClientsFields();
        }

        private void btn_clients_add_Click(object sender, System.EventArgs e)
        {
            if (tb_clients_fullName.Text == "")
            {
                MessageBox.Show("Введіть ім'я клієнта");
                return;
            }
            if (tb_clients_phone.Text == "")
            {
                MessageBox.Show("Введіть номер телефону клієнта");
                return;
            }
            if (!Utils.checkPhoneFormat(tb_clients_phone.Text))
            {
                return;
            }

            Client client = new Client();

            client.FullName = tb_clients_fullName.Text;
            client.Phone = tb_clients_phone.Text;

            if (!DBPresentation.instance().tryToAddNewClient(client))
            {
                MessageBox.Show("Клієнт за цим номером телефону вже існує");
            }
            else
            {
                initClientsList();
                cleanClientsFields();
            }
        }

        private void btn_clients_search_Click(object sender, System.EventArgs e)
        {
            initClientsList(true);
        }

        private void lb_clients_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (lb_clients.SelectedIndex < 0)
            {
                btn_clients_add.Show();
                btn_clients_delete.Hide();
                btn_clients_reset.Hide();
                btn_clients_update.Hide();
                return;
            }
            else
            {
                btn_clients_add.Hide();
                btn_clients_delete.Show();
                btn_clients_reset.Show();
                btn_clients_update.Show();
            }

            int id = 0;
            if (!Utils.getIDFromString(lb_clients.SelectedItem.ToString(), out id))
            {
                return;
            }

            Client client = DBPresentation.instance().getClientByID(id);

            tb_clients_fullName.Text = client.FullName;
            tb_clients_phone.Text = client.Phone;
        }
    }
}