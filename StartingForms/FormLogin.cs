using System;
using System.Windows.Forms;

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

        }

        private void btn_registration_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form reg = new FormRegistration(this);
            reg.Show();
        }
    }
}
