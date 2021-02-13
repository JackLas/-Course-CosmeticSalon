using System;
using System.Windows.Forms;
using CosmeticSalon.Common;
using CosmeticSalon.DB;

namespace CosmeticSalon
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            Account acc = DBPresentation.instance().login(tb_login.Text, tb_password.Text);
            switch (acc.Type)
            {
                case Types.AccountType.UNKNOWN:
                    MessageBox.Show("unknown");
                    break;
                case Types.AccountType.NOT_ACTIVE:
                    MessageBox.Show("not active");
                    break;
                default:
                    MessageBox.Show("OK");
                    break;
            }
        }

        private void btn_registration_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form reg = new FormRegistration(this);
            reg.Show();
        }
    }
}
