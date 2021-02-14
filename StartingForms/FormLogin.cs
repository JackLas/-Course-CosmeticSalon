using System;
using System.Windows.Forms;
using CosmeticSalon.Common;
using CosmeticSalon.DB;
using CosmeticSalon.MainForms;

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
                    Form main = new FormWork(acc, this);
                    this.Hide();
                    main.Show();
                    break;
            }

        }

        private void btn_registration_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form reg = new FormRegistration(this);
            reg.Show();
        }

        public void reopen()
        {
            tb_login.Text = "";
            tb_login.Focus();
            tb_password.Text = "";
            this.Show();
        }

        private void FormLogin_Shown(object sender, EventArgs e)
        {
            // -- for testing purpose --
            tb_login.Text = "admin";
            tb_password.Text = "admin";
            btn_login_Click(this, null);
        }
    }
}
