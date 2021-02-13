using CosmeticSalon.Common;

namespace CosmeticSalon.MainForms
{
    partial class FormWork
    {
        public partial class AccountantFormInitializer : IMainWindowInitializer
        {
            public void Initialize(FormWork form)
            {
                form.Text = "Hello from Accountant";
                form.lbl_test.Text = "Hello from Accountant";
            }
        }
    }
}