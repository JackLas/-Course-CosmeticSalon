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
                    lbl_wrongLogPass.Visible = true;
                    break;
                case Types.AccountType.NOT_ACTIVE:
                    MessageBox.Show("Зачекайте підтвердження адміністратора");
                    lbl_wrongLogPass.Visible = false;
                    break;
                default:
                    MessageBox.Show("OK");
                    lbl_wrongLogPass.Visible = false;
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
