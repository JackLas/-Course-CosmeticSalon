using System.Windows.Forms;
using CosmeticSalon.Common;

namespace CosmeticSalon.MainForms
{
    public partial class FormWork : Form
    {
        Form mParentForm;
        Account mUser;

        public FormWork(Account account, Form parentForm)
        {
            mUser = account;
            mParentForm = parentForm;

            InitializeComponent();

            mUser.initializeForm(this);
        }

        private void FormWork_FormClosed(object sender, FormClosedEventArgs e)
        {
            mParentForm.Close();
        }
    }
}
