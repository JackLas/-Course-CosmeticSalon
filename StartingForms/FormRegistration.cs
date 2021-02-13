using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void btn_registration_Click(object sender, EventArgs e)
        {
            this.Hide();
            MessageBox.Show("Реєстрація успішна, очікуйте підтвердження адміністратора", 
                            "Реєстрація",
                            MessageBoxButtons.OK);
            mParentForm.Show();
            this.Close();
        }
    }
}
