using System.Windows.Forms;
using CosmeticSalon.Common;
using CosmeticSalon.DB;

namespace CosmeticSalon.MainForms
{
    public partial class FormWork : Form
    {
        FormLogin mFormLogin;
        Account mUser;

        bool isAppExit = true;

        public FormWork(Account account, FormLogin parentForm)
        {
            mUser = account;
            mFormLogin = parentForm;

            InitializeComponent();
            mUser.initializeForm(this);

            lbl_name.Text = mUser.Surname + " " + mUser.Name + " " + mUser.MiddleName;
            lbl_post.Text = DBPresentation.instance().getPostName(mUser.Type);
            lbl_id.Text = "(ID: " + mUser.ID.ToString() + ")";
            lbl_id.Location = new System.Drawing.Point(lbl_name.Location.X + lbl_name.Size.Width - 4, lbl_id.Location.Y);
        }

        private void FormWork_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isAppExit)
            {
                mFormLogin.Close();
            }
            else
            {
                mFormLogin.reopen();
            }
            
        }

        private void btn_exit_Click(object sender, System.EventArgs e)
        {
            isAppExit = false;
            this.Close();
        }

        private void initEmployeesList()
        {
            lb_employees.Items.Clear();
            foreach (string str in 
                DBPresentation.instance().getStrListOfEmployees(
                    rbtn_active.Checked, 
                    tb_employeesSearch.Text.Length > 0 ? tb_employeesSearch.Text : null))
            {
               lb_employees.Items.Add(str);
            }
        }

        private void initRegistrationTab(FormWork form)
        {
            initEmployeesList();
        }

        private void btn_search_Click(object sender, System.EventArgs e)
        {
            initEmployeesList();
        }

        private void rbtn_active_CheckedChanged(object sender, System.EventArgs e)
        {
            initEmployeesList();
        }
    }
}
