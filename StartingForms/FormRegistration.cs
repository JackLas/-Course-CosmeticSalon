using System;
using System.Windows.Forms;
using CosmeticSalon.DB;

namespace CosmeticSalon
{
    public partial class FormRegistration : Form
    {
        private Form mParentForm;

        public FormRegistration(Form parent)
        {
            mParentForm = parent;
            InitializeComponent();
        }

        private void FormRegistration_FormClosed(object sender, FormClosedEventArgs e)
        {
            mParentForm.Show();
        }

        private void btn_registration_Click(object sender, EventArgs e)
        {
            if (checkInputValidity())
            {
                this.Hide();

                DBPresentation.instance().register(
                    tb_login.Text,
                    tb_password.Text,
                    tb_surname.Text,
                    tb_name.Text,
                    tb_middleName.Text,
                    tb_phone.Text,
                    rtb_exp.Lines
                );

                MessageBox.Show("Реєстрація успішна, очікуйте підтвердження адміністратора",
                                "Реєстрація",
                                MessageBoxButtons.OK);

                mParentForm.Show();
                this.Close();
            }
        }

        private bool checkInputValidity()
        {
            if (tb_name.Text.Length == 0)
            {
                MessageBox.Show("Введіть ім'я");
                return false;
            }

            if (tb_surname.Text.Length == 0)
            {
                MessageBox.Show("Введіть прізвище");
                return false;
            }

            if (tb_password.Text.Length == 0)
            {
                MessageBox.Show("Введіть пароль");
                return false;
            }

            if (tb_login.Text.Length == 0)
            {
                MessageBox.Show("Введіть логін");
                return false;
            }

            if (tb_password.Text != tb_repassword.Text)
            {
                MessageBox.Show("Паролі не співпадають");
                return false;
            }

            if (DBPresentation.instance().isLoginAlreadyExists(tb_login.Text))
            {
                MessageBox.Show("Такий логін вже існує");
                return false;
            }

            return true;
        }
    }
}
